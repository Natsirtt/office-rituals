using UnityEngine;
using System.Collections;

public class LocationWorkDesk : Location {

	public Character OwnerCharacter;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public override void LocationAction(Character actingCharacter)
	{
		//Do work
		float workUpdate = 0.1f;

		if (actingCharacter != OwnerCharacter) 
		{

			workUpdate = - workUpdate;
		}

		Debug.Log ("Working, effort = "+workUpdate);
		if (OwnerCharacter == actingCharacter) {
			Debug.Log ("Add Work! ");
			WorkMeterManager.GetInstance ().AddWork (OwnerCharacter, workUpdate);
		} else {
			Debug.Log ("Steal Work!");
			//WorkMeterManager.GetInstance ().CanStealWork (actingCharacter, OwnerCharacter);
			WorkMeterManager.GetInstance ().StealWork (actingCharacter, OwnerCharacter, workUpdate);
		}
	}
}
