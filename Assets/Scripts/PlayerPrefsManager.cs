using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsManager : MonoBehaviour
{
	private const string MasterVolumeKey = "MasterVolume";
	private const string DifficultyKey = "Difficulty";

	public static void SetMasterVolume(float volume)
	{
		if (volume > 0f && volume <= 1f)
		{
			PlayerPrefs.SetFloat(MasterVolumeKey, volume);
		}
		else
		{
			Debug.LogError("Volume out of range.");
		}
	}
	
	public static float GetMasterVolume()
	{
		return PlayerPrefs.GetFloat(MasterVolumeKey);
	}

	public static void SetDifficulty(int difficulty)
	{
		if (difficulty >= 0 && difficulty <= 2)
		{
			PlayerPrefs.SetInt(DifficultyKey, difficulty);
		}
		else
		{
			Debug.LogError("Difficult out of range.");
		}
	}

	public static int GetDifficulty()
	{
		return PlayerPrefs.GetInt(DifficultyKey);
	}
}
