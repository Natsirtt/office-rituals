using UnityEngine;
using System.Collections;

public class LocationSmokeArea : Location {

	private float smokeStartTime;
	public float smokeTime = 4;


	// Use this for initialization
	void Start () {
		smokeStartTime = 0;
	
	}
	public override void LocationAction(Character actingCharacter)
	{
		StartCoroutine (Smoke (smokeTime, actingCharacter));
	}

	IEnumerator Smoke(float time, Character actingCharacter)
	{
		var smokeMeter = actingCharacter.GetComponent<SmokeMeter> ();
		smokeMeter.DepEnabled  = false;

		actingCharacter.StartSmoke ();
		actingCharacter.setCanMove (false);

		yield return new WaitForSeconds(time);

		actingCharacter.setCanMove (true);

		actingCharacter.EndSmoke (75f);
		smokeMeter.DepEnabled  = true;
	}

	// Update is called once per frame
	void Update () {
		
	}
}
