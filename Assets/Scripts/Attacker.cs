using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{

	[Range(-1, 2f)] 
	public float WalkingSpeed;

	private GameObject _currentTarget;
	private Animator _anim;

	public void SetSpeed(float speed)
	{
		WalkingSpeed = speed;
	}

	// Use this for initialization
	void Start ()
	{
		_anim = GetComponent<Animator>();
		//alternative form to add a Rigidbody2D component
		//Rigidbody2D myRigidBody = gameObject.AddComponent<Rigidbody2D>();

		//turn it kinematic
		//myRigidBody.isKinematic = true;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.left * WalkingSpeed * Time.deltaTime);

		if (_currentTarget == null)
		{
			_anim.SetBool("IsAttacking", false);
		}
	}

	public void StrikeCurrentTarget(float damage)
	{
		if (_currentTarget)
		{
			_currentTarget.GetComponent<Health>().Hitted(damage);
		}

	}

	public void Attack(GameObject target)
	{
		_currentTarget = target;
		_anim.SetBool("IsAttacking", true);
	}
}
