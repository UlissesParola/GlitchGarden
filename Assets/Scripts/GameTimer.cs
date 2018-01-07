using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
	public float LevelDuration;
    public float LastAttackDuration;
    public bool IsTimeForLastAttack;
	public GameObject LevelEndCanvas;

	private bool _levelEnded;
	private LevelManager _levelManager;
    private float _lastAttackTime;
	
	// Use this for initialization
	void Start ()
	{
		_levelManager = FindObjectOfType<LevelManager>();
        _lastAttackTime = LevelDuration - LastAttackDuration;
	}
	
	// Update is called once per frame
	void Update ()
	{
		GetComponent<Slider>().value = Time.timeSinceLevelLoad / LevelDuration;
		
		if (Time.timeSinceLevelLoad > LevelDuration && !_levelEnded)
		{
			LevelEnd();
		}

        if (Time.timeSinceLevelLoad > _lastAttackTime && IsTimeForLastAttack == false)
        {
            IsTimeForLastAttack = true;
            Debug.Log("Time for a massive attack!");
        }
	}

	void LevelEnd()
	{
        LevelEndCanvas.SetActive(true);
		_levelEnded = true;

	}

	public void LoadNextlevel()
	{
		Time.timeScale = 1;
		_levelManager.LoadNextScene();
	}
}
