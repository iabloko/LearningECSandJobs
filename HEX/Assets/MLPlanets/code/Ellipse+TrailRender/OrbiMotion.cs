using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Orbits {
    public class OrbiMotion : MonoBehaviour {
        public Transform orbitingObject;
        public GameObject trailObject;
        public Ellipse orbitpath;
        public Material trailMat;

        [Range (0, 1f)] public float orbitProgress = 0f;
        public bool orbitActive = true;
        [Range (0.01f, 100f)] public float orbitPeriod;
        //rotate around it`s axis
        [Range (0, 25)] public int planetSpeedRotation;

        void Start () {
            if (orbitingObject == null) {
                orbitActive = false;
                return;
            }
            SetOrbitionPositions ();
            StartCoroutine (AnimateOrbit ());
            TrailSettings ();
        }
        private void TrailSettings () {
            TrailRenderer tr = trailObject.AddComponent<TrailRenderer> ();
            tr.time = 100;
            tr.startWidth = 0.005f;
            tr.endWidth = 0;
            tr.material = trailMat;
            tr.startColor = new Color (1, 1, 0, 0.1f);
            tr.endColor = new Color (0, 0, 0, 0);
        }

        private void SetOrbitionPositions () {
            Vector2 orbitPos = orbitpath.Evalute (orbitProgress);
            orbitingObject.localPosition = new Vector3 (orbitPos.x, orbitPos.y, orbitPos.y);
            trailObject.transform.Rotate (Vector3.up * planetSpeedRotation);
        }
        //random position
        private void RandomOrbitPosotion () {
            orbitProgress = UnityEngine.Random.Range (0f, 1f);
        }
        void Update () {
            if (Input.GetKeyUp (KeyCode.Space)) {
                RandomOrbitPosotion ();
            }
        }
        IEnumerator AnimateOrbit () {
            float speed = 1 / orbitPeriod;
            if (orbitPeriod < 0.1f) {
                orbitPeriod = 0.1f;
            }
            while (orbitActive) {
                orbitProgress += Time.deltaTime * speed;
                orbitProgress %= 1f;
                SetOrbitionPositions ();
                yield return null;
            }
        }

    }
}