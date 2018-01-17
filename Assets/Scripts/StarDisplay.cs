using UnityEngine;
using UnityEngine.UI;

public class StarDisplay : MonoBehaviour
{
	public int Stars = 100;

	public enum Status
	{
		Success,
		Failure
	};
	
	private Text _starsText;
	
	// Use this for initialization
	void Start ()
	{
        int difficulty = PlayerPrefsManager.GetDifficulty();

        switch (difficulty)
        {
            case 0:
                Stars += 20;
                break;
            case 2:
                Stars -= 20;
                break;
            default:
                Stars = 100;
                break;
        }

        _starsText = GetComponent<Text>();
        _starsText.text = Stars.ToString();
	}

	public void AddStars(int amount)
	{
		Stars += amount;
		_starsText.text = Stars.ToString();
	}

	public Status UseStars(int amount)
	{
		if (Stars >= amount)
		{
			Stars -= amount;
			_starsText.text = Stars.ToString();
			return Status.Success;
		}
		return Status.Failure;
	}
}
