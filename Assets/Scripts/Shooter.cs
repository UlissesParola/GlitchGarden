using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
	public GameObject Projectile; 
	public Transform Gun;
	
	private GameObject _projectileParent;

	private void Start()
	{
		_projectileParent = GameObject.Find("Projectiles");

		if (_projectileParent== null)
		{
			_projectileParent = new GameObject("Projectiles");
		}
	}

	private void FireGun()
	{
		GameObject newProjectile = Instantiate(Projectile, Gun);
		newProjectile.transform.SetParent(_projectileParent.transform);
	}
}
