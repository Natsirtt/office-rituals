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

		//if (actingCharacter != OwnerCharacter) {
		//	workUpdate = - workUpdate;
		//}

		if (OwnerCharacter == actingCharacter) {
			//Debug.Log ("Add Work! ");
			WorkMeterManager.GetInstance ().AddWork (OwnerCharacter, workUpdate);
		} else {
			//WorkMeterManager.GetInstance ().CanStealWork (actingCharacter, OwnerCharacter);
			float workStolen = WorkMeterManager.GetInstance ().StealWork (actingCharacter, OwnerCharacter, workUpdate);
			Debug.Log (string.Format("{0} stole {1} work from {2}", 
				actingCharacter.name, workStolen, OwnerCharacter.name));
		}
	}
}
