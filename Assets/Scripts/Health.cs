using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

	public float HealthPoints;

	public void Hitted(float hits)
	{
		HealthPoints -= hits;

		if (HealthPoints <= 0)
		{
			Die();
		}
	}

	private void Die()
	{
		Destroy(gameObject, 0.5f);
	}
}
