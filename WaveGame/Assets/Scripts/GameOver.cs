using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class GameOver : MonoBehaviour
{

public void Exit()
{
        Advertisement.Show();
    SceneManager.LoadScene(0);
    Time.timeScale = 1;
}

public void Restart()
{
    SceneManager.LoadScene(1);
    Time.timeScale = 1;
}

}
