using UnityEngine;
using System.Collections;

public abstract class Location : MonoBehaviour {



	// Use this for initialization
	void Start () {
	
	}

	void OnTriggerEnter(Collider coll) 
	{
		Debug.Log ("OnTriggerEnter");
		Character character;
		character = coll.gameObject.GetComponent<Character>();
		
		if (character != null) {
			character.SetLocation (this);
		}
	}

	void OnTriggerExit(Collider coll) 
	{
		Debug.Log ("OnTriggerExit");
		Character character;
		character = coll.gameObject.GetComponent<Character>();
		
		if (character != null) {
			character.SetLocation (null);
		}
	} 

	public abstract void LocationAction (Character actingCharacter);

	// Update is called once per frame
	void Update () {
	
	}

}
