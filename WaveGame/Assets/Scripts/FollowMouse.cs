using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    Vector3 MousePos;

	void Update ()
    {
        if (Input.GetButton("MouseControl"))
        {
            MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(transform.position.x, MousePos.y, transform.position.z);
        }
    }
}
