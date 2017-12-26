using System.Collections;
using System.Collections.Generic;
using NUnit.Framework.Constraints;
using UnityEngine;
using UnityEngine.UI;

public class StarDisplay : MonoBehaviour
{
	public int Stars = 100;

	public enum Status
	{
		Success,
		Failure
	};
	
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

	public Status UseStars(int amount)
	{
		if (Stars >= amount)
		{
			Stars -= amount;
			_starsText.text = Stars.ToString();
			return Status.Success;
		}
		return Status.Failure;
	}
}
