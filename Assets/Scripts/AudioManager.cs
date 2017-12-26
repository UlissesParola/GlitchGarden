using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
	public AudioClip[] AudioClips;
	private AudioSource _source;
	public int ActualClipIndex;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(this);
		_source = GetComponent<AudioSource>();
		ChangeVolume(PlayerPrefsManager.GetMasterVolume());
	}

	public void PlayAudioClip(int clipIndex)
	{
		if (AudioClips[clipIndex] != null)
		{
			ActualClipIndex = clipIndex;
			_source.clip = AudioClips[clipIndex];
			_source.Play();
		}
		else
		{
			Debug.Log("Array index is null.");
		}
	}

	public void ChangeVolume(float newVolume)
	{
		_source.volume = newVolume;
	}

	public void PlayClip(AudioClip clip)
	{
		_source.Stop();
		_source.PlayOneShot(clip);
	}
}
