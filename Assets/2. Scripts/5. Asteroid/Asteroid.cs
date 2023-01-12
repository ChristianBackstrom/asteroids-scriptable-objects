using System;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
	private const float Randomness = .5f;

	public void AddForce(float speed)
	{
		Rigidbody2D rb = this.gameObject.GetComponent<Rigidbody2D>();

		Vector2 direction = -this.transform.position;

		rb.AddForce(direction * speed);
	}

	public void GenerateAsteroid(float size, float steps, float randomness)
	{
		List<Vector3> vertices = new List<Vector3>();

		vertices.Add(Vector2.zero);

		float step = (2 * Mathf.PI) / steps;

		for (int i = 0; i < steps; i++)
		{
			float x = Mathf.Cos(step * i);
			float y = Mathf.Sin(step * i);

			Vector2 vert = new Vector3(x, y);

			vert *= 1 + UnityEngine.Random.Range(-randomness, randomness);

			vertices.Add(vert);
		}

		Mesh mesh = GenerateMesh(vertices.ToArray());

		this.gameObject.GetComponent<MeshFilter>().mesh = mesh;

		PolygonCollider2D polygonCollider2D = this.gameObject.AddComponent<PolygonCollider2D>();

		List<Vector2> path = new List<Vector2>();

		for (int i = 1; i < vertices.Count; i++)
		{
			path.Add(vertices[i]);
		}

		polygonCollider2D.SetPath(0, path.ToArray());
	}



	private Mesh GenerateMesh(Vector3[] vertices)
	{
		Mesh mesh = new Mesh();

		Vector2 center = Vector2.zero;

		List<int> triangles = new List<int>();

		for (int i = 1; i < vertices.Length; i++)
		{
			triangles.Add(0);
			triangles.Add(i);
			triangles.Add(i - 1);
		}

		triangles.Add(0);
		triangles.Add(1);
		triangles.Add(vertices.Length - 1);

		mesh.vertices = vertices;
		mesh.triangles = triangles.ToArray();

		return mesh;
	}
}
