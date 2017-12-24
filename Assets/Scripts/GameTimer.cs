using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
	public float LevelDuration;
	public GameObject LevelEndPanel;
	public AudioClip LevelEndSound;
	
	private SceneAudioManager _audioManager;
	private bool _levelEnded;
	private LevelManager _levelManager;
	
	// Use this for initialization
	void Start ()
	{
		_levelManager = FindObjectOfType<LevelManager>();
		_audioManager = GameObject.FindObjectOfType<SceneAudioManager>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		GetComponent<Slider>().value = Time.timeSinceLevelLoad / LevelDuration;
		
		if (Time.timeSinceLevelLoad > LevelDuration && !_levelEnded)
		{
			Debug.Log("Level ended");
			LevelEnd();
			_levelEnded = true;
		}
	}

	void LevelEnd()
	{
		LevelEndPanel.SetActive(true);
		Invoke("AutoLoadNextLevel", LevelEndSound.length);
		_audioManager.PlayClip(LevelEndSound);
	}

	void AutoLoadNextLevel()
	{
		_levelManager.LoadNextScene();
	}
}
