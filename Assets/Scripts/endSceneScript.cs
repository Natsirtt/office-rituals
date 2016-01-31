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

		if (workInst.AllWork.Keys.Count == 0)
			return null; // Should never be called in the actual game

		for (int i = 0; i < workInst.AllWork.Keys.Count; i++) {
			Character key = (Character)workInst.AllWork.Keys.ElementAt(i);
			if (key.id == id)
				return key;
		}
		return null;
	}

	// Use this for initialization
	void Start () {

		for (int i = 0; i < 4; i++) {

			Slider slider = P1Slider;
			switch (i) {
			case 0: slider = P1Slider; break;
			case 1: slider = P2Slider; break;
			case 2: slider = P3Slider; break;
			case 3: slider = P4Slider; break;
			default: continue; // Should never be called
			}

			var background = slider.transform.Find ("Fill Area/Fill");
			var bgImage = background.GetComponent<Image> ();
			bgImage.color = Character.GetColor (i);
		}



		var workInst = WorkMeterManager.GetInstance ();
		var winner = workInst.AllWork.Aggregate((l, r) => l.Value > r.Value ? l : r);

		WinnerText.text = string.Format("Player {0} Won!", winner.Key.id + 1);

		for (int i = 0; i < 4; i++) {
			Character key = FindChar (i);
			if (key == null)
				continue; // If not found then it's at zero anyways

			float value = workInst.GetWork(key) / 100.0f;

			Slider slider = P1Slider;
			switch (i) {
			case 0: slider = P1Slider; break;
			case 1: slider = P2Slider; break;
			case 2: slider = P3Slider; break;
			case 3: slider = P4Slider; break;
			}

			slider.value = value;
		}
	}

	void Update() {
		// TODO: We could probably check the input with the characters, but I guess this works just fine for now.
		for (int i = 0; i <= 11; i++)
		{
			if (i == 0)
			{
				if (Input.GetKeyDown(KeyCode.Space))
				{
					LoadNextScene ();
				}
			}
			else if (Input.GetButtonDown(XBoxController.SecondaryActionPressedDescriptor(i)))
			{
				LoadNextScene ();
			}
		}
	}

	void LoadNextScene() {
		Application.LoadLevel("setupScene");

		// We can unload stuff here!
		WorkMeterManager.GetInstance().AllWork.Clear();
	}
}
