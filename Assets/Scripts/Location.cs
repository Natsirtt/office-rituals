using UnityEngine;
using System.Collections;

public abstract class Location : MonoBehaviour {



	// Use this for initialization
	void Start () {
	
	}

	void OnCollisionEnter(Collision coll) 
	{
		Character character;
		character = coll.gameObject.GetComponent<Character>();

		if (character != null) {
			character.SetLocation (this);
		}
	} 

	void OnCollisionExit(Collision coll) 
	{
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
