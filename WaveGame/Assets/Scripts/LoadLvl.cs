using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLvl : MonoBehaviour
{
    public int LvLNumber;
    public void LoadLVL()
    {
        SceneManager.LoadScene(LvLNumber);
    }
}
