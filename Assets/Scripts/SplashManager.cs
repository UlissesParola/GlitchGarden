using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashManager : MonoBehaviour
{
	private float _sceneChangeTime;
	public LevelManager LevelManager;
	
	// Use this for initialization
	void Start ()
	{
		_sceneChangeTime = Time.time + 2.5f;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time >= _sceneChangeTime)
		{
			LevelManager.LoadScene("StartMenu");
			
		}
	}
}
