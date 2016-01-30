﻿using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {

    private Location previousLocation;

    [SerializeField]
    private float moveSpeed = 1.0f;
    private Vector3 moveVector = Vector3.zero;

	// Use this for initialization
	void Start() {
		gameObject.AddComponent<CoffeeMeter> ();
	}

    public bool CanMove()
    {
        return true; // TODO
    }

    public void Move(Vector2 v)
    {
        moveVector += new Vector3(v.x, 0, v.y) * moveSpeed;
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

    public void AddCoffee(float value) {
		var coffeeComponent = GetComponent<CoffeeMeter> ();
		if (coffeeComponent != null) {
			coffeeComponent.Add (value);
			Debug.Log ("Current Coffee: " + coffeeComponent.Value);
		}
    }
}
