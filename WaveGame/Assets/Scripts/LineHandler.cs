using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class LineHandler : MonoBehaviour
{
    public Transform FollowObject;

    const float LineWidth = 0.1f;
    public float LineLength = 7f;
    public int LinePoints = 50;
    float Ratio;
    public Vector3[] positions;
    //public Queue<Vector3> positions = new Queue<Vector3>(SIZE);

    public float speed = 0.01f;

    LineRenderer lr;
    int i = 0;

    float tim = 0;

    // Use this for initialization
    void Start()
    {
        if (!FollowObject)
            FollowObject = transform;
        Ratio = LineLength / LinePoints;
        positions = new Vector3[LinePoints];

        lr = GetComponent<LineRenderer>();
        lr.useWorldSpace = false;
        lr.widthMultiplier = LineWidth;

        SetPositions();
        tim = Time.time;

    }

    void MovePositions()
    {
        for (i = LinePoints-1; i > 0; i--)
        {
            positions[i] = new Vector3(i * Ratio,positions[i-1].y);
        }
        positions[0] = new Vector3(0, FollowObject.position.y);
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

    // Update is called once per frame
    void Update()
    {
        while (Time.time - tim > speed)
        {
            tim += speed;
            MovePositions();
        }
        transform.position = new Vector3((Time.time - tim)*Ratio/speed, 0, 0);
    }
}
