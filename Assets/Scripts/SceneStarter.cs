using UnityEngine;

public class SceneStarter : MonoBehaviour {
	public GameObject[] playerStartingPositions;

	// Use this for initialization
	void Start () {
		var prefab = Resources.Load<GameObject> ("GUI");
		for (int i = 0; i < CharactersManager.Instance.characters.Count; i++) {
			var newGUI = Instantiate(prefab);
			CharactersManager.Instance.characters[i].GUI = newGUI;
            //Debug.Log(CharactersManager.Instance.characters[i].transform.position);
		    CharactersManager.Instance.characters[i].transform.position = playerStartingPositions[i].transform.position;
            //Debug.Log(CharactersManager.Instance.characters[i].transform.position);
		}
		CharactersManager.Instance.EnableAllCharacters ();
	}
}
