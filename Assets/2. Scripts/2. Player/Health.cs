using UnityEngine;
using TMPro;

public class Health : MonoBehaviour
{
	[SerializeField] private Ship _ship;
	[SerializeField] private TMP_Text _text;

	private int _health;



	private void Awake()
	{
		_health = _ship.MaxHealth;
		_text.text = $"{_health}/{_ship.MaxHealth}";
	}

	public void Hit()
	{
		_health--;
		_text.text = $"{_health}/{_ship.MaxHealth}";



		if (_health <= 0)
		{
			FindObjectOfType<GameOver>(true).gameObject.SetActive(true);
		}
	}
}
