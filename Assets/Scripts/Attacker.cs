using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{

	[Range(-1, 2f)] 
	public float WalkingSpeed;

	private GameObject _currentTarget;

	public void SetSpeed(float speed)
	{
		WalkingSpeed = speed;
	}

	// Use this for initialization
	void Start ()
	{
		//alternative form to add a Rigidbody2D component
		//Rigidbody2D myRigidBody = gameObject.AddComponent<Rigidbody2D>();
		
		//turn it kinematic
		//myRigidBody.isKinematic = true;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.left * WalkingSpeed * Time.deltaTime);
	}

	public void StrikeCurrentTarget(float damage)
	{
		_currentTarget.GetComponent<Health>().Hitted(damage);
	}

	public void Attack(GameObject target)
	{
		_currentTarget = target;
	}
}
