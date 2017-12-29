using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameMenu : MonoBehaviour
{
	public GameObject InGameMenuCanvas;

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

}
