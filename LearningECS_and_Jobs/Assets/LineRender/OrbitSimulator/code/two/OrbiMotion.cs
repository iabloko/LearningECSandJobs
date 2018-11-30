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
        public float orbitPeriod = 0f;
        public bool orbitActive = true;

        void Start () {
            if (orbitingObject == null) {
                orbitActive = false;
                return;
            }
            SetOrbitionPositions ();
            StartCoroutine (AnimateOrbit ());
            //TrailSettings ();
        }
        private void TrailSettings () {
            TrailRenderer tr = trailObject.AddComponent<TrailRenderer> ();
            tr.time = 2 * orbitPeriod;
            tr.startWidth = 0.55f;
            tr.endWidth = 0;
            tr.material = trailMat;
            tr.startColor = new Color (1, 1, 0, 0.1f);
            tr.endColor = new Color (0, 0, 0, 0);
        }

        private void SetOrbitionPositions () {
            Vector2 orbitPos = orbitpath.Evalute (orbitProgress);
            orbitingObject.localPosition = new Vector3 (orbitPos.x, 0, orbitPos.y);
        }
        private void RandomOrbitPosotion () {
            orbitProgress = UnityEngine.Random.Range (0f, 1f);
        }
        void Update () {
            if (Input.GetKeyUp (KeyCode.Space)) {
                RandomOrbitPosotion ();
            }
        }
        IEnumerator AnimateOrbit () {
            if (orbitPeriod < 0.1f) {
                orbitPeriod = 0.1f;
            }

            float orbitSpeed = 1f / orbitPeriod;
            while (orbitActive) {
                orbitProgress += Time.deltaTime * orbitSpeed;
                orbitProgress %= 1f;
                SetOrbitionPositions ();
                yield return null;
            }
        }

    }
}