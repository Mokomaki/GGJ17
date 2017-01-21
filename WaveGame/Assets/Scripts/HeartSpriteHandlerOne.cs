using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartSpriteHandlerOne : MonoBehaviour
{
    public Heart Heart;
    private SpriteRenderer spriteR;
    public Sprite Full_Heart;
    public Sprite Half_Heart;
    public Sprite Empty_Heart;
    int spriteMode = 0;

    void Start()
    {
        spriteR = gameObject.GetComponent<SpriteRenderer>();
        spriteR.sprite = Full_Heart;
    }

  
    void Update()
    {
        if (spriteMode == 0)
        {
            spriteR.sprite = Full_Heart;
        } else
        if (spriteMode == 1)
        {
            spriteR.sprite = Half_Heart;
        }else
        if (spriteMode == 2)
        {
            spriteR.sprite = Empty_Heart;
        }
    }

    public void TakesDmg()
    {
        if (spriteMode < 2)
        {
            spriteMode++;
        }
        if (spriteMode == 2)
        {
            Heart.Heart_Count++;
        }
    }
}
