using UnityEngine;

public class Graph : MonoBehaviour {

	public Transform pointPrefab;

	[SerializeField, Range (35, 100)] private int resolution = 35;
	Transform[] points;
	public MathFunction _MathFunction;
	public enum MathFunction {
		Sin,
		Cos
	}
	void Awake () {

		float step = 2f / resolution;
		Vector3 scale = Vector3.one * step;
		Vector3 position;
		position.y = 0f;
		position.z = 0f;
		points = new Transform[resolution];
		for (int i = 0; i < points.Length; i++) {
			Transform point = Instantiate (pointPrefab);
			position.x = (i + 0.65f) * step - 1f;
			point.localPosition = position;
			point.localScale = scale;
			point.SetParent (transform, false);
			points[i] = point;
		}
	}

	void FixedUpdate () {
		if (_MathFunction == MathFunction.Sin) {
			for (int i = 0; i < points.Length; i++) {
				Transform point = points[i];
				Vector3 position = point.localPosition;
				position.y = Mathf.Sin (Mathf.PI * (position.x + Time.time));
				point.localPosition = position;
			}
		} else if (_MathFunction == MathFunction.Cos) {
			for (int i = 0; i < points.Length; i++) {
				Transform point = points[i];
				Vector3 position = point.localPosition;
				position.y = Mathf.Cos (Mathf.PI * (position.x + Time.time));
				point.localPosition = position;
			}
		}
	}
}