using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Asteroid : MonoBehaviour
{

	[SerializeField] private GameObject _asteroidShard;


	public void AddForce(float speed, Vector2 target)
	{
		Rigidbody2D rb = this.gameObject.GetComponent<Rigidbody2D>();

		Vector2 direction = new Vector2(Random.Range(-target.x, target.x), Random.Range(-target.y, target.y)) - (Vector2)this.transform.position;

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




	public void Split()
	{
		Vector3[] vertices = GetComponent<MeshFilter>().mesh.vertices;


		Vector3[] splitVertices = new Vector3[3];

		splitVertices[0] = vertices[0];
		splitVertices[1] = vertices[1];
		splitVertices[2] = vertices[vertices.Length - 1];

		GenerateSplitMesh(splitVertices);

		for (int i = 1; i < vertices.Length; i++)
		{
			splitVertices[0] = vertices[0];
			splitVertices[1] = vertices[i];
			splitVertices[2] = vertices[i - 1];

			GenerateSplitMesh(splitVertices);
		}

	}


	private void GenerateRandomSplitMesh(Vector3[] vertices)
	{

	}

	private void GenerateSplitMesh(Vector3[] vertices)
	{
		Mesh mesh = new Mesh();

		int[] triangle = new int[3] { 0, 1, 2 };

		mesh.vertices = vertices;
		mesh.triangles = triangle;

		GameObject splitPiece = Instantiate(_asteroidShard, this.transform.position, this.transform.rotation);

		splitPiece.transform.localScale = this.transform.localScale;

		splitPiece.GetComponent<MeshFilter>().mesh = mesh;
		splitPiece.GetComponent<MeshRenderer>().sharedMaterial = this.GetComponent<MeshRenderer>().sharedMaterial;

		Vector2 averageVertex = GetAverageVertex(vertices);

		Rigidbody2D rb = splitPiece.GetComponent<Rigidbody2D>();
		rb.AddForce(averageVertex * 8, ForceMode2D.Impulse);
		splitPiece.GetComponent<AsteroidShard>().StartCountdownToMinimize(200, .3f);
	}

	private Vector2 GetAverageVertex(Vector3[] vertices)
	{
		Vector2 average = Vector2.zero;

		for (int i = 0; i < vertices.Length; i++)
		{
			average += (Vector2)(this.transform.rotation * vertices[i]);
		}

		average /= vertices.Length;

		return average;
	}
}
