using UnityEngine;
using System.Collections;

public abstract class Meter {
    public float Value;

    void Start() {
        Value = 0.0f;
    }

    public abstract void CalcWork(ref float value);
}



public class Character : MonoBehaviour {

    private float WorkMeter;
    private float CoffeeMeter;
    private Location previousLocation;

	// Use this for initialization
	void Start() {
        this.WorkMeter = 0.0f;
        this.CoffeeMeter = 50.0f;
	}
	
	// Update is called once per frame
	void Update() {
        const float moveSpeed = 3.0f;
        Vector3 move = Vector3.zero;
        if (Input.GetKey("up")) move.y += moveSpeed;
        if (Input.GetKey("down")) move.y -= moveSpeed;
        if (Input.GetKey("left")) move.x -= moveSpeed;
        if (Input.GetKey("right")) move.x += moveSpeed;
        transform.Translate(move * Time.deltaTime);

		if (Input.GetKey("e")) {
			DoLocationAction();
		}
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
        CoffeeMeter += value;
        CoffeeMeter = Mathf.Clamp(CoffeeMeter, 0.0f, 100.0f);
    }

    public void AddWork(float value) {
        WorkMeter += value;
        WorkMeter = Mathf.Clamp(WorkMeter, 0.0f, 100.0f);

        if (WorkMeter >= 100.0f) {
            // Win?
        }
    }
}
