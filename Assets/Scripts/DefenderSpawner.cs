using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{

	private GameObject _defenderParent;

	// Use this for initialization
	void Start () {
		_defenderParent = GameObject.Find("Defenders");
		if (_defenderParent == null)
		{
			_defenderParent = new GameObject("Defenders");
		}
	}

	private void OnMouseDown()
	{
		Vector2 instancePosition = SnapToGrid(CalculateWorldUnit());
		GameObject defender = Instantiate(Button.SelectedDefender, instancePosition, Quaternion.identity);
		defender.transform.SetParent(_defenderParent.transform);
	}

	private Vector2 CalculateWorldUnit()
	{
		Vector3 mousePosition = Input.mousePosition;
		mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
		return new Vector2(mousePosition.x, mousePosition.y);
	}

	private Vector2 SnapToGrid(Vector2 rawPosition)
	{
		int x = Mathf.RoundToInt(rawPosition.x);
		int y = Mathf.RoundToInt(rawPosition.y);
		
		return new Vector3(x, y);
	}
}
