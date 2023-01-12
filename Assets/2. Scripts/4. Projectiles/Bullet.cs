using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	[SerializeField] private Ship _ship;

	private const string AsteroidTag = "Asteroid";

	private void Update()
	{
		this.transform.position = Vector2.Lerp(this.transform.position, this.transform.position + this.transform.up, Time.deltaTime * _ship.BulletSpeed);
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag(AsteroidTag))
		{
			Destroy(other.gameObject);
			Destroy(this.gameObject);
		}
	}

	private void OnBecameInvisible()
	{
		Destroy(this.gameObject);
	}
}
