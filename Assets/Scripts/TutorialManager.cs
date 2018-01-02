using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{

	public GameObject[] Panels;
	public GameObject TutorialCanvas;
	public Toggle ShowTutorialToggle;
	
	private int _panelIndex;


	void Start()
	{
		if (PlayerPrefsManager.GetHideTutorial() == 1)
		{
			TutorialCanvas.SetActive(false);
		}
		else
		{
			_panelIndex = 0;
			Time.timeScale = 0;
		}
	}
	
	public void ForwardButton()
	{
		if (_panelIndex < Panels.Length -1)
		{
			Panels[_panelIndex].SetActive(false);
			_panelIndex++;
			Panels[_panelIndex].SetActive(true);
		}
	}

	public void BackButton()
	{
		if (_panelIndex > 0)
		{
			Panels[_panelIndex].SetActive(false);
			_panelIndex--;
			Panels[_panelIndex].SetActive(true);
		}
	}

	public void QuitTutorial()
	{
		Time.timeScale = 1;
		TutorialCanvas.SetActive(false);
	}

	public void HideTutorial(bool enable)
	{
		int hideTutorial = Convert.ToInt32(!enable);
		PlayerPrefsManager.SetHideTutorial(hideTutorial); 
	}
}
