using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public static GameOver GoInctance;

    void Awake()
    {
        if (GoInctance != this)
            GoInctance = this;

        Time.timeScale = 0;

        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
            Time.timeScale = 1;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            SceneManager.LoadScene(1);
            Time.timeScale = 1;
        }
    }

    void Start()
    {
        if (GoInctance != this)
            GoInctance = this;
    }
}