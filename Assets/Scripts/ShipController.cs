using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShipController : MonoBehaviour {

	List<GameObject> attitudeControllers;
	Rigidbody2D physicsBody;

	// Use this for initialization
	void Start () {
		attitudeControllers = new List<GameObject>();
		physicsBody = GetComponent<Rigidbody2D>();

		physicsBody.AddTorque(10000);

		foreach (Transform child in transform) {
			if (child.gameObject.name == "Attitude") {
				attitudeControllers.Add(child.gameObject);
			}
		}
	}

	// Update is called once per frame
	void Update () {
		foreach (GameObject attitude in attitudeControllers) {
			Debug.DrawLine(attitude.transform.position, attitude.transform.position + attitude.transform.TransformDirection(attitude.transform.InverseTransformDirection(attitude.transform.up)) * -16, Color.red);
		}
	}

	void FixedUpdate() {
		Stabilize();
	}

	void Stabilize() {
		if (physicsBody.angularVelocity > 0) {
			physicsBody.AddTorque(-10.5f);
		} else if (physicsBody.angularVelocity < 0) {
			physicsBody.AddTorque(10.5f);
		}

		if (Mathf.Abs(physicsBody.angularVelocity) < 1f) {
			physicsBody.angularVelocity = 0;
		}
	}
}
