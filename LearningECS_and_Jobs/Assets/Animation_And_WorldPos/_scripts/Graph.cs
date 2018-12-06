using System.Collections;
using UnityEngine;

public class Graph : MonoBehaviour {

	public Transform pointPrefab;
	[SerializeField, Range (25, 50000)] private int resolution = 35;
	private Transform[] points;
	const float _PI = Mathf.PI;

	public NamesForDelegate _function;

	void Awake () {
		float step = 2f / resolution;
		Vector3 scale = Vector3.one * step;
		points = new Transform[resolution * resolution];
		for (int i = 0; i < points.Length; i++) {
			Transform point = Instantiate (pointPrefab);
			point.localScale = scale;
			point.SetParent (transform, false);
			points[i] = point;
		}
	}
	void Update () {
		float t = Time.deltaTime;
		DelegateFunction f = dFunctions[(int) _function];
		float step = 2f / resolution;
		Debug.Log (step);
		for (int i = 0, z = 0; z < resolution; z++) {
			float v = (z + 0.5f) * step - 1f;
			for (int x = 0; x < resolution; x++, i++) {
				float u = (x + 0.5f) * step - 1f;
				points[i].localPosition = f (u, v, t);
			}
		}
	}
	static DelegateFunction[] dFunctions = {
		SineFunction,
		MultiSineFunction,
		Sin2DFunction,
		MultipleSin,
		Pulsation,
		Cylinder,
		Sphere,
		Lissaju
	};

	static Vector3 SineFunction (float x, float z, float t) {
		//float _PI = Mathf.PingPong (Mathf.PI + Time.time, 55 * Mathf.PI);
		Vector3 _vector;
		Debug.Log ("x= " + x + "z= " + z);
		_vector.x = x;
		_vector.y = Mathf.Sin (_PI * (x + t));
		_vector.z = z;
		return _vector;
	}

	static Vector3 MultiSineFunction (float x, float z, float t) {
		//float _PI = Mathf.PingPong (Mathf.PI + Time.time, 55 * Mathf.PI);
		Vector3 _vector;
		_vector.x = x;
		_vector.y = Mathf.Sin (_PI * (x + t / _PI));
		_vector.y += Mathf.Sin (2f * _PI * (x + t / _PI)) / 2f;
		_vector.y *= 2f / 3f;
		_vector.z = z;
		return _vector;
	}

	static Vector3 Sin2DFunction (float x, float z, float t) {
		//float _PI = Mathf.PingPong (Mathf.PI + Time.time, 55 * Mathf.PI);
		Vector3 _vector;
		_vector.x = x;
		_vector.y = Mathf.Sin (_PI * (x + t));
		_vector.y += Mathf.Sin (_PI * (z + t));
		_vector.y *= 0.5f;
		_vector.z = z;
		return _vector;
	}

	static Vector3 MultipleSin (float x, float z, float t) {
		//float _PI = Mathf.PingPong (Mathf.PI + Time.time, 55 * Mathf.PI);
		Vector3 _vector;
		_vector.x = x;
		_vector.y = 2f * Mathf.Sin (_PI * (x + z + t * 0.5f));
		_vector.y += Mathf.Sin (_PI * (x + t));
		_vector.y += Mathf.Sin (2f * _PI * (z + 2f * t)) * 0.5f;
		_vector.y *= 0.2f;
		_vector.z = z;
		return _vector;
	}
	static Vector3 Pulsation (float x, float z, float t) {
		Vector3 _vector;
		float q = Mathf.Sqrt (x * x + z * z);
		_vector.x = x;
		_vector.y = Mathf.Sin (_PI * (5f * q - t));
		_vector.y /= 1f + 10f * q;
		_vector.z = z;
		//y *= 0.1f * (1f + 10f * q);
		return _vector;
	}

	static Vector3 Cylinder (float u, float v, float t) {
		Vector3 _vector;
		float radius = 1f + Mathf.Sin (2f * _PI * v + t) * 0.2f;
		_vector.x = radius * Mathf.Sin (_PI * u);
		_vector.y = v;
		_vector.z = radius * Mathf.Cos (_PI * u);
		return _vector;
	}

	static Vector3 Sphere (float u, float v, float t) {
		Vector3 _vector;
		float radius = 0.8f + Mathf.Sin (_PI * (6f * u + t)) * 0.1f;
		radius += Mathf.Sin (_PI * (4f * v + t)) * 0.1f;
		float S = radius * Mathf.Cos (_PI * 0.5f * v);

		_vector.x = S * Mathf.Sin (_PI * u);
		_vector.y = radius * Mathf.Sin (_PI * 0.5f * v);
		_vector.z = S * Mathf.Cos (_PI * u);

		return _vector;
	}
	static Vector3 Lissaju (float u, float v, float t) {
		Vector3 _vector;
		float freq_a = 1f;
		float freq_b = 2f;
		_vector.x = 1f * Mathf.Sin (freq_a * v * t);
		_vector.y = 1f * Mathf.Sin (freq_b * v * t);
		_vector.z = 1f;
		//Debug.Log(_vector);

		return _vector;
	}
}