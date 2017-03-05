using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSelect : MonoBehaviour
{
    public GameObject Infinite;
    public GameObject Level;

	void Start ()
    {
		
	}

	void Update ()
    {
		
	}

    public void ClickInfinite()
    {
        Infinite.SetActive(true);
        Level.SetActive(false);
    }

    public void ClickLevel()
    {
        Level.SetActive(true);
        Infinite.SetActive(false);
    }
}
