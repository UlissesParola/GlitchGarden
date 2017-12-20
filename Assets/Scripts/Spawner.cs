using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class Spawner : MonoBehaviour
{
	public GameObject[] Attackers;

	private Random _random;
	private bool _waiting;
	
	// Use this for initialization
	void Start () {
		int seed = Mathf.RoundToInt(this.transform.position.y * Time.realtimeSinceStartup);
		_random = new Random(seed);
		StartCoroutine(Wait(_random.Next(0, 50)));
	}
	
	// Update is called once per frame
	void Update () {
		if (!_waiting)
		{
			int attackersIndex = _random.Next(0, Attackers.Length);
			GameObject attackerPrefab = Attackers[attackersIndex];
			int time = attackerPrefab.GetComponent<Attacker>().SeenEverySeconds;
			float seconds = _random.Next(time/20, time * 20) ;
			StartCoroutine(Wait(seconds));
			Spawn(attackerPrefab);
		}
	}

	public void Spawn(GameObject attackerPrefab)
	{
		Vector3 position = gameObject.transform.position;
		GameObject newAttacker = Instantiate(attackerPrefab, position, Quaternion.identity);
		newAttacker.transform.SetParent(this.transform);
	}

	private IEnumerator Wait(float seconds)
	{
		_waiting = true;
		yield return new WaitForSeconds(seconds);
		_waiting = false;
	}
}
