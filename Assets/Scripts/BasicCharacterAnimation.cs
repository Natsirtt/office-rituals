using UnityEngine;
using System.Collections;

public class BasicCharacterAnimation : MonoBehaviour {

	public bool HasMoved { get; set; }


	public float MaxRotation = 10;

	private Vector3 facing_ = Vector3.right;
	public Vector3 Facing {
		get {
			return this.facing_;
		}
		set {
			this.facing_ = value.normalized;
		}
	}

	public Quaternion FacingQuat {
		get {
			return Quaternion.LookRotation(this.Facing);
		}
	}

	private Quaternion current_facing_;

	private float wiggle_timer_ = 0;
	private Quaternion start_;

	void Start () {
		this.start_ = this.transform.localRotation;
		this.current_facing_ = this.FacingQuat;
	}
	
	// Update is called once per frame
	void Update () {
		this.current_facing_ = Quaternion.RotateTowards(this.current_facing_, this.FacingQuat, 10);
		var base_face = this.start_ * this.current_facing_;
		
		if( HasMoved ) {
			this.wiggle_timer_ += Time.deltaTime * 0.75f;
			while( this.wiggle_timer_ > 1.0f ) this.wiggle_timer_ -= 1.0f;
			var smooth = Mathf.Sin(wiggle_timer_ * 2 * Mathf.PI);
			var a = smooth * 10;
			this.transform.localRotation = base_face * Quaternion.Euler(0, 0, a);
		}
		else {
			this.wiggle_timer_ = 0;
			this.transform.localRotation = base_face;
		}
	}
}
