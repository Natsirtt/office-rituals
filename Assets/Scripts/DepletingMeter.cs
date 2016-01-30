using UnityEngine;

public abstract class DepletingMeter : Meter
{
    [Range(MinValue, MaxValue)]
    public float amountDepletedPerSecond = 2.5f;

	// Update is called once per frame
	void Update () {
	    Remove(amountDepletedPerSecond * Time.deltaTime);
	}
}
