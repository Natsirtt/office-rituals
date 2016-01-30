using UnityEngine;

[RequireComponent(typeof(Character))]
public abstract class Controller : MonoBehaviour
{
    private Character character;

    void Awake()
    {
        character = GetComponent<Character>();
    }

	// Update is called once per frame
	void Update () {
	    if (IsActionPressed())
	    {
            Debug.Log("Action pressed by " + this.name);
	        character.DoLocationAction();
	    }
	    if (character.CanMove())
	    {
	        character.Move(ComputeMovement().normalized);
	    }
	}

    protected abstract bool IsActionPressed();
    protected abstract Vector2 ComputeMovement();
}
