using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Attacker))]
public class Lizard : MonoBehaviour {
	
	private Attacker _attacker;
	private Animator _animator;

	// Use this for initialization
	void Start ()
	{
		_attacker = GetComponent<Attacker>();
		_animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (!other.GetComponent<Defender>())
		{
			return;
		}
		else
		{
			_animator.SetBool("IsAttacking", true);
			_attacker.Attack(other.gameObject);
		}

	}
}
