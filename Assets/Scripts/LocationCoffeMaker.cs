using UnityEngine;
using System.Collections;

public class LocationCoffeMaker : Location {

	private float coffeeAvailable;
	private float coffeStartTime;
	private float coffeTime = 7;
	public TextMesh textMesh;
	public GameObject coffePot;

	// Use this for initialization
	void Start () {
		coffeeAvailable = 0f;
		coffeStartTime = 0f;
		coffePot.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {

		if (coffeStartTime != 0) 
		{
			float remainingCoffeeTime = coffeStartTime + coffeTime - Time.time;
			int printTime = (int)remainingCoffeeTime;
			textMesh.text = "Coffee...\n"+printTime;

			if (remainingCoffeeTime <= 0) 
			{
				coffeeAvailable = 100f;
				coffeStartTime = 0f;
				coffePot.SetActive (true);
				textMesh.text = "";
			}
		}
	}

	public override void LocationAction(Character actingCharacter)
	{
		Debug.Log("cofee location");
		if (coffeeAvailable <= 0f) 
		{
			if (coffeStartTime == 0f)
			{
				//Making coffee
				Debug.Log("Starting coffe Maker\n"+coffeTime);

				textMesh.text = "Coffee...\n"+coffeTime;
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
