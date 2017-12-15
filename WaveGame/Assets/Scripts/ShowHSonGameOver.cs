using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowHSonGameOver : MonoBehaviour
{

    [SerializeField]
    private SHighScore Hscr;

    [SerializeField]
    private TextMeshProUGUI text;

    void Awake()
    {
        text.text = "Highscore: " + Hscr.highscore;
    }
}
