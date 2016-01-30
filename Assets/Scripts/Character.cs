using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {

	public GameObject GUI;

    private Location previousLocation;

    [SerializeField]
    private float moveSpeed = 1.0f;
    private Vector3 moveVector = Vector3.zero;

	private bool canMove;
	private float lastCoffeDrink;
	public float coffeeDrinkTime = 5;

	public GameObject coffeCup;

	// Use this for initialization
	void Start() {
		gameObject.AddComponent<CoffeeMeter> ();

		WorkMeterManager.GetInstance ().OnChange += OnWorkUpdated;
		ForceUpdateGUI ();
		if (coffeCup != null) {
			coffeCup.SetActive (false);
		}
		canMove = true;

	}
	public bool DrinkingCoffe()
	{
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
