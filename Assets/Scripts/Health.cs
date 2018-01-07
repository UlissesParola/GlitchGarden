using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public AudioClip HittedSound;
    public AudioClip DeathSound;
    public float HealthPoints;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void Hitted(float hits)
	{
		HealthPoints -= hits;

        if (HealthPoints <= 0)
        {
            audioSource.PlayOneShot(DeathSound);
            Die();
        }
        else
        {
            audioSource.PlayOneShot(HittedSound);
        }

	}

	private void Die()
	{
		Destroy(gameObject, 0.5f);
	}
}
