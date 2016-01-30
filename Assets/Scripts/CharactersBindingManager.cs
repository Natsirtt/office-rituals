using UnityEngine;

public class CharactersBindingManager : MonoBehaviour {
	void Update () {
	    for (int i = 1; i <= 11; i++)
	    {
	        if (Input.GetButtonDown("XBOX_" + i + "_X"))
	        {
	            Debug.Log("Gamepad id: " + i);
	        }
	    }
	}
}
