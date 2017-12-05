using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    Vector3 MousePos;

    public GameObject pointer;
    public float MinPos = -1.9f;
    public float MaxPos = 2.5f;
    public float CurPos;
    public float TargetPos;
    public float Sensitivity = 0.1f;

    public bool MouseControlEnabled = true;


    void Start()
    {
        CurPos = TargetPos = -1.9f;
        Camera.main.aspect = 16 / 10;
     //   Debug.Log(Camera.main.pixelRect);
    }

    void Update()
	{
		/*
        if (Input.GetKey(KeyCode.Space))
        {
            TargetPos += Sensitivity;
        }
        else
        {
            TargetPos -= Sensitivity;
        }
        TargetPos = Mathf.Clamp(TargetPos, MinPos, MaxPos);
    }
    */
		if (Input.touchCount > 0 || Input.GetKey(KeyCode.Space)) 
		{
			TargetPos += Sensitivity;
		} else {
			TargetPos -= Sensitivity;
		}
		TargetPos = Mathf.Clamp (TargetPos, MinPos, MaxPos);
	}

    void LateUpdate()
    {
        TargetPos = Mathf.Clamp(TargetPos, MinPos, MaxPos);
    }

    void FixedUpdate()
    {
        CurPos = CurPos + (TargetPos - CurPos) * 0.3f;
        transform.position = new Vector3(transform.position.x, CurPos, transform.position.z);
    }

}
