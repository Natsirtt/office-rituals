using UnityEngine;

public class Character : MonoBehaviour {

	public Color CharColor;

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
	public GameObject cig;

	private bool hasCoffeCup;

	public Transform characterModel;

	private BasicCharacterAnimation moveAnimator = null;

	// Use this for initialization
	void Start() {
		gameObject.AddComponent<CoffeeMeter> ();
		gameObject.AddComponent<SmokeMeter> ();

		CharColor = Color.red;

		moveAnimator = this.GetComponentInChildren<BasicCharacterAnimation>();

        UpdateGUI();

		if (coffeCup != null) {
			coffeCup.SetActive (false);
		}
		if (cig != null) {
			cig.SetActive (false);
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
	public static Color GetColor(int index) { // TODO: Tryout all the colors properly!
		switch (index) {
		case 0: return Color.red;
		case 1: return Color.green;
		case 2: return new Color(75, 206, 250); // light blue
		case 3: return Color.yellow;
		default: return Color.white; // should never be used
		}
	}
	private bool guiInit = false;
	private void UpdateGUI() {

		if (GUI == null) {
			return;
		}

		// Unoptimized code, but MEY!
		var guiComp = GUI.GetComponent<GUIContainer> ();

		if (!guiInit) {
			guiComp.GuiTransform.localPosition = new Vector3(10, -15 - id * GuiYOffset, 0);
			guiInit = true;
		}

		this.CharColor = GetColor (id); // :)
		guiComp.SetBackground(this.CharColor);

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
		var smokeComponent = GetComponent<SmokeMeter> ();
		guiComp.SetSmoke(smokeComponent.Value);

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
		bool moved = false;
		if (canMove) 
		{
			moveVector += new Vector3 (v.x, 0, v.y) * moveSpeed;
			if( moveVector.sqrMagnitude > 0.1f ) {
				moved = true;
			}
		}

		moveAnimator.HasMoved = moved;
    }
	
	// Update is called once per frame
	void Update() {
        transform.Translate(moveVector * Time.deltaTime);

		if (characterModel != null && moveVector != Vector3.zero) {
			Vector3 rotateVector = moveVector*1000;
			rotateVector.y = 1;
			// characterModel.transform.LookAt (rotateVector);
			moveAnimator.Facing = rotateVector;
		}

        moveVector = Vector3.zero;
        UpdateGUI();
	}
    
    public void SetLocation(Location location) {
        if (location == null)
        {
            Debug.Log("Exited location");
        }
        else
        {
            Debug.Log("Entered " + location.name);
        }
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

	public void StartSmoke()
	{
		cig.SetActive (true);
	}
	public void EndSmoke(float value)
	{
		var smokeComponent = GetComponent<SmokeMeter> ();
		if (smokeComponent != null) {
			smokeComponent.Add (value);

			GUI.GetComponent<GUIContainer> ().SetSmoke(smokeComponent.Value);
		}
		cig.SetActive (false);
	}

    public void AddCoffee(float value) {
		lastCoffeDrink = Time.time;

		var coffeeComponent = GetComponent<CoffeeMeter> ();
		if (coffeeComponent != null) {
			coffeeComponent.Add (value);
			Debug.Log ("Current Coffee: " + coffeeComponent.Value);

			GUI.GetComponent<GUIContainer> ().SetCoffee(coffeeComponent.Value);
		}
    }
}
