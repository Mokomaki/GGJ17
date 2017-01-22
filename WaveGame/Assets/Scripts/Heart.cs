using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Heart : MonoBehaviour
{
    public static Heart Instance;

    public HeartSpriteHandlerOne Heart_1;
    public HeartSpriteHandlerOne Heart_2;
    public HeartSpriteHandlerOne Heart_3;
    public int Heart_Count = 1;
    
    void Awake()
    {
        if (Instance != this)
            Instance = this;
    }

    void Start()
    {
        if (Instance != this)
            Instance = this;
    }

    void Update()
    {

    }

    public void TakesDmG()
    {
        if (Heart_Count == 1)
        {
            Heart_1.TakesDmg();
        }
        else if (Heart_Count == 2)
        {
            Heart_2.TakesDmg();
        }
        else if (Heart_Count == 3)
        {
            Heart_3.TakesDmg();
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
