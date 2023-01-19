using UnityEngine;
using UnityEditor;

public class ControlPanel : EditorWindow
{

	private SerializedObject shipData;
	private SerializedObject asteroidData;

	// Asteroid
	private SerializedProperty OriginalTimeBetweenSpawn;

	private SerializedProperty SpawningBreakpoints;

	private SerializedProperty AsteroidCornerRandomness;


	private SerializedProperty AsteroidFlightTarget;

	private SerializedProperty MinSpawnDistance;
	private SerializedProperty MaxSpawnDistance;

	private SerializedProperty MinSpawnSize;
	private SerializedProperty MaxSpawnSize;

	private SerializedProperty MinFlightSpeed;
	private SerializedProperty MaxFlightSpeed;


	// shipData

	private SerializedProperty MaxHealth;

	private SerializedProperty RotationSpeed;

	private SerializedProperty ThrustSpeed;

	private SerializedProperty ShootCooldown;

	private SerializedProperty BulletSpeed;

	private SerializedProperty FirePoint;



	[MenuItem("Tools/ControlPanel")]
	private static void ShowWindow()
	{
		var window = GetWindow<ControlPanel>();
		window.titleContent = new GUIContent("ControlPanel");
		window.Show();
	}

	private void OnEnable()
	{
		asteroidData = new SerializedObject((AsteroidSpawningValues)Resources.Load("AsteroidData"));
		shipData = new SerializedObject((Ship)Resources.Load("ShipData"));


		// asteroid
		OriginalTimeBetweenSpawn = asteroidData.FindProperty("OriginalTimeBetweenSpawn");


		SpawningBreakpoints = asteroidData.FindProperty("SpawningBreakpoints");
		AsteroidCornerRandomness = asteroidData.FindProperty("AsteroidCornerRandomness");
		AsteroidFlightTarget = asteroidData.FindProperty("AsteroidFlightTarget");

		MinSpawnDistance = asteroidData.FindProperty("MinSpawningDistance");
		MaxSpawnDistance = asteroidData.FindProperty("MaxSpawningDistance");

		MinSpawnSize = asteroidData.FindProperty("MinSpawnSize");
		MaxSpawnSize = asteroidData.FindProperty("MaxSpawnSize");

		MinFlightSpeed = asteroidData.FindProperty("MinFlightSpeed");
		MaxFlightSpeed = asteroidData.FindProperty("MaxFlightSpeed");


		// ship
		MaxHealth = shipData.FindProperty("MaxHealth");
		RotationSpeed = shipData.FindProperty("RotationSpeed");
		ThrustSpeed = shipData.FindProperty("ThrustSpeed");
		ShootCooldown = shipData.FindProperty("ShootCooldown");
		BulletSpeed = shipData.FindProperty("BulletSpeed");
		FirePoint = shipData.FindProperty("FirePoint");


	}

	private void OnGUI()
	{
		asteroidData.Update();

		EditorGUILayout.Space();

		using (new EditorGUILayout.HorizontalScope())
		{

			using (new EditorGUILayout.VerticalScope(EditorStyles.helpBox))
			{
				EditorGUILayout.PropertyField(OriginalTimeBetweenSpawn);


				EditorGUILayout.PropertyField(SpawningBreakpoints);
				EditorGUILayout.PropertyField(AsteroidCornerRandomness);
				EditorGUILayout.PropertyField(AsteroidFlightTarget);


				using (new EditorGUILayout.HorizontalScope())
				{
					EditorGUILayout.PropertyField(MinSpawnDistance);
					EditorGUILayout.PropertyField(MaxSpawnDistance);
				}

				using (new EditorGUILayout.HorizontalScope())
				{
					EditorGUILayout.PropertyField(MinSpawnSize);
					EditorGUILayout.PropertyField(MaxSpawnSize);
				}


				using (new EditorGUILayout.HorizontalScope())
				{
					EditorGUILayout.PropertyField(MinFlightSpeed);
					EditorGUILayout.PropertyField(MaxFlightSpeed);
				}
			}

			EditorGUILayout.Space(30);

			shipData.Update();

			using (new EditorGUILayout.VerticalScope(EditorStyles.helpBox))
			{
				using (new EditorGUILayout.VerticalScope())
				{
					EditorGUILayout.PropertyField(MaxHealth);

					EditorGUILayout.PropertyField(RotationSpeed);

					EditorGUILayout.PropertyField(ThrustSpeed);

					EditorGUILayout.PropertyField(ShootCooldown);

					EditorGUILayout.PropertyField(BulletSpeed);

					EditorGUILayout.PropertyField(FirePoint);
				}
			}

		}

		shipData.ApplyModifiedProperties();
		asteroidData.ApplyModifiedProperties();
	}
}