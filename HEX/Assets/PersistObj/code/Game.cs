using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour {
	[SerializeField] private List<Transform> listObjects;

	public Transform prefab;
	public Text _reference;

	public KeyCode createKey = KeyCode.C;
	public KeyCode newGameKey = KeyCode.N;
	public KeyCode saveKey = KeyCode.S;
	public KeyCode loadKey = KeyCode.L;

	string savePath;

	void Awake () {
		listObjects = new List<Transform> ();
		savePath = Path.Combine (Application.persistentDataPath, "saveFile");

		_reference.text = "createKey= " + createKey.ToString () + " " + "newGameKey= " + newGameKey.ToString () + " " + "saveKey= " + saveKey.ToString () + " " + "loadKey= " + loadKey.ToString ();
	}

	void Update () {
		if (Input.GetKeyUp (createKey)) {
			CreateObject ();
		} else if (Input.GetKeyUp (newGameKey)) {
			ResetScene ();
		} else if (Input.GetKeyUp (saveKey)) {
			Save ();
		} else if (Input.GetKeyUp (loadKey)) {
			Load ();
		}
	}

	void ResetScene () {
		for (int i = 0; i < listObjects.Count; i++) {
			Destroy (listObjects[i].gameObject);
		}
		listObjects.Clear ();
	}

	void CreateObject () {
		Transform createObjects = Instantiate (prefab);
		createObjects.localPosition = Random.insideUnitSphere * 3f;
		createObjects.localRotation = Random.rotation;
		createObjects.localScale = Vector3.one * Random.Range (0.1f, 1f);
		listObjects.Add (createObjects);
	}

	void Save () {
		using (
			var writer = new BinaryWriter (File.Open (savePath, FileMode.Create))
		) {
			writer.Write (listObjects.Count);
			for (int i = 0; i < listObjects.Count; i++) {
				Transform t = listObjects[i];
				writer.Write (t.localPosition.x);
				writer.Write (t.localPosition.y);
				writer.Write (t.localPosition.z);
			}
		}
	}

	void Load () {
		ResetScene ();
		using (
			var reader = new BinaryReader (File.Open (savePath, FileMode.Open))
		) {
			int count = reader.ReadInt32 ();
			for (int i = 0; i < count; i++) {
				Vector3 p;
				p.x = reader.ReadSingle ();
				p.y = reader.ReadSingle ();
				p.z = reader.ReadSingle ();
				Transform t = Instantiate (prefab);
				t.localPosition = p;
				listObjects.Add (t);
			}
		}
	}
}