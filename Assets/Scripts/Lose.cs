using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lose : MonoBehaviour
{

	private LevelManager _levelManager;
	// Use this for initialization
	void Start ()
	{
		_levelManager = FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.GetComponent<Attacker>())
		{
			_levelManager.LoadScene("03a Lose");
		}
	}
}
