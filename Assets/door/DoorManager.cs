using UnityEngine;
using System.Collections;

public class DoorManager : MonoBehaviour {

	public Animator animController;
	private bool open;
	private bool locked;

	private int people = 0;

	// Use this for initialization
	void Start () {
		open = false;
		locked = false;
	}

	public void LockDoor(bool val)
	{
		Debug.Log ("Lockdoor = "+val);
		locked = val;

		if (locked) 
		{
			if (open) {
				open = false;
				animController.SetTrigger ("closeDoor");
			}
		} 

	}

	void OnTriggerStay(Collider coll)
	{
		if (!open && !locked) 
		{
			open = true;
			animController.SetTrigger ("openDoor");
		}
	}

	void OnTriggerEnter(Collider coll) 
	{
		people++;
		if (!open && !locked) 
		{
			open = true;
			animController.SetTrigger ("openDoor");
		}
	}
	
	void OnTriggerExit(Collider coll) 
	{
		people--;
		if (open && people <= 0) 
		{
			animController.SetTrigger ("closeDoor");
			open = false;
		}
	} 
}
