using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarBonus : MonoBehaviour {

    private StarDisplay _starDisplay;
    private Animator _animator;
    private AudioSource _audioSource;
    private Rigidbody2D _rigidBody2D;

	// Use this for initialization
	void Start () {
        _starDisplay = GameObject.FindObjectOfType<StarDisplay>();
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
        _rigidBody2D = GetComponent<Rigidbody2D>();

        _rigidBody2D.velocity = Vector3.down; 
	}

    private void Update()
    {
        Debug.Log(_rigidBody2D.velocity);
    }

    private void OnMouseDown()
    {
        _animator.SetTrigger("Pop");
    }

    public void Pop()
    {
        _audioSource.Play();
        _rigidBody2D.velocity = Vector3.zero;
    }

    public void DestroyStar()
    {
        _starDisplay.AddStars(10);
        Debug.Log("Star die");
        Destroy(gameObject);
    }
}
