using Unity.Entities;
using UnityEngine;

public class GraphSystems : ComponentSystem {

    public struct Data {
        public readonly int Lenght;
        public ComponentDataArray<GraphIComponent> _graph;
    }

    [Inject] private Data data;

    void Awake () {
        float step = 2f;
    }

    protected override void OnUpdate () {
        for (var i = 0; i < data.Lenght; i++) {
            var Graph = data._graph[i];
            Debug.Log(Graph);
        }
    }
}