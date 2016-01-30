using UnityEngine;

[RequireComponent(typeof(Collider))]
public abstract class Location : MonoBehaviour {
	void OnTriggerEnter(Collider coll) 
	{
		//Debug.Log ("OnTriggerEnter");
		Character character;
		character = coll.gameObject.GetComponent<Character>();
		
		if (character != null) {
			character.SetLocation (this);
		}
	}

	void OnTriggerExit(Collider coll) 
	{
		//Debug.Log ("OnTriggerExit");
		Character character;
		character = coll.gameObject.GetComponent<Character>();
		
		if (character != null) {
			character.SetLocation (null);
		}
	} 

	public abstract void LocationAction (Character actingCharacter);
}
