using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    //public static GameOver GoInctance;

    //void Update()
    //{
        //if (GoInctance != this)
        //    GoInctance = this;

        //Time.timeScale = 0;


           //SceneManager.LoadScene(0);
            //Time.timeScale = 1;


            //SceneManager.LoadScene(1);
          //  Time.timeScale = 1;

    //}

//void Start()
//{
//if (GoInctance != this)
//    GoInctance = this;
//}

public void Exit()
{
    SceneManager.LoadScene(0);
    Time.timeScale = 1;
}

public void Restart()
{
    SceneManager.LoadScene(1);
    Time.timeScale = 1;
}

}
