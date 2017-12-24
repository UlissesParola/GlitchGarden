using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
	public float LevelDuration;

	private LevelManager _levelManager;
	private float _endTime;
	
	// Use this for initialization
	void Start ()
	{
		_endTime = Time.time + LevelDuration;
		_levelManager = FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		GetComponent<Slider>().value = Time.time / _endTime;
		
		if (Time.time > _endTime)
		{
			Debug.Log("Level ended");
			LevelEnd();
		}
	}

	void LevelEnd()
	{
		Invoke("AutoLoadNextLevel", 3);
	}

	void AutoLoadNextLevel()
	{
		_levelManager.LoadNextScene();
	}
}
