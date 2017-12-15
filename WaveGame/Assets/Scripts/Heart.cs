using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Heart : MonoBehaviour
{

    public AudioSource audio;
    public GameObject Game;
    public GameObject Exit;
    public GameObject GameOver;

    public static Heart Instance;

    public HeartSpriteHandler Heart_1;
    public HeartSpriteHandler Heart_2;
    public HeartSpriteHandler Heart_3;
    public int Heart_Count = 1;

    public GameObject[] ObjsToDisable; 
    
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
            Time.timeScale = 0;
            Exit.SetActive(false);
            foreach(GameObject obj in ObjsToDisable)
            {
                obj.gameObject.SetActive(false);
            }
            for(AudioSource AudioVolume; audio.volume > 0; audio.volume--)
            GameOver.SetActive(true);
        }
    }
}
