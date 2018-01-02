using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefenderButton : MonoBehaviour
{
	public GameObject Defender;
	public static GameObject SelectedDefender;

	private Text _cost;
	private DefenderButton[] _defenderButtons;

	private void Start()
	{
		_defenderButtons = FindObjectsOfType<DefenderButton>();
		_cost = transform.GetComponentInChildren<Text>();
		_cost.text = Defender.GetComponent<Defender>().StarCost.ToString();
	}

	private void OnMouseDown()
	{
		SelectedDefender = Defender;
		
		foreach (DefenderButton obj in _defenderButtons)
		{
				obj.GetComponentInChildren<SpriteRenderer>().color = Color.black;
		}
		
		this.GetComponentInChildren<SpriteRenderer>().color = Color.white;
	}
}
