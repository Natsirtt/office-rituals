using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {

	public GameObject GUI;

    private Location previousLocation;

    [SerializeField]
    private float moveSpeed = 1.0f;
    private Vector3 moveVector = Vector3.zero;

	// Use this for initialization
	void Start() {
		gameObject.AddComponent<CoffeeMeter> ();

		WorkMeterManager.GetInstance ().OnChange += OnWorkUpdated;

		ForceUpdateGUI ();
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

			GUI.GetComponent<GUI> ().CoffeeSlider.value = coffeeComponent.Value / 100.0f;
		}
    }
}
