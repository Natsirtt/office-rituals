using UnityEngine;

public abstract class DepletingMeter : Meter
{
    [Range(MinValue, MaxValue)]
    public float amountDepletedPerSecond = 2.5f;

	public bool DepEnabled = true;

	// Update is called once per frame
	void Update () {
		if (DepEnabled) {
			Remove(amountDepletedPerSecond * Time.deltaTime);
		}
	}
}
