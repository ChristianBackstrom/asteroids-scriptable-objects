using UnityEngine;
using UnityEditor;


[CreateAssetMenu(fileName = "AsteroidSpawningValues", menuName = "Asteroird-Destroyer/AsteroidSpawningValues", order = 0)]
public class AsteroidSpawningValues : ScriptableObject
{
	public float TimeBetweenSpawn;


	[Space(20)]

	public float AsteroidCornerRandomness;

	[Space(20)]
	public Vector2 AsteroidFlightTarget;


	[Space(20)]
	[HideInInspector] public float MinSpawningDistance;

	[Space(20)]
	[HideInInspector] public float MaxSpawningDistance;




	[Space]
	[HideInInspector] public int MinAsteroidCornerAmount;

	[Space]
	[HideInInspector] public int MaxAsteroidCornerAmount;



	[Space]
	[HideInInspector] public float MinSpawnSize;

	[Space]
	[HideInInspector] public float MaxSpawnSize;


	[Space]
	[HideInInspector] public float MinFlightSpeed;

	[Space]
	[HideInInspector] public float MaxFlightSpeed;



	private void OnValidate()
	{
		if (MaxSpawningDistance < MinSpawningDistance) MaxSpawningDistance = MinSpawningDistance;
		if (MaxSpawnSize < MinSpawnSize) MaxSpawnSize = MinSpawnSize;
		if (MaxFlightSpeed < MinFlightSpeed) MaxFlightSpeed = MinFlightSpeed;
	}
}



[CustomEditor(typeof(AsteroidSpawningValues))]
public class AsteroidSpawningEditor : Editor
{
	SerializedObject so;

	SerializedProperty propMinSpawnDistance;
	SerializedProperty propMaxSpawnDistance;

	SerializedProperty propMinSpawnSize;
	SerializedProperty propMaxSpawnSize;

	SerializedProperty propMinFlightSpeed;
	SerializedProperty propMaxFlightSpeed;

	private void OnEnable()
	{
		so = serializedObject;

		propMinSpawnDistance = so.FindProperty("MinSpawningDistance");
		propMaxSpawnDistance = so.FindProperty("MaxSpawningDistance");

		propMinSpawnSize = so.FindProperty("MinSpawnSize");
		propMaxSpawnSize = so.FindProperty("MaxSpawnSize");

		propMinFlightSpeed = so.FindProperty("MinFlightSpeed");
		propMaxFlightSpeed = so.FindProperty("MaxFlightSpeed");
	}

	public override void OnInspectorGUI()
	{
		base.OnInspectorGUI();

		so.Update();

		using (new EditorGUILayout.HorizontalScope())
		{
			EditorGUILayout.PropertyField(propMinSpawnDistance);
			EditorGUILayout.PropertyField(propMaxSpawnDistance);
		}

		using (new EditorGUILayout.HorizontalScope())
		{
			EditorGUILayout.PropertyField(propMinSpawnSize);
			EditorGUILayout.PropertyField(propMaxSpawnSize);
		}


		using (new EditorGUILayout.HorizontalScope())
		{
			EditorGUILayout.PropertyField(propMinFlightSpeed);
			EditorGUILayout.PropertyField(propMaxFlightSpeed);
		}


		so.ApplyModifiedProperties();
	}
}