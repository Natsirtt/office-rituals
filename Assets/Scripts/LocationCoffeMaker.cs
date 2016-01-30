using UnityEngine;
using System.Collections;

public class LocationCoffeMaker : Location {

	private int coffeeAvailable;
	private float coffeStartTime;
	public float coffeTime = 7;
	private TextMesh textMesh;
	private GameObject[] coffePot;
	public AudioClip dripSound;
	public AudioClip readySound;
	public AudioClip drinkSound;

	private AudioSource audioSource;

	// Use this for initialization
	void Start () {
		coffeeAvailable = 0;
		coffeStartTime = 0f;
		coffePot = GameObject.FindGameObjectsWithTag("CoffeePots");
		foreach (GameObject go in coffePot) 
		{
			go.SetActive (false);
		}
		textMesh = GetComponentInChildren<TextMesh> ();
		audioSource = GetComponentInChildren<AudioSource> ();
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
				coffeStartTime = 0f;
				foreach (GameObject go in coffePot) 
				{
					go.SetActive (true);
				}
				coffeeAvailable = coffePot.Length;
				textMesh.text = "";
				audioSource.Stop();
				audioSource.loop = false;
				audioSource.clip = readySound;
				audioSource.Play();
			}
		}
	}

	public override void LocationAction(Character actingCharacter)
	{
		Debug.Log("cofee location");
		if (coffeeAvailable <= 0) 
		{
			if (coffeStartTime == 0f)
			{
				//Making coffee
				Debug.Log("Starting coffe Maker\n"+coffeTime);

				textMesh.text = "Coffee...\n"+coffeTime;
				coffeStartTime = Time.time;
				audioSource.loop = true;
				audioSource.clip = dripSound;
				audioSource.Play();
			}
		} 
		else 
		{
			Debug.Log("Drinking cofee");
			actingCharacter.AddCoffee (20f);
			coffeeAvailable -= 1;
			coffePot[coffeeAvailable].SetActive(false);
			audioSource.loop = false;
			audioSource.clip = drinkSound;
			audioSource.Play();
		}



	}


}
