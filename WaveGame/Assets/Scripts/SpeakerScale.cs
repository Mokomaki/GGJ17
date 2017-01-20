using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeakerScale : MonoBehaviour
{
    float scale;

    void Update()
    {
        scale = 0.5f + Mathf.PingPong(1 * Time.time, .5f/*speed*/) * 0.25f/*scale pingpong*/;
        transform.localScale = new Vector3(scale, scale, 1);
        
    }
}
