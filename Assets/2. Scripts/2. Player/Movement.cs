using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
	[SerializeField] private Ship _ship;

	[SerializeField] private Vector2 _input;

	[SerializeField] private Rigidbody2D _rb;

	private ParticleSystem _particleSystem;

	private void Awake()
	{
		_rb = GetComponent<Rigidbody2D>();
		_particleSystem = GetComponentInChildren<ParticleSystem>();
	}


	private void Update()
	{
		Getinput();

		ApplyRotation(_input.x);

		ApplyThrust(_input.y);

		ApplyParticles(_input.y);
	}

	private void FixedUpdate()
	{
	}

	private void ApplyRotation(float rotation)
	{

		this.transform.rotation *= Quaternion.Euler(0, 0, -rotation * _ship.RotationSpeed * Time.deltaTime);
	}

	private void ApplyThrust(float thrust)
	{
		_rb.AddForce(transform.right * thrust * _ship.ThrustSpeed);
	}

	private void Getinput()
	{
		_input = InputHandler.Instance.MoveInputs;

		if (_input.y < 0) _input.y = 0;
	}

	private void ApplyParticles(float thrust)
	{
		ParticleSystem.MainModule main = _particleSystem.main;
		if (thrust > 0)
		{
			_particleSystem.Play();
			return;
		}

		_particleSystem.Stop();
	}
}
