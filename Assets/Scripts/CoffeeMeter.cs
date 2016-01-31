public class CoffeeMeter : DepletingMeter {

	void Start() {
		Value = 50.0f;
	}

	public override void CalcWork(ref float value) {

		if (this.Value == 0.0f) {
			value *= 0.15f;
		} 
		else if (this.Value >= 100.0f) {
			value *= 10.0f;
		} else if (this.Value >= 80.0f) {
			value *= 1.2f;
		} else if (this.Value >= 20.0f) {
			value *= 0.8f;
		}

	}
}
