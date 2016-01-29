using UnityEngine;
using System.Collections;

public class LocationCoffeMaker : Location {

	private float coffeeAvailable;
	private float coffeStartTime;
	private float coffeTime = 5;

	// Use this for initialization
	void Start () {
		coffeeAvailable = 0f;
		coffeStartTime = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		if (coffeStartTime != 0 && (Time.time > coffeStartTime + coffeTime)) 
		{
			coffeeAvailable = 100f;
			coffeStartTime = 0f;
		}
	}

	public override void LocationAction(Character actingCharacter)
	{
		if (coffeeAvailable <= 0f) 
		{
			if (coffeStartTime == 0f)
			{
				//Making coffee
				Debug.Log("Starting coffe Maker");
				coffeStartTime = Time.time;
			}
		} 
		else 
		{
			Debug.Log("Drinking cofee");
			actingCharacter.AddCoffee (20f);
			coffeeAvailable -= 20f;
		}



	}


}
