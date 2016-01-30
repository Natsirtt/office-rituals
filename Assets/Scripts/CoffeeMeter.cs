public class CoffeeMeter : DepletingMeter {

	void Start() {
		Value = 50.0f;
	}

	public override void CalcWork(ref float value) {
		value *= 1.2f;
	}
}
