using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
	public GameObject[] Attackers;
    public float MaxDelayFactor;
    public float MinDelayFactor;

    private bool _waiting;
    private GameTimer _gameTimer;

	
	// Use this for initialization
	void Start () {
		StartCoroutine(Wait(Random.Range(10f, 30f)));
        _gameTimer = FindObjectOfType<GameTimer>();
        MaxDelayFactor = 15;
        MinDelayFactor = 3;
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

        if (_gameTimer.IsTimeForLastAttack)
        {
            MaxDelayFactor = 0;
            MinDelayFactor = 3;
        }
		
		if (!_waiting)
		{
			int attackersIndex = Random.Range(0, Attackers.Length);
            Debug.Log("Attacker: " + attackersIndex);
			GameObject attackerPrefab = Attackers[attackersIndex];
			int time = attackerPrefab.GetComponent<Attacker>().SeenEverySeconds;
			float seconds = Random.Range(time/MinDelayFactor, time + MaxDelayFactor) ;
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
		float probabilityToSpawnInGivenSecond = (1 / secondsPerSpawn) / MaxDelayFactor;
 
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
