using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarDisplay : MonoBehaviour
{
	public int Stars;
	
	private Text _starsText;
	
	// Use this for initialization
	void Start ()
	{
		_starsText = GetComponent<Text>();
	}

	public void AddStars(int amount)
	{
		Stars += amount;
		_starsText.text = Stars.ToString();
	}

	public void UseStars(int amount)
	{
		Stars -= amount;
		_starsText.text = Stars.ToString();
	}
}
