using UnityEngine;
using System.Collections;

public class BossTalk : MonoBehaviour {

	public string[] lines;
	public AudioClip[] sounds;


	// Use this for initialization
	void Start () {
	
	}

	public string getNextLine()
	{
		int l = Random.Range (0, lines.Length - 1);
		return lines[l];
	}

	public AudioClip getNextSound()
	{
		int l = Random.Range (0, sounds.Length - 1);
		return sounds[l];
	}


	// Update is called once per frame
	void Update () {
	
	}
}
