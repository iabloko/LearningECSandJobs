using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class LightGrid : MonoBehaviour {
    [SerializeField] Light _light;
    private int _line, _columns = 2;
    private int _spacing = 2;
    [SerializeField] float _speed = 2;

    List<Light> _ListOfLight = new List<Light> ();

    void Start () {
        for (var y = 0; y < _line; y++) {
            for (var x = 0; x < _columns; x++) {
                var px = (x - (_columns - 0.5f) / 2) * _spacing;
                var py = (y - (_line - 0.5f) / 2) * _spacing;

                var go = Instantiate (_light, transform);
                go.transform.localPosition = new Vector3 (px, py, 0);
                go.transform.localRotation = Quaternion.identity;

                _ListOfLight.Add (go.GetComponent<Light> ());
            }
        }
        Destroy (_light.gameObject);
    }

    void Update () {
        IDE ();
    }

    private void IDE () {
        var t = Time.time;

        foreach (var l in _ListOfLight) {
            var p = (float3) l.transform.localPosition;
            p.z = t;

            var amplitude = math.saturate (noise.snoise (p / _speed) * 0.9f);

            var red = math.sin (amplitude * 7 + t * 4);
            var green = math.sin (amplitude * 7 + t * 2);
            var blue = math.sin (amplitude * 8 + t * 3);

            var col = (Color) ((Vector4) (new float4 (red, green, blue, 1) / 2 + 0.5f));
            col = col.linear;

            l.color = col;
        }
    }
}