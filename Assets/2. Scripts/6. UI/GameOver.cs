using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOver : MonoBehaviour
{
	[SerializeField] TMP_Text _asteroidCount;

	private void Awake()
	{
		this.gameObject.SetActive(false);
	}

	private void OnEnable()
	{
		if (_asteroidCount == null)
		{
			print("Assign all variables");
			return;
		}


		_asteroidCount.text = $"{AsteroidManager.Instance.AsteroidsDestroyed} asteroids destroyed";
	}

	public void Restart()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
}
