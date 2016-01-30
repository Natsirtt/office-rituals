using UnityEngine;

public class Character : MonoBehaviour {

	public GameObject GUI;
    public float GuiYOffset = 130f;
    [HideInInspector]
	public int id;

    private Location previousLocation;

    [SerializeField]
    private float moveSpeed = 1.0f;
    private Vector3 moveVector = Vector3.zero;

	private bool canMove;
	private float lastCoffeDrink;
	public float coffeeDrinkTime = 5;
    public float coffeeEarnedFromCup = 75f;

	public GameObject coffeCup;

	private bool hasCoffeCup;

	public Transform characterModel;

	// Use this for initialization
	void Start() {
		gameObject.AddComponent<CoffeeMeter> ();

        UpdateGUI();

		if (coffeCup != null) {
			coffeCup.SetActive (false);
		}
		canMove = true;
		hasCoffeCup = false;
        GUI.GetComponent<GUI> ().GuiTransform.localPosition = new Vector3(10, -15 - id * GuiYOffset, 0);
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
	private void UpdateGUI() {

		// Unoptimized code, but MEY!
		var guiComp = GUI.GetComponent<GUI> ();

		// Set UserText
		guiComp.SetName("Player " + (id + 1));

		// Set Work 
		var inst = WorkMeterManager.GetInstance();
		guiComp.SetWork(inst.GetWork(this));

		// Set Anger
		guiComp.SetAnger(100.0f);

		// Set Coffee
		var coffeeComponent = GetComponent<CoffeeMeter> ();
		guiComp.SetCoffee (coffeeComponent.Value);
	
		// Set Smoke
		guiComp.SetSmoke(75.0f);

		// Set OCD
		guiComp.SetOCD(0.0f);
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
			Vector3 rotateVector = moveVector*1000;
			rotateVector.y = 1;
			characterModel.transform.LookAt (rotateVector);
		}

        moveVector = Vector3.zero;
        UpdateGUI();
	}
    
    public void SetLocation(Location location) {
        previousLocation = location;
    }

    public void DoLocationAction() {
        
		if (hasCoffeCup) 
		{
			AddCoffee(coffeeEarnedFromCup);
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
