using UnityEngine;
using System.Collections;

public class LocationCoffeMaker : Location {

	private float coffeeAvailable;
	private Time coffeStartTime;
	private float coffeTime = 5;

	// Use this for initialization
	void Start () {
		coffeeAvailable = 0;
		coffeStartTime = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (coffeStartTime != 0 && (Time.time > coffeStartTime + coffeTime)) 
		{
			coffeeAvailable = 100;
			coffeStartTime = 0;
		}
	}

	public override void LocationAction(Character actingCharacter)
	{
		if (coffeeAvailable <= 0f) 
		{
			if (coffeStartTime == 0)
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
