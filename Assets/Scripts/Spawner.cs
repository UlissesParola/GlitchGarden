using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class Spawner : MonoBehaviour
{
	public GameObject[] Attackers;

	private GameObject _parent;
	private Random _random;
	private bool _waiting;
	
	// Use this for initialization
	void Start () {
		_parent = GameObject.Find("Attackers");
		
		if (_parent == null)
		{
			_parent = new GameObject("Attackers");
		}

		int seed = Mathf.RoundToInt(this.transform.position.y * Time.realtimeSinceStartup);
		_random = new Random(seed);
		StartCoroutine(Wait(_random.Next(0, 10)));
	}
	
	// Update is called once per frame
	void Update () {
		if (!_waiting)
		{
			int attackersIndex = _random.Next(0, Attackers.Length);
			GameObject attackerPrefab = Attackers[attackersIndex];
			int time = attackerPrefab.GetComponent<Attacker>().SeenEverySeconds;
			float seconds = _random.Next(time/2, time * 2) ;
			StartCoroutine(Wait(seconds));
			Spawn(attackerPrefab);
		}
	}

	public void Spawn(GameObject attackerPrefab)
	{
		Vector3 position = gameObject.transform.position;
		GameObject newAttacker = Instantiate(attackerPrefab, position, Quaternion.identity);
		newAttacker.transform.SetParent(_parent.transform);
	}

	private IEnumerator Wait(float seconds)
	{
		_waiting = true;
		yield return new WaitForSeconds(seconds);
		_waiting = false;
	}
}
