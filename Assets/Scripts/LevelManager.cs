using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

	public bool AutoLoadNextLevel;
	public float AutoLoadTimer;

	private static string _lastScene;

	private void Start()
	{
		if (AutoLoadNextLevel)
		{
			Invoke("LoadNextScene", AutoLoadTimer);
		}
	}

	public void LoadScene(string scene)
	{
		_lastScene = SceneManager.GetActiveScene().name;
		Debug.Log(_lastScene);
		SceneManager.LoadScene(scene);
	}

	public void LoadNextScene()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}
	
	public void Quit()
	{
		Application.Quit();
		Debug.Log("Quit");
	}

	public void SceneTransition(string scene, float delay)
	{
		Invoke("this.LoadScene(" + scene + ")", delay);
	}

	public void Restart()
	{
        Time.timeScale = 1;
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	public void RestartLastScene()
	{
        Time.timeScale = 1;
        SceneManager.LoadScene(_lastScene);
	}
}
