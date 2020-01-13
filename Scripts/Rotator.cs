using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour {
	public float speed = .1f;

	void Update () {
		float dt = Time.deltaTime;
		transform.Rotate (
			0,
			speed * dt,
			0);
	}
}
