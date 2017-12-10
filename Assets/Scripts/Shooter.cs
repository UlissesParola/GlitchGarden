using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{

	public GameObject Projectile, ProjectileParent;
	public Transform Gun;
	
	private void FireGun()
	{
		GameObject newProjectile = Instantiate(Projectile, Gun);
		newProjectile.transform.SetParent(ProjectileParent.transform);
	}
}
