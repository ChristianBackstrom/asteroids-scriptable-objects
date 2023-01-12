using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Asteroird-Destroyer/Ship")]
public class Ship : ScriptableObject
{
	public int MaxHealth;

	public float RotationSpeed;

	public float ThrustSpeed;

	[Range(0, 1)]
	public float ShootCooldown;

	public float BulletSpeed;

	public float FirePoint;


	private void OnValidate()
	{
		MaxHealth = MaxHealth < 0 ? 0 : MaxHealth;
		RotationSpeed = RotationSpeed < 0 ? 0 : RotationSpeed;
		ThrustSpeed = ThrustSpeed < 0 ? 0 : ThrustSpeed;
	}
}
