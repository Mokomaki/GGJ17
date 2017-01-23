using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Heart : MonoBehaviour
{
    public GameObject DisableME;
    public GameObject GameOver;

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
            gameObject.transform.position = new Vector3(10000,1000,1000);
            DisableME.gameObject.transform.position = new Vector3(10000, 1000, 1000);
            GameOver.SetActive(isActiveAndEnabled);
            if (Input.GetKey(KeyCode.Escape))
            {
                SceneManager.LoadScene(0);
            }

            if (Input.GetKey(KeyCode.Space))
            {
                SceneManager.LoadScene(1);
            }
        }
    }
}
