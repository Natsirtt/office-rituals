﻿using UnityEngine;

public class Character : MonoBehaviour {

	public GameObject GUI;
	public int id;

    private Location previousLocation;

    [SerializeField]
    private float moveSpeed = 1.0f;
    private Vector3 moveVector = Vector3.zero;

	private bool canMove;
	private float lastCoffeDrink;
	public float coffeeDrinkTime = 5;

	public GameObject coffeCup;

	private bool hasCoffeCup;

	public Transform characterModel;

	// Use this for initialization
	void Start() {
		gameObject.AddComponent<CoffeeMeter> ();

		WorkMeterManager.GetInstance ().OnChange += OnWorkUpdated;
		ForceUpdateGUI ();
		if (coffeCup != null) {
			coffeCup.SetActive (false);
		}
		canMove = true;
		hasCoffeCup = false;
	}

	public bool DrinkingCoffe()
	{
		hasCoffeCup = false;
		bool drinking = false;
		if (lastCoffeDrink != 0 && Time.time < lastCoffeDrink + coffeeDrinkTime) 
		{
			drinking = true;
		}
		return drinking;
	}

#region GUI
	void OnWorkUpdated() {
		var inst = WorkMeterManager.GetInstance();
		GUI.GetComponent<GUI> ().SetWork(inst.GetWork(this));
	}
	void UpdateCoffeeGUI() {
		var coffeeComponent = GetComponent<CoffeeMeter> ();
		GUI.GetComponent<GUI> ().SetCoffee (coffeeComponent.Value);
	}
	public void ForceUpdateGUI() {
		OnWorkUpdated ();
	}
#endregion

    public bool CanMove()
    {
        return canMove;
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

		if (characterModel != null && moveVector != Vector3.zero) {
			Vector3 rotateVector = moveVector;
			rotateVector.y = 1;
			characterModel.transform.LookAt (rotateVector);
		}

        moveVector = Vector3.zero;
	}
    
    public void SetLocation(Location location) {
        previousLocation = location;
    }

    public void DoLocationAction() {
        
		if (hasCoffeCup) 
		{
			AddCoffee(20f);
			hasCoffeCup = false;
			coffeCup.SetActive(false);
		}

		if (previousLocation != null) {
            previousLocation.LocationAction(this);
        }

    }

    public void DoSecondaryAction()
    {
        Debug.LogWarning("No secondary action implemented yet");
        // TODO
    }

	public void TakeCoffeeCup()
	{
		if (!hasCoffeCup && !DrinkingCoffe ()) 
		{
			hasCoffeCup = true;

			coffeCup.SetActive(true);
		}
	}

    public void AddCoffee(float value) {
		lastCoffeDrink = Time.time;

		var coffeeComponent = GetComponent<CoffeeMeter> ();
		if (coffeeComponent != null) {
			coffeeComponent.Add (value);
			Debug.Log ("Current Coffee: " + coffeeComponent.Value);

			GUI.GetComponent<GUI> ().SetCoffee(coffeeComponent.Value);
		}
    }
}
