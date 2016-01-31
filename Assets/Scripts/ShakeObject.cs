using UnityEngine;
using System.Collections;

public class ShakeObject : MonoBehaviour {
	Quaternion rot;
	private float ShakeIntensity = 10;
	public float MaxShakeTime = 1;
	float shakeTimer = 0;

	// Use this for initialization
	void Start () {
		this.rot = this.transform.localRotation;
	}

	public void Shake() {
		this.shakeTimer = this.MaxShakeTime;

	}
	
	// Update is called once per frame
	void Update () {
		this.shakeTimer -= Time.deltaTime;
		if( this.shakeTimer < 0 ) this.shakeTimer = 0;

		this.transform.localRotation = this.rot * Quaternion.Euler(this.R(), this.R(), this.R());
	}

	private float R() {
		return Random.Range(-1, 1) * this.shakeTimer * this.ShakeIntensity;
	}
}
