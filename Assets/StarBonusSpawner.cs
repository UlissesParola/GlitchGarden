﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarBonusSpawner : MonoBehaviour {

    public GameObject StarBonusPrefab;
    public float StarBirthInterval;

    private float _timeToSpawn;
	// Use this for initialization
	void Start () {
        _timeToSpawn = Time.time + StarBirthInterval;
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.time >= _timeToSpawn)
        {
            SpawnStar();
            _timeToSpawn += StarBirthInterval;
        }
	}

    private void SpawnStar()
    {
        int posX = UnityEngine.Random.Range(1, 9);
        Debug.Log(posX);
        Instantiate(StarBonusPrefab, new Vector3(posX, 7, -5), Quaternion.identity);
    }
}
