﻿using UnityEngine;
using UnityEngine.UI;

public class GUIContainer : MonoBehaviour {
	
	// User
	public Text UserText;

	// Work
	public Text WorkDoneText;

	// Anger
	public Slider AngerSlider;

	// Coffee
	public Slider CoffeeSlider;

	// Smoke
	public Slider NicotineSlider;

	// OCD
	public Slider OCDSlider;

    // Maybe I will just cheat with this
    public RectTransform GuiTransform;

	public void SetBackground(Color color) {
		var image = GuiTransform.GetComponent<Image>();
		image.color = color;
	}

	public void SetName(string name) {
		this.UserText.text = name;
	}

	public void SetWork(float value) {
		WorkDoneText.text = string.Format("Work: {0:0.00}%", value);
	}

	public void SetAnger(float value) {
		AngerSlider.value = value / 100.0f;
	}

	public void SetCoffee(float value) {
		//WorkDoneText.text = string.Format("Work: {0:0.00}%", inst.GetWork(this));
		CoffeeSlider.value = value / 100.0f;
	}

	public void SetSmoke(float value) {
		this.NicotineSlider.value = value / 100.0f;
	}

	public void SetOCD(float value) {
		this.OCDSlider.value = value / 100.0f;
	}
}
