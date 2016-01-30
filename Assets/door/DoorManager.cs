using UnityEngine;
using System.Collections;

public class DoorManager : MonoBehaviour {

	public Animator animController;


	// Use this for initialization
	void Start () {
		//animController = GetComponentInChildren<Animator> ();
	}
	void OnTriggerEnter(Collider coll) 
	{
		animController.SetTrigger ("openDoor");
	}
	
	void OnTriggerExit(Collider coll) 
	{
		animController.SetTrigger ("closeDoor");
	} 
}
