using System;
using UnityEngine;

[RequireComponent(typeof(Character))]
public abstract class Controller : MonoBehaviour
{
    private Character character;

    void Awake()
    {
        character = GetComponent<Character>();
        foreach (var j in Input.GetJoystickNames())
        {
            Debug.Log(j);
        }
    }

	// Update is called once per frame
	void Update () {
	    if (IsActionPressed())
	    {
            //Debug.Log("Action pressed by " + this.name);
	        character.DoLocationAction();
	    }
	    if (IsSecondaryActionPressed())
	    {
	        Debug.Log("Secondary pressed by " + this.name);
	        character.DoSecondaryAction();
	    }
	    if (character.CanMove())
	    {
	        character.Move(ComputeMovement().normalized);
	    }
	}

    protected abstract bool IsActionPressed();
    protected abstract bool IsSecondaryActionPressed();
    protected abstract Vector2 ComputeMovement();
}
