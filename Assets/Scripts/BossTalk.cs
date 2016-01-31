using UnityEngine;
using System.Collections;

public class BossTalk : MonoBehaviour {

	public string[] linesTowardsMeeting;
	public string[] linesAtMeeting;
	public string[] linesTowardsOffice;
	public AudioClip[] sounds;


	// Use this for initialization
	void Start () {
	
	}

	public string getNextLineWalkToMeeting()
	{
		int l = Random.Range (0, linesTowardsMeeting.Length - 1);
		return linesTowardsMeeting[l];
	}
	public string getNextLineAtMeeting()
	{
		int l = Random.Range (0, linesAtMeeting.Length - 1);
		return linesAtMeeting[l];
	}
	public string getNextLineWalkToOffice()
	{
		int l = Random.Range (0, linesTowardsOffice.Length - 1);
		return linesTowardsOffice[l];
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
