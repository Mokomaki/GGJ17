using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{

    public HeartSpriteHandlerOne Heart_1;
    public HeartSpriteHandlerTwo Heart_2;
    public HeartSpriteHandlerThree Heart_3;
    public int Heart_Count = 1;
    

    void Start()
    {

    }

    void Update()
    {
        if (Heart_Count > 3)
        {

        }
    }

    public void TakesDmG()
    {
        if (Heart_Count == 1)
        {
            Heart_1.TakesDmg();  
        }else
        if (Heart_Count == 2)
        {
            Heart_2.TakesDmg();
        }
        else
        if (Heart_Count == 3)
        {
            Heart_3.TakesDmg();
        }
    }
}
