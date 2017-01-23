using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static Score ScoreInstance;
    public Text Points;
    public float ScorePoints;

    void Awake()
    {
        if (ScoreInstance != this)
            ScoreInstance = this;
    }

    void Start()
    {
        if (ScoreInstance != this)
            ScoreInstance = this;

        Points = GetComponent<Text>();
    }
    void Update()
    {
        Points.text = "Score: " + ScorePoints;
    }

    public void AddToScore()
    {
        ScorePoints++;
        SHighScore.SHInstance.AddHScorepoints();
    }

}
