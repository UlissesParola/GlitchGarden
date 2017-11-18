using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInBehaviour : MonoBehaviour
{

	public float FadeInTime;

	private Image _fadeInPanel;
	private Color _currentColor = Color.white;
	
	// Use this for initialization
	void Start ()
	{
		_fadeInPanel = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.timeSinceLevelLoad < FadeInTime)
		{
			_currentColor.a = 1 - (Time.timeSinceLevelLoad / FadeInTime);
			_fadeInPanel.color = _currentColor;

		}
		else
		{
			gameObject.SetActive(false);
		}
	}
}
