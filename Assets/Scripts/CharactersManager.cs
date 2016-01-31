using System.Collections.Generic;
using UnityEngine;

public class CharactersManager : MonoBehaviour
{
    private static CharactersManager _instance = null;

    public static CharactersManager Instance
    {
        get { return _instance; }
    }

    public List<Character> characters;
    private int nextCharacterId = 0;
    private GameObject characterPrefab;

    // Use this for initialization
	void Awake() {
	    if (_instance != null)
	    {
	        Debug.LogError("Two CharactersManager in the hierarchy");
	        return;
	    }
	    _instance = this;
        Debug.Log("Singleton " + name + " initialized");

        characters = new List<Character>();
        DontDestroyOnLoad(gameObject);
	    characterPrefab = Resources.Load<GameObject>("CharacterPrefab");
	}

    public GameObject CreateCharacter()
    {
        var newChar = Instantiate(characterPrefab);
        newChar.transform.parent = transform;
        //newChar.SetActive(false);
        var charScript = newChar.GetComponent<Character>();
        characters.Add(charScript);
		charScript.id = nextCharacterId;
		charScript.GetComponentInChildren<CharacterMaterial>().TextureIndex = charScript.id;
        nextCharacterId++;
        return newChar;
    }

    public void EnableAllCharacters()
    {
		switch (characters.Count) {
		case 1: workValue = 1.00f; break;
		case 2: workValue = 0.50f; break;
		case 3: workValue = 0.40f; break;
		case 4: workValue = 0.20f; break;
		default: workValue = 0.1f; break; // should never called
		}

        foreach (var character in characters)
        {
            character.gameObject.SetActive(true);
        }
    }

	public static float workValue = 0.1f;
}
