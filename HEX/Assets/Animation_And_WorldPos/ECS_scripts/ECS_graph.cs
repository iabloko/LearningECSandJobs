using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

class ECS_graph : MonoBehaviour {
    public NamesForDelegate _function;
    public int resolution;
    public Transform pointPrefab;
    private const float _PI = Mathf.PI;
    [HideInInspector] public Transform[] points;

}
class FunctionSystem : ComponentSystem {

    struct Component {
        public ECS_graph _graph;
    }
    //[Inject] Component _components;
    protected override void OnUpdate () {
        float t = Time.time;
        //DelegateFunction f = dFunctions[(int) _function];
        foreach (var entity in GetEntities<Component> ()) {
            Debug.Log (entity);
        }
    }
    static DelegateFunction[] dFunctions = {
        SineFunction
    };
    static Vector3 SineFunction (float x, float z, float t) {
        Vector3 _vector;
        _vector.x = x;
        _vector.y = Mathf.Sin (Mathf.PI * (x + t));
        _vector.z = z;
        return _vector;
    }
}