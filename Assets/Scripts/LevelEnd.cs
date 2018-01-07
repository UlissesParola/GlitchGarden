using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEnd : MonoBehaviour {
    public AudioClip LevelEndSound;

    private SceneAudioManager _audioManager;

    // Use this for initialization
    void Start () {
        GameObject.FindWithTag("Level Canvas").SetActive(false);
        _audioManager = GameObject.FindObjectOfType<SceneAudioManager>();
        EndLevel();
    }

    void DestroyObjectsInScene()
    {
        string[] tagsToDestroy = { "Attacker", "Defender", "Projectile" };

        foreach (string tagToDestroy in tagsToDestroy)
        {
            GameObject[] objs = GameObject.FindGameObjectsWithTag(tagToDestroy);
            foreach (GameObject obj in objs)
            {
                Destroy(obj);
            }
        }
    }

    void EndLevel()
    {
        Time.timeScale = 0;
        _audioManager.PlayClip(LevelEndSound);
        DestroyObjectsInScene();
    }
}
