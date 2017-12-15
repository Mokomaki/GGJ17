using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowScoreOnGameOver : MonoBehaviour
{

    [SerializeField]
    private Score scr;

    [SerializeField]
    private TextMeshProUGUI text;

    void Awake()
    {
        text.text = "Score: " + scr.ScorePoints;
    }
}
