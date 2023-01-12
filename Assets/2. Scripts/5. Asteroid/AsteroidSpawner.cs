using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
	[SerializeField] private AsteroidSpawningValues _spawningValues;

	[SerializeField] private Asteroid _asteroidPrefab;

	private float timer = 0;
	private Vector2 spawnPosition = Vector2.zero;

	private void Update()
	{
		timer += Time.deltaTime;
		if (timer < _spawningValues.SpawnRate) return;
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


		spawnPosition = Random.insideUnitCircle.normalized * _spawningValues.SpawningDistance;

		float speed = Random.Range(_spawningValues.MinFlightSpeed, _spawningValues.MaxFlightSpeed);
		float scale = Random.Range(_spawningValues.MinSpawnSize, _spawningValues.MaxSpawnSize);

		Asteroid asteroid = Instantiate(_asteroidPrefab, spawnPosition, Quaternion.identity);
		asteroid.transform.localScale = Vector3.one * scale;

		asteroid.GenerateAsteroid(speed, _spawningValues.GenerationSteps, _spawningValues.GenerationRandomness);

		asteroid.AddForce(speed);
	}


	private void OnDrawGizmos()
	{
		if (_spawningValues == null) return;

		Gizmos.color = Color.green;
		Gizmos.DrawWireSphere(Vector3.zero, _spawningValues.SpawningDistance);


		Gizmos.color = Color.blue;

		Gizmos.DrawSphere(spawnPosition, .5f);
	}
}
