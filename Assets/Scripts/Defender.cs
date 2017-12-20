using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
	public int StarCost;
	private StarDisplay _starDisplay;
	// Use this for initialization
	void Start ()
	{
		_starDisplay = GameObject.FindObjectOfType<StarDisplay>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void AddStars(int amount)
	{
		_starDisplay.AddStars(amount);
	}

	public void UseStars(int amount)
	{
		
	}

}
