using System.Collections;
using UnityEngine;

public class Graph : MonoBehaviour {

	public Transform pointPrefab;
	[SerializeField, Range (Mathf.PI, 60 * Mathf.PI)] private float _PI = Mathf.PI;
	[SerializeField, Range (35, 100)] private int resolution = 35;
	[SerializeField] private bool Single = false;
	Transform[] points;
	public MathFunction _MathFunction;
	public enum MathFunction {
		Sin,
		Cos
	}

	void Awake () {
		float step = 4f / resolution;
		Vector3 scale = Vector3.one * step;
		Vector3 position;
		position.y = 0f;
		position.z = 0f;
		points = new Transform[resolution];
		for (int i = 0; i < points.Length; i++) {
			Transform point = Instantiate (pointPrefab);
			position.x = (i + 0.5f) * step - 1f;
			point.localPosition = position;
			point.localScale = scale;
			point.SetParent (transform, false);
			points[i] = point;
		}
	}

	float SineFunction (float x, float t) {
		return Mathf.Sin (_PI * (x + t / _PI));
	}

	float MultiSineFunction (float x, float t) {
		float y = Mathf.Sin (_PI * (x + t / _PI));
		y += Mathf.Sin (2f * _PI * (x + t / _PI)) / 2f;
		y += 2f / 3f;
		return y;
	}

	void Update () {
		float t = Time.time;
		if (_MathFunction == MathFunction.Sin) {
			for (int i = 0; i < points.Length; i++) {
				Transform point = points[i];
				Vector3 position = point.localPosition;
				if (Single == true) {
					position.y = SineFunction (position.x, t);
				} else {
					position.y = MultiSineFunction (position.x, t);
				}
				point.localPosition = position;
			}
		}
		_PI = Mathf.PingPong (Mathf.PI + Time.time, 55 * Mathf.PI);
	}
}