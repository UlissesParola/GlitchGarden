using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
	public GameObject Projectile; 
	public Transform Gun;
	
	private GameObject _projectileParent;
	private Animator _animator;
	private Spawner _myLaneSpawner;

	private void Start()
	{
		_animator = GetComponent<Animator>();
		_projectileParent = GameObject.Find("Projectiles");

		if (_projectileParent== null)
		{
			_projectileParent = new GameObject("Projectiles");
		}
		
		SetMyLaneSpawner();
	}

	private void Update()
	{
		if (IsAttackerAhead())
		{
			_animator.SetBool("IsAttacking", true);
		}
		else
		{
			_animator.SetBool("IsAttacking", false);
		}
	}

	private void FireGun()
	{
		GameObject newProjectile = Instantiate(Projectile, Gun);
		newProjectile.transform.SetParent(_projectileParent.transform);
	}

	private bool IsAttackerAhead()
	{	
		
		if (_myLaneSpawner.transform.childCount == 0)
		{
			return false;
		}

		foreach (Transform attacker in _myLaneSpawner.transform)
		{
			if (transform.position.x < attacker.position.x)
			{
				return true;
			}
		}

		return false;
	}

	private void SetMyLaneSpawner()
	{
		Spawner[] spawners = FindObjectsOfType<Spawner>();

		foreach (Spawner spawner in spawners)
		{
			if (spawner.transform.position.y == transform.position.y)
			{
				_myLaneSpawner = spawner;
				return;
			}
		}

		Debug.LogError("Spawner not founded");

	}
}
