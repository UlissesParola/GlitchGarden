using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneAudioManager : MonoBehaviour
{
	public bool loop = true;
	
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
		if (_sceneIndex == 1)
		{
			if ((_audioSource.clip == null || _audioManager.ActualClipIndex != 1))
			{
				_audioManager.PlayAudioClip(1);
			}
		}
		else
		{
			_audioManager.PlayAudioClip(_sceneIndex);
			_audioSource.loop = loop;
		}
	}

	public void PlayClip(AudioClip clip)
	{
		_audioManager.PlayClip(clip);
	}
}
