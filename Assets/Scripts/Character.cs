using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {

    private float CoffeeMeter;
    private Location previousLocation;

    [SerializeField]
    private float moveSpeed = 1.0f;
    private Vector3 moveVector = Vector3.zero;

	// Use this for initialization
	void Start() {
        this.CoffeeMeter = 50.0f;
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
        CoffeeMeter += value;
        CoffeeMeter = Mathf.Clamp(CoffeeMeter, 0.0f, 100.0f);
    }

    public void AddWork(float value) {
		WorkMeterManager.GetInstance ().AddWork (this, value);
    }
}
