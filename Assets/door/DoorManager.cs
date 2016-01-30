using UnityEngine;
using System.Collections;

public class DoorManager : MonoBehaviour {

	public Animator animController;
	private bool open;

	// Use this for initialization
	void Start () {
		open = false;
	}
	void OnTriggerEnter(Collider coll) 
	{
		if (!open) 
		{
			open = true;
			animController.SetTrigger ("openDoor");
		}
	}
	
	void OnTriggerExit(Collider coll) 
	{
		if (open) 
		{
			animController.SetTrigger ("closeDoor");
			open = false;
		}
	} 
}
