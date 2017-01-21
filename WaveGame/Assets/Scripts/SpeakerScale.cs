﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeakerScale : MonoBehaviour
{
    Vector3 StartScale;
    float scale;

    void Start()
    {
        StartScale = transform.localScale;
    }

    void Update()
    {
        scale = 1 + Mathf.PingPong(1 * Time.time, .5f/*speed*/) * 0.5f/*scale pingpong*/;
        transform.localScale = StartScale*scale;
    }
}
