﻿using UnityEngine;
using System.Collections;

public class ConferenceLocation : Location {

	public DoorManager confDoor;


	// Use this for initialization
	void Start () {
	
	}

	public override void LocationAction(Character actingCharacter)
	{
		
	}

	public void LockDoor(bool val)
	{
		//Debug.Log ("Confroom lock "+val);
		Debug.Log (confDoor);

		if (confDoor != null)
		{
			//Debug.Log ("Confroom lock not null");
			confDoor.LockDoor (val);
		}
	}

	public bool CheckPlayersInConfRoom()
	{
		bool anyoneMissing = false;
		for (int i = 0; i < CharactersManager.Instance.characters.Count; i++) {

			Location cLocation = CharactersManager.Instance.characters [i].GetCurrentLocation (); 
			if (cLocation != null && "ConfRoom" == cLocation.name) 
			{
				//OK, player in conf room
				Debug.Log("player nbr "+i+" is in conf room");
			} 
			else
			{
				Debug.Log("player nbr "+i+" is NOT in conf room");
				StartCoroutine(PunishPlayer (CharactersManager.Instance.characters [i]));
				anyoneMissing = true;
			}
		}
		return anyoneMissing;
	}

	IEnumerator PunishPlayer(Character player)
	{
		yield return new WaitForSeconds(1);
		player.StartSmokeOverCharacter ();
		player.setCanMove (false);
		yield return new WaitForSeconds(10);
		player.setCanMove (true);
		player.StopSmokeOverCharacter ();
	}
	// Update is called once per frame
	void Update () {
	
	}
}
