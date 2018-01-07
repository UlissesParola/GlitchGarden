using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Attacker))]
public class Lizard : MonoBehaviour {
	private Attacker _attacker;

	// Use this for initialization
	void Start ()
	{
		_attacker = GetComponent<Attacker>();
	}
	

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (!other.GetComponent<Defender>())
		{
			return;
		}
		else
		{
			_attacker.Attack(other.gameObject);
		}

	}
}
