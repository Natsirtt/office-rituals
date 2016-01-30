using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {

    private Location previousLocation;

    [SerializeField]
    private float moveSpeed = 1.0f;
    private Vector3 moveVector = Vector3.zero;

	private bool canMove;

	// Use this for initialization
	void Start() {
		gameObject.AddComponent<CoffeeMeter> ();
		canMove = true;
	}

    public bool CanMove()
    {
        return canMove; // TODO
    }
	public void setCanMove(bool val)
	{
		canMove = val;
	}

    public void Move(Vector2 v)
    {
		if (canMove) 
		{
			moveVector += new Vector3 (v.x, 0, v.y) * moveSpeed;
		}
    }
	
	// Update is called once per frame
	void Update() {
        transform.Translate(moveVector * Time.deltaTime);
        moveVector = Vector3.zero;
	}
    
    public void SetLocation(Location location) {
        previousLocation = location;
    }

    public void DoLocationAction() {
        if (previousLocation != null) {
            previousLocation.LocationAction(this);
        }
    }

    public void DoSecondaryAction()
    {
        Debug.LogWarning("No secondary action implemented yet");
        // TODO
    }

    public void AddCoffee(float value) {
		var coffeeComponent = GetComponent<CoffeeMeter> ();
		if (coffeeComponent != null) {
			coffeeComponent.Add (value);
			Debug.Log ("Current Coffee: " + coffeeComponent.Value);
		}
    }
}
