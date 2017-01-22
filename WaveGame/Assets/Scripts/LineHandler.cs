using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

[RequireComponent(typeof(LineRenderer))]
public class LineHandler : MonoBehaviour
{
    public static LineHandler Instance;

    public Transform FollowObject;

    public float LineWidth = 0.1f;
    public float LineLength = 7f;
    public int LinePoints = 50;
    public float Ratio;
    public Vector3[] positions;
    //public Queue<Vector3> positions = new Queue<Vector3>(SIZE);

    public float Lifetime = 2.0f;
    float Frequency = 0.01f;

    LineRenderer lr;
    int i = 0;

    float tim = 0;

    void Awake()
    {
        Instance = this;
    }

    // Use this for initialization
    void Start()
    {
        Instance = this;
        SetUp();
    }

    void MovePositions()
    {
        var z = transform.localPosition.z;

        //set last point to keep right length
        positions[LinePoints-1] = new Vector3(LineLength - transform.localPosition.x, positions[LinePoints - 2].y, z);
        for (i = LinePoints-3; i > 0; i--)
        {
            positions[i+1] = new Vector3(i * Ratio,positions[i].y, z);
        }
        //set first point to start x
        positions[1] = new Vector3(0, transform.InverseTransformPoint(FollowObject.position).y, transform.localPosition.z);


        SmoothEnds();
        lr.SetPositions(positions);
    }

    void SetPositions()
    {
        positions = new Vector3[LinePoints];
        for (i = 0; i < LinePoints; i++)
        {
            positions[i] = new Vector3(i * Ratio, 0);
        }

        lr.numPositions = LinePoints;
        lr.SetPositions(positions);
    }

    void SmoothEnds()
    {
        positions[0] = new Vector3(-transform.localPosition.x, transform.InverseTransformPoint(FollowObject.position).y, transform.localPosition.z);
        lr.SetPosition(0, positions[0]);

        positions[LinePoints - 1] = new Vector3(LineLength - transform.localPosition.x, positions[LinePoints - 1].y, transform.localPosition.z);
        lr.SetPosition(LinePoints - 1, positions[LinePoints - 1]);
    }

    // Update is called once per frame
    void Update()
    {
        while (Time.time - tim > Frequency && Frequency > 0.0001f)
        {
            tim += Frequency;
            MovePositions();
        }
        transform.localPosition = new Vector3((Time.time - tim)*Ratio/Frequency, transform.localPosition.y, transform.localPosition.z);
        SmoothEnds();
    }

    public int XIndex(Transform t2)
    {
        return Mathf.FloorToInt(transform.InverseTransformPoint(t2.position).x / Ratio);
    }

    void SetUp()
    {
        Instance = this;
        if (!FollowObject)
            FollowObject = transform;
        LinePoints = Mathf.Max(LinePoints, 1);
        Ratio = LineLength / LinePoints;

        lr = GetComponent<LineRenderer>();
        lr.useWorldSpace = false;
        lr.widthMultiplier = LineWidth;

        SetPositions();
        tim = Time.time;
        Frequency = Lifetime / LinePoints;
    }

#if UNITY_EDITOR
    void OnValidate()
    {
        SetUp();
    }
#endif
}
