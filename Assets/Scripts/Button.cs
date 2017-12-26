using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button : MonoBehaviour
{
	public GameObject Defender;
	public static GameObject SelectedDefender;

	private Text _cost;
	private Button[] _buttons;

	private void Start()
	{
		_buttons = FindObjectsOfType<Button>();
		_cost = transform.GetComponentInChildren<Text>();
		_cost.text = Defender.GetComponent<Defender>().StarCost.ToString();
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
