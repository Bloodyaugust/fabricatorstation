using UnityEngine;
using System.Collections;

public class TestController : MonoBehaviour {

	public GameObject shipPrefab;

	// Use this for initialization
	void Start () {
		float screenX;
		float screenY;
		Vector3 newPoint;

		for (int i = 0; i < 0; i++) {
			screenX = Random.Range(0.0f, Camera.main.pixelWidth);
			screenY = Random.Range(0.0f, Camera.main.pixelHeight);
			newPoint = Camera.main.ScreenToWorldPoint(new Vector3(screenX, screenY, 10));

			Instantiate(shipPrefab, newPoint, Quaternion.identity);
		}
	}

	// Update is called once per frame
	void Update () {

	}
}
