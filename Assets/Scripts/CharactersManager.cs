﻿using System.Collections.Generic;
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
        newChar.SetActive(false);
        var charScript = newChar.GetComponent<Character>();
        characters.Add(charScript);
		charScript.id = nextCharacterId;
        charScript.GetComponentInChildren<CharacterMaterial>().TextureIndex = charScript.id;
        nextCharacterId++;
        return newChar;
    }

    public void EnableAllCharacters()
    {
        foreach (var character in characters)
        {
            character.gameObject.SetActive(true);
        }
    }
}
