using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{

    public GameObject pointer;
    public float MinPos = -1.89f;
    public float MaxPos = 2.5f;
    public float CurPos;
    public float Sensitivity = 0.1f;


    void Start()
    {
        CurPos = MinPos;
        Camera.main.aspect = 16 / 10;
        Debug.Log(Camera.main.pixelRect);
    }

    void Update()
    {
        if (CurPos > MaxPos)
        {
            CurPos = MaxPos;
        }
        if (CurPos < MinPos)
        {
            CurPos = MinPos;
        }

        transform.position = new Vector3(transform.position.x, CurPos, 1);

        if (Input.GetKey(KeyCode.Space))
        {
            CurPos += Sensitivity;
        }
        else
        {
            CurPos -= Sensitivity;
        }
    }

}
