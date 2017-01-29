using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SHighScore : MonoBehaviour
{
    public static SHighScore SHInstance;

    public float score;

    public float highscore;

    public Text text;

    void Awake()
    {
        if (SHInstance != this)
            SHInstance = this;
    }

    void Start()
    {
        if (SHInstance != this)
            SHInstance = this;

        text = GetComponent<Text>();

        highscore = PlayerPrefs.GetFloat("highscore", highscore);
    }

    void Update()
    {
        text.text = "HighScore: " + highscore;

        if (score > highscore)
        {
            highscore = score;
            PlayerPrefs.SetFloat("highscore", highscore);
            PlayerPrefs.Save();
        }
    }

    public  void AddHScorepoints()
    {
        score++;
    }
}
