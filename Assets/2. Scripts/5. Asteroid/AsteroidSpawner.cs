using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class AsteroidSpawner : MonoBehaviour
{
	[SerializeField] private AsteroidSpawningValues _spawningValues;

	[SerializeField] private Asteroid _asteroidPrefab;

	private float timer = 0;
	private Vector2 LastPosition = Vector2.zero;

	private void Update()
	{
		timer += Time.deltaTime;
		if (timer < _spawningValues.TimeBetweenSpawn) return;

		timer = 0;

		SpawnAsteroid();
	}

	private void SpawnAsteroid()
	{
		if (_asteroidPrefab == null)
		{
			print("Asteroid Prefab not assigned");
			return;
		}


		Vector2 spawnPosition = LastPosition;
		float distance = Random.Range(_spawningValues.MinSpawningDistance, _spawningValues.MaxSpawningDistance);

		while (Vector2.Distance(LastPosition, spawnPosition) < _spawningValues.MaxSpawnSize)
		{
			distance = Random.Range(_spawningValues.MinSpawningDistance, _spawningValues.MaxSpawningDistance);

			spawnPosition = Random.insideUnitCircle.normalized * distance;
		}

		LastPosition = spawnPosition;


		float speed = Random.Range(_spawningValues.MinFlightSpeed, _spawningValues.MaxFlightSpeed) * distance / _spawningValues.MinSpawningDistance;
		float scale = Random.Range(_spawningValues.MinSpawnSize, _spawningValues.MaxSpawnSize);


		Asteroid asteroid = Instantiate(_asteroidPrefab, spawnPosition, Quaternion.identity);
		asteroid.transform.localScale = Vector3.one * scale;

		int asteroidCorners = UnityEngine.Random.Range(_spawningValues.MinAsteroidCornerAmount, _spawningValues.MaxAsteroidCornerAmount);

		asteroid.GenerateAsteroid(speed, asteroidCorners, _spawningValues.AsteroidCornerRandomness);

		asteroid.AddForce(speed);
	}


	private void OnDrawGizmos()
	{
		if (_spawningValues == null) return;

		Gizmos.color = Color.green;
		Gizmos.DrawWireSphere(Vector3.zero, _spawningValues.MaxSpawningDistance);
		Gizmos.DrawWireSphere(Vector3.zero, _spawningValues.MinSpawningDistance);
	}
}
