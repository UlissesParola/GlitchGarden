using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
	public float LevelDuration;
	public GameObject LevelEndCanvas;
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
			LevelEnd();
		}
	}

	void DestroyObjectsInScene()
	{
		string[] tagsToDestroy = {"Attacker", "Defender", "Projectile"};

		foreach (string tagToDestroy in tagsToDestroy)
		{
			GameObject[] objs =  GameObject.FindGameObjectsWithTag(tagToDestroy);
			foreach (GameObject obj in objs)
			{
				Destroy(obj);
			}
		}

	}

	void LevelEnd()
	{
		DestroyObjectsInScene();
		LevelEndCanvas.SetActive(true);
		_audioManager.PlayClip(LevelEndSound);
		_levelEnded = true;
		Time.timeScale = 0;
	}

	public void LoadNextlevel()
	{
		Time.timeScale = 1;
		_levelManager.LoadNextScene();
	}
}
