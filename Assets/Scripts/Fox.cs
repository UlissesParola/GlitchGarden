using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Attacker))]
public class Fox : MonoBehaviour
{

	private Attacker _attacker;
	private Animator _animator;

	// Use this for initialization
	void Start ()
	{
		_attacker = GetComponent<Attacker>();
		_animator = GetComponent<Animator>();
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (!other.GetComponent<Defender>())
		{
			return;
		}
		
		if (other.GetComponent<Stone>())
		{
			_animator.SetTrigger("Jump Trigger");
		}
		else 
		{
			_attacker.Attack(other.gameObject);
		}
	}
}
