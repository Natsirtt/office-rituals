using UnityEngine;
using System.Collections;

public class SceneStarter : MonoBehaviour {
	public int characterOffsetX = 2;
	public int characterOffsetZ = 4;
	// Use this for initialization
	void Start () {
		var prefab = Resources.Load<GameObject> ("GUI");
		for (int i = 0; i < CharactersManager.Instance.characters.Count; i++) {
			var newGUI = Instantiate(prefab);
			CharactersManager.Instance.characters[i].GUI = newGUI;

			Vector3 offset = new Vector3(characterOffsetX*i,0,characterOffsetZ);

			CharactersManager.Instance.characters[i].transform.position += offset;
		}
		CharactersManager.Instance.EnableAllCharacters ();
	}
}
