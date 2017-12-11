using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
	public GameObject Defender;
	public static GameObject SelectedDefender;
	
	private Button[] _buttons;

	private void Start()
	{
		_buttons = FindObjectsOfType<Button>();
	}

	private void OnMouseDown()
	{
		SelectedDefender = Defender;
		
		foreach (Button obj in _buttons)
		{
				obj.GetComponent<SpriteRenderer>().color = Color.black;
		}
		
		this.GetComponent<SpriteRenderer>().color = Color.white;
	}
}
