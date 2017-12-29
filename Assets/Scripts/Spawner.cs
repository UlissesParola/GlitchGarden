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
		int seed = Mathf.RoundToInt(this.transform.position.y * System.DateTime.Now.Millisecond);
		_random = new Random(seed);
		StartCoroutine(Wait(_random.Next(0, 20)));
	}
	
	// Update is called once per frame
	void Update () {

		/*foreach (GameObject thisAttacker in Attackers)
		{
			if (IsTimeToSpawn(thisAttacker))
			{
				Spawn(thisAttacker);
			}
		}*/
		
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
	
	private bool IsTimeToSpawn(GameObject attacker) {
		var myAttacker = attacker.GetComponent<Attacker>();
		float secondsPerSpawn = myAttacker.SeenEverySeconds;
		float probabilityToSpawnInGivenSecond = (1 / secondsPerSpawn) / 5;
 
		if (Time.deltaTime > secondsPerSpawn) {
			Debug.LogWarning("Spawn rate capped by frame rate");
		}
 
		// probability increases the longer it takes this frame to show
		float probabilityToSpawnInGivenFrame = probabilityToSpawnInGivenSecond * Time.deltaTime;
 
		if (UnityEngine.Random.value < probabilityToSpawnInGivenFrame)
			return true;
		else
			return false;
	}
}
