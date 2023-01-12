using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
	public static InputHandler Instance { get; private set; }

	private PlayerInput _playerInput;


	private Vector2 _moveInputs;
	private InputAction _shoot;


	public Vector2 MoveInputs { get => _moveInputs; }
	public InputAction Shoot { get => _shoot; }


	private void Awake()
	{
		#region Singleton
		if (Instance != null)
		{
			Destroy(gameObject);
			return;
		}

		Instance = this;
		DontDestroyOnLoad(gameObject);

		print("InputHandler created");
		#endregion

		_playerInput = GetComponent<PlayerInput>();
	}

	#region Inputs
	private void OnEnable()
	{
		_shoot = _playerInput.actions["Shoot"];
	}

	private void Update()
	{
		_moveInputs = _playerInput.actions["Move"].ReadValue<Vector2>();
	}

	#endregion
}

