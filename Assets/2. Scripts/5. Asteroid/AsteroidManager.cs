using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidManager : Singleton<AsteroidManager>
{

	[SerializeField] private AsteroidSpawningValues _asteroidSpawningValues;

	private AsteroidSpawner _asteroidSpawner;
	private static int _asteroidsDestroyed = 0;
	private int _lastBreakpoint = 0;
	private SpawningBreakpoint currentBreakpoint;
	private int breakpointIndex = 0;

	public static List<Asteroid> Asteroids = new List<Asteroid>();

	public AsteroidSpawningValues AsteroidSpawningValues
	{
		get
		{
			return _asteroidSpawningValues;
		}
	}

	public int AsteroidsDestroyed
	{
		get { return _asteroidsDestroyed; }
		set
		{
			_asteroidsDestroyed = value;
			CheckForBreakpoint(value);
		}
	}

	protected override void Awake()
	{
		base.Awake();

		if (_asteroidSpawningValues == null)
		{
			Debug.LogError("Asteroid Spawning Values have not been assigned in Asteroid Manager");
			UnityEditor.EditorApplication.isPlaying = false;
		}

		currentBreakpoint = _asteroidSpawningValues.SpawningBreakpoints[0];

		_asteroidSpawner = FindObjectOfType<AsteroidSpawner>();
	}

	public void CheckForBreakpoint(int destroyed)
	{
		if (breakpointIndex >= _asteroidSpawningValues.SpawningBreakpoints.Length - 1) return;



		if (destroyed - _lastBreakpoint >= currentBreakpoint.AmountToNext)
		{
			_lastBreakpoint += currentBreakpoint.AmountToNext;

			breakpointIndex++;

			_asteroidSpawner.SpawnTimeMultiplier = currentBreakpoint.SpawnValue;

			currentBreakpoint = _asteroidSpawningValues.SpawningBreakpoints[breakpointIndex];

		}
	}
}
