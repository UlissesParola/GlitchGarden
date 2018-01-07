using UnityEngine;

public class Projectile : MonoBehaviour
{
	public float Speed;
	public float Damage;
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.right * Speed * Time.deltaTime);
	}

	private void OnBecameInvisible()
	{
		Destroy(gameObject);
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.GetComponent<Attacker>() && other.GetComponent<Health>())
		{

			other.GetComponent<Health>().Hitted(Damage);
			Destroy(gameObject);

		}
	}
}
