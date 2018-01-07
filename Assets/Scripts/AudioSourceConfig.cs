using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSourceConfig : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<AudioSource>().volume = PlayerPrefsManager.GetMasterVolume();
	}
}
