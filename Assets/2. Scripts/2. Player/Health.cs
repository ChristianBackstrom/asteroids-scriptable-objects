using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
	[SerializeField] private Ship _ship;

	[SerializeField] private int _health;

	private bool _isAlive;

	private void Awake()
	{
		_health = _ship.MaxHealth;
	}


	private void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.CompareTag("Asteroid"))
		{
			_health--;
		}
	}
}
