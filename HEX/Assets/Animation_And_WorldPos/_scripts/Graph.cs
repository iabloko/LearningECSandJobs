using System.Collections;
using UnityEngine;

public class Graph : MonoBehaviour {

	public Transform pointPrefab;
	[SerializeField, Range (35, 1000)] private int resolution = 35;
	private Transform[] points;
	const float _PI = Mathf.PI;

	//Delegate Zone
	static DelegateFunction[] _dFunctions = {
		SineFunction,
		Sin2DFunction,
		MultiSineFunction,
		MultipleSin,
		Pulsation

	};
	public MathFunction _MathFunction;
	public enum MathFunction {
		Sine,
		Sin2DFunction,
		MultiSine,
		MultipleSin,
		Pulsation
	}
	//Delegate Zone end

	void Awake () {
		float step = 2f / resolution;
		Vector3 scale = Vector3.one * step;
		Vector3 position;
		position.y = 0f;
		position.z = 0f;
		points = new Transform[resolution * resolution];
		for (int i = 0, z = 0; i < points.Length; z++) {
			position.z = (z + 0.5f) * step - 1f;
			for (int x = 0; x < resolution; x++, i++) {
				Transform point = Instantiate (pointPrefab);
				position.x = (x + 0.5f) * step - 1f;
				point.localPosition = position;
				point.localScale = scale;
				point.SetParent (transform, false);
				points[i] = point;
			}
		}
	}
	static float SineFunction (float x, float z, float t) {
		//float _PI = Mathf.PingPong (Mathf.PI + Time.time, 55 * Mathf.PI);
		return Mathf.Sin (_PI * (x + t / _PI));
	}

	static float MultiSineFunction (float x, float z, float t) {
		//float _PI = Mathf.PingPong (Mathf.PI + Time.time, 55 * Mathf.PI);
		float y = Mathf.Sin (_PI * (x + t / _PI));
		y += Mathf.Sin (2f * _PI * (x + t / _PI)) / 2f;
		y *= 2f / 3f;
		return y;
	}

	static float Sin2DFunction (float x, float z, float t) {
		//float _PI = Mathf.PingPong (Mathf.PI + Time.time, 55 * Mathf.PI);
		float y = Mathf.Sin (_PI * (x + t));
		y += Mathf.Sin (_PI * (z + t));
		y *= 0.5f;
		return y;
	}

	static float MultipleSin (float x, float z, float t) {
		//float _PI = Mathf.PingPong (Mathf.PI + Time.time, 55 * Mathf.PI);
		float y = 2f * Mathf.Sin (_PI * (x + z + t * 0.5f));
		y += Mathf.Sin (_PI * (x + t));
		y += Mathf.Sin (2f * _PI * (z + 2f * t)) * 0.5f;
		y *= 0.2f;
		return y;
	}
	static float Pulsation (float x, float z, float t) {
		float q = Mathf.Sqrt (x * x + z * z);
		float y = Mathf.Sin (_PI * (5f * q - t));
		y /= 1f + 10f * q;
		//y *= 0.1f * (1f + 10f * q);
		return y;
	}

	void Update () {
		float t = Time.time;
		DelegateFunction f = _dFunctions[(int) _MathFunction];
		for (int i = 0; i < points.Length; i++) {
			Transform point = points[i];
			Vector3 position = point.localPosition;
			position.y = f (position.x, position.z, t);
			point.localPosition = position;
		}
	}
}