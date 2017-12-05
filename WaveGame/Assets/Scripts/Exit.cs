using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

public class Exit : MonoBehaviour 
{
	public GameObject Pause;
	public void TryToExit ()
	{
        Advertisement.Show();
		Time.timeScale = 0;
		Pause.SetActive (true);
	}

	public void YesIReallyWantToExit()
	{
		SceneManager.LoadScene(0);
		Pause.SetActive (false);
		Time.timeScale = 1;
	}

	public void NoIReallyDontWantToExit()
	{
		Pause.SetActive (false);
		Time.timeScale = 1;
	}

}