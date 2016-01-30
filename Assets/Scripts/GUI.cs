using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GUI : MonoBehaviour {
	public Text WorkDoneText;

	// Coffee
	public Slider CoffeeSlider;

	public void SetCoffee(float value) {
		//WorkDoneText.text = string.Format("Work: {0:0.00}%", inst.GetWork(this));
		CoffeeSlider.value = value / 100.0f;
	}

	public void SetWork(float value) {
		WorkDoneText.text = string.Format("Work: {0:0.00}%", value);
	}
}
