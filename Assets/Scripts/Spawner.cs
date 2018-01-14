using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
	public GameObject[] Attackers;
    public float MaxSpawnDelay;
    public float MinSpawnDelay;

    private bool _waiting;
    private GameTimer _gameTimer;
    private float _attackersTotalWeight;

	
	// Use this for initialization
	void Start () {
		StartCoroutine(Wait(Random.Range(15f, 30f)));
        _gameTimer = FindObjectOfType<GameTimer>();
        MaxSpawnDelay = 20;
        MinSpawnDelay = 10;

        foreach (var attacker in Attackers)
        {
            _attackersTotalWeight += attacker.GetComponent<Attacker>().AttackerSpawnWeight;
        }
	}
	
	// Update is called once per frame
	void Update () {

        /*if (!_waiting)
        {
            foreach (GameObject thisAttacker in Attackers)
            {
                if (IsTimeToSpawn(thisAttacker))
                {
                    Spawn(thisAttacker);
                }
            }
        }*/


        if (_gameTimer.IsTimeForLastAttack)
        {
            MaxSpawnDelay = 10;
            MinSpawnDelay = 5;
        }
		
		if (!_waiting)
		{
            GameObject attackerPrefab = ChooseAttacker();
			float seconds = Random.Range(MinSpawnDelay, MaxSpawnDelay) ;
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
	
	/*private bool IsTimeToSpawn(GameObject attacker) {
		var myAttacker = attacker.GetComponent<Attacker>();
		float secondsPerSpawn = myAttacker.SeenEverySeconds / SpawnRate;
		float probabilityToSpawnInGivenSecond = (1 / secondsPerSpawn) / Lanes;
 
		if (Time.deltaTime > secondsPerSpawn) {
			Debug.LogWarning("Spawn rate capped by frame rate");
		}
 
		// probability increases the longer it takes this frame to show
		float probabilityToSpawnInGivenFrame = probabilityToSpawnInGivenSecond * Time.deltaTime;
 
		if (UnityEngine.Random.value < probabilityToSpawnInGivenFrame)
			return true;
		else
			return false;
	}*/

    private GameObject ChooseAttacker()
    {
        float prob = Random.Range(0f, 1f);
        Debug.Log("prob: " + prob);
        float totalProb = 0;

        foreach (GameObject attacker in Attackers)
        {
            Debug.Log(attacker.name);
            float attackerProb = attacker.GetComponent<Attacker>().AttackerSpawnWeight / _attackersTotalWeight;
            Debug.Log(attackerProb);
            totalProb += attackerProb;
            Debug.Log("total prob : " + totalProb);

            if (prob < totalProb)
            { 
                Debug.Log(attacker.name + "Spawn");
                 return attacker; 
            } 
        }

        return Attackers[0];
    }
}
