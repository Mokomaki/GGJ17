using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class LineHandler : MonoBehaviour
{
    const int SIZE = 10;
    const float RATIO = 5f / SIZE;
    public Vector3[] positions = new Vector3[SIZE];
    //public Queue<Vector3> positions = new Queue<Vector3>(SIZE);

    public float speed = 0.01f;

    LineRenderer lr;
    int i = 0;

    float tim = 0;

    // Use this for initialization
    void Start()
    {
        lr = GetComponent<LineRenderer>();

        SetPositions();
        tim = Time.time;
    }

    void MovePositions()
    {
        for (i = SIZE-1; i > 0; i--)
        {
            positions[i] = new Vector3(i * RATIO,positions[i-1].y);
        }
        positions[0] = new Vector3(0, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        lr.SetPositions(positions);
    }

    void SetPositions()
    {
        positions = new Vector3[SIZE];
        for (i = 0; i < SIZE; i++)
        {
            positions[i] = new Vector3(i * RATIO, 0);
        }

        lr.numPositions = SIZE;
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
        transform.position = new Vector3((Time.time - tim), 0, 0);
    }
}
