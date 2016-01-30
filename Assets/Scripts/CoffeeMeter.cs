public class CoffeeMeter : DepletingMeter {

	void Start() {
		Value = 50.0f;
	}

	public override void CalcWork(ref float value) {

		if (this.Value == 0.0f) {
			value *= 0.3f;
		} 
		else if (this.Value >= 100.0f) {
			value *= 20.0f;
		} else if (this.Value >= 80.0f) {
			value *= 1.2f;
		} else if (this.Value >= 20.0f) {
			value *= 0.8f;
		}

	}
}
