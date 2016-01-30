using UnityEngine;
using System.Collections;

public class CoffeeMeter : Meter {

	void Start() {
		Value = 50.0f;
	}

	public override void CalcWork(ref float value) {
		value *= 1.2f;
	}
}
