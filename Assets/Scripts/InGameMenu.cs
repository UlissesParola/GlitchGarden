using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameMenu : MonoBehaviour
{
	public GameObject InGameMenuCanvas;
	public LevelManager LevelManager;

	private void OnMouseDown()
	{
		Time.timeScale = 0;
		InGameMenuCanvas.SetActive(true);
	}

	public void BackToTheGame()
	{
		Time.timeScale = 1;
		InGameMenuCanvas.SetActive(false);
	}

	public void BackToStartMenu()
	{
		Time.timeScale = 1;
		LevelManager.LoadScene("01a StartMenu");
	}

}
