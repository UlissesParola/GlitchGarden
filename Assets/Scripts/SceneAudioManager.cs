using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneAudioManager : MonoBehaviour {
	
	private AudioManager _audioManager;
	private AudioSource _audioSource;
	private int _sceneIndex;
	
	// Use this for initialization
	void Start ()
	{
		_audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
		_audioSource = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioSource>();
		_sceneIndex = SceneManager.GetActiveScene().buildIndex;
		ChoosingAudioClip();
	}

	private void ChoosingAudioClip()
	{
		Debug.Log(_audioManager.ActualClipIndex);
		Debug.Log(_audioSource.clip == null);
		
		if (_sceneIndex == 1)
		{
			if ((_audioSource.clip == null || _audioManager.ActualClipIndex != 0))
			{
				_audioManager.PlayAudioClip(0);
				Debug.Log("Start");
			}
		}
		else
		{
			_audioManager.PlayAudioClip(_sceneIndex - 1);
			Debug.Log("Else");
		}
	}
}
