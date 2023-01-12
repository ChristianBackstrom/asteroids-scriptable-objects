#if UNITY_EDITOR
using UnityEditor;
#endif


using UnityEngine;
using UnityEngine.InputSystem;

public class Shoot : MonoBehaviour
{

	[SerializeField] private Ship _ship;

	[SerializeField] private GameObject _bullet;

	private float cooldown = 0;

	private void OnEnable()
	{
		InputHandler.Instance.Shoot.performed += Fire;
	}

	private void OnDisable()
	{
		InputHandler.Instance.Shoot.performed -= Fire;
	}

	private void Fire(InputAction.CallbackContext ctx)
	{
		if (cooldown > _ship.ShootCooldown)
		{
			cooldown = 0;


			Instantiate(_bullet, this.transform.position + this.transform.right * _ship.FirePoint, Quaternion.Euler(0, 0, -90) * this.transform.rotation);
		}
	}

	private void Update()
	{
		cooldown += Time.deltaTime;
	}


#if UNITY_EDITOR
	private void OnDrawGizmos()
	{
		if (_ship == null) return;

		Handles.color = Color.red;

		Handles.ArrowHandleCap(0, this.transform.position + this.transform.right * _ship.FirePoint, Quaternion.LookRotation(transform.right), .2f, EventType.Repaint);

	}
#endif
}
