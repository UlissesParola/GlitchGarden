using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
    public Slider VolumeSlider;
    public Text DifficultyText;

    private int _difficultyIndex = 1;
    private AudioManager _audioManager;
    private float _currentVolume;
    private readonly string[] _difficultyLabels = {"Easy", "Normal", "Hard"};
    
    private void Start()
    {
        _audioManager = FindObjectOfType<AudioManager>();
        LoadOptions();
    }

    private void Update()
    {
        ChangeVolume(VolumeSlider.value);
    }

    public void ChangeVolume(float volume)
    {
        if (_audioManager != null)
        {
            _audioManager.GetComponent<AudioSource>().volume = volume;
            _currentVolume = volume;
        }
        else
        {
            Debug.LogError("AudioManager is missing.");
        }
    }

    public void DifficultyPlusChange()
    {
        if (_difficultyIndex < 2)
        {
            _difficultyIndex++;
            DifficultyText.text = _difficultyLabels[_difficultyIndex];
        }
    }
    
    public void DifficultyMinusChange()
    {
        if (_difficultyIndex > 0)
        {
            _difficultyIndex--;
            DifficultyText.text = _difficultyLabels[_difficultyIndex];
        }
    }

    private void ChangeDifficulty(int difficulty)
    {
        _difficultyIndex = difficulty;
        DifficultyText.text = _difficultyLabels[_difficultyIndex];
    }

    public void SaveOptions()
    {
        PlayerPrefsManager.SetMasterVolume(_currentVolume);
        PlayerPrefsManager.SetDifficulty(_difficultyIndex);
    }

    private void LoadOptions()
    {
        ChangeVolume(PlayerPrefsManager.GetMasterVolume());
        VolumeSlider.value = _currentVolume;
        ChangeDifficulty(PlayerPrefsManager.GetDifficulty());  
    }
    
}
