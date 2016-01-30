using UnityEngine;
using System.Collections;

public abstract class Meter : MonoBehaviour {

	// Not sure if we want this to change, shouldn't be to hard now.
	public const float MaxValue = 100.0f;
	public const float MinValue = 0.0f;

	// Start value should depend on what type of meter we have,
	// for example coffee might start at a higher value.
	public const float StartValue = 0.0f;


	public float Value;

	void Start() {
		Value = StartValue;
	}

	public void Add (float value) {
		Value += value;
		Value = Mathf.Clamp (Value, MinValue, MaxValue);
	}

	public void Remove (float value) {
		Value -= value;
		Value = Mathf.Clamp (Value, MinValue, MaxValue);
	}

	public abstract void CalcWork(ref float value);
}
