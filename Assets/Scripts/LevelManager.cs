using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {


	public void LoadScene(string scene)
	{
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
}
