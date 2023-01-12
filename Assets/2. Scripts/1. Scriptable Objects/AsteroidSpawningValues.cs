using UnityEngine;
using UnityEditor;


[CreateAssetMenu(fileName = "AsteroidSpawningValues", menuName = "Asteroird-Destroyer/AsteroidSpawningValues", order = 0)]
public class AsteroidSpawningValues : ScriptableObject
{
	public float SpawnRate;

	public float SpawningDistance;


	[Space(20)]

	public int GenerationSteps;

	public float GenerationRandomness;

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
		if (MaxSpawnSize < MinSpawnSize) MaxSpawnSize = MinSpawnSize;
		if (MaxFlightSpeed < MinFlightSpeed) MaxFlightSpeed = MinFlightSpeed;
	}
}



[CustomEditor(typeof(AsteroidSpawningValues))]
public class AsteroidSpawningEditor : Editor
{
	SerializedObject so;

	SerializedProperty propMinSpawnSize;
	SerializedProperty propMaxSpawnSize;
	SerializedProperty propMinFlightSpeed;
	SerializedProperty propMaxFlightSpeed;

	private void OnEnable()
	{
		so = serializedObject;

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