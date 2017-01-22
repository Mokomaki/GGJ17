using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
#if UNITY_EDITOR
using UnityEditor;
#endif

[RequireComponent(typeof(LineRenderer))]
public class ShortLineHandler : MonoBehaviour
{
    [System.Serializable]
    public class Func
    {
        public int UseFunction = 1;
        public float FunctionInput = 0.2f;
        public float FunctionSize = 1.0f;
        public float StartPoint = 0.0f;
        public float EndPoint = 1.0f;
        public bool InUse = true;
    }

    public List<Func> functions = new List<Func>();

    [Range(0.1f,10)]
    public float length = 1;
    int LinePoints = 50;
    public Vector3[] positions;
    
    public float Speed = 1.0f;

    public float Accuracy = 0.5f;

    public UnityEvent CorrectFunction;
    public UnityEvent BadFunction;

    LineHandler lh;

    LineRenderer lr;
    int i = 0;
    int j = 0;

    int index;
    float error;
    
    [ContextMenu("Render Line")]
    void Start()
    {
        LinePoints = Mathf.Max(LinePoints, 1);

        lr = GetComponent<LineRenderer>();

        lr.numCornerVertices = 1;
        lr.numCapVertices = 3;
        lr.useWorldSpace = false;
        lr.widthMultiplier = Accuracy;//LineHandler.Instance.LineWidth;

        SetPositions();
    }

    public void SetPositions()
    {
        lh = LineHandler.Instance;

        LinePoints = Mathf.CeilToInt(length / lh.Ratio);
        positions = new Vector3[LinePoints];

        Curve();

        lr.numPositions = LinePoints;
        lr.SetPositions(positions);
    }
    
    void Update()
    {
        transform.localPosition = transform.localPosition + Vector3.left * Speed * Time.deltaTime;
        CheckWave();
    }

    void CheckWave()
    {
        index = lh.XIndex(transform);

        if (index + LinePoints > lh.LinePoints)
            return;

        if (index < 0)
        {
            BadFunction.Invoke();
            return;
        }

        error = 0;
        float height = lh.transform.InverseTransformPoint(transform.position).y;
        
        for (i = 0; i < LinePoints; i++)
        {
            error += Mathf.Abs(positions[i].y+height - lh.positions[index + i].y);
        }

        if (error/LinePoints < Accuracy)
        {
            CorrectFunction.Invoke();
        }
    }

    float Y(int ipos)
    {
        float retVal = 0;
        float pos = ipos * lh.Ratio;
        foreach(var f in functions)
        {
            if (!f.InUse)
                continue;

            if (f.StartPoint < pos && pos < f.EndPoint)
            {
                switch (f.UseFunction)
                {
                    case 1: // linear with input as center
                        retVal += pos < f.StartPoint + f.FunctionInput ?
                            Mathf.Lerp(0, f.FunctionSize, (pos - f.StartPoint) / f.FunctionInput) :
                            Mathf.Lerp(0, f.FunctionSize, (f.EndPoint - pos) / (f.EndPoint - f.StartPoint - f.FunctionInput));
                        break;
                    case 2: // sin with input as x multiplier
                        retVal += Mathf.Sin((pos-f.StartPoint) * f.FunctionInput) * f.FunctionSize;
                        break;
                    case 3: // half sin with input as x multiplier
                        retVal += Mathf.Clamp(Mathf.Sin((pos - f.StartPoint) * f.FunctionInput), 0, float.MaxValue) * f.FunctionSize;
                        break;
                    default:
                        break;
                }
            }
        }

        return Mathf.Clamp(retVal,0,10);
    }

    void Curve()
    {
        for (i = 0; i < LinePoints; i++)
        {
            positions[i] = new Vector3(i * lh.Ratio, Y(i), 0);
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    public void Reach()
    {
        Heart.Instance.TakesDmG();
        Destroy(gameObject);
    }

#if UNITY_EDITOR
    void OnValidate()
    {
        //Start();
    }
#endif
}
