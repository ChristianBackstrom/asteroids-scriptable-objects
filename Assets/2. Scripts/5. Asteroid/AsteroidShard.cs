using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidShard : MonoBehaviour
{
	private bool _minimize = false;

	private float _timer = 0;

	private float _lifeTime;

	private Vector3 _startScale;

	public async void StartCountdownToMinimize(int delay, float lifeTime)
	{
		await Task.Delay(delay);

		_timer = lifeTime;
		_lifeTime = lifeTime;

		_startScale = this.transform.localScale;

		_minimize = true;
	}

	private void Update()
	{
		if (!_minimize) return;

		_timer -= Time.deltaTime;

		if (_timer <= 0) Destroy(this.gameObject);

		this.transform.localScale = _startScale * _timer / _lifeTime;
	}
}
