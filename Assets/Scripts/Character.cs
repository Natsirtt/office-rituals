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
	    
	}
    
    public void SetLocation(Location location) {

    }

    public void DoLocationAction() {

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
