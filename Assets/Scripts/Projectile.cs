using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Projectile : MonoBehaviour
{
	public float Speed;
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.right * Speed * Time.deltaTime);
	}

	private void OnBecameInvisible()
	{
		Destroy(gameObject);
	}
}
