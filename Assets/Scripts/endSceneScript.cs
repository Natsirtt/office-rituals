using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class endSceneScript : MonoBehaviour {

	public Slider P1Slider;
	public Slider P2Slider;
	public Slider P3Slider;
	public Slider P4Slider;

	public Text WinnerText;

	Character FindChar (int id) {
		var workInst = WorkMeterManager.GetInstance ();
		for (int i = 0; i < workInst.AllWork.Keys.Count; i++) {
			Character key = (Character)workInst.AllWork.Keys.ElementAt(i);
			if (key.id == id)
				return key;
		}
		return null;
	}

	// Use this for initialization
	void Start () {

		var workInst = WorkMeterManager.GetInstance ();
		var winner = workInst.AllWork.Aggregate((l, r) => l.Value < r.Value ? l : r);

		WinnerText.text = string.Format("Player {0} Won!", winner.Key.id + 1);

		for (int i = 0; i < 4; i++) {
			Character key = FindChar (i);
			if (key == null)
				continue;

			float value = workInst.GetWork(key) / 100.0f;

			Slider slider = P1Slider;
			switch (i) {
			case 0: slider = P1Slider; break;
			case 1: slider = P2Slider; break;
			case 2: slider = P3Slider; break;
			case 3: slider = P4Slider; break;
			}

			UpdateSlider (slider, key, value);
		}
	}

	void UpdateSlider(Slider slider, Character character, float value) {
		//slider.color = character.CharColor;
		slider.value = value;

		var background = slider.transform.Find ("Fill Area/Fill");
		var bgImage = background.GetComponent<Image> ();

		bgImage.color = character.CharColor;

	}
}
