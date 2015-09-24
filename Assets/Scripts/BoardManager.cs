using UnityEngine;
using System.Collections;

public class BoardManager : MonoBehaviour {

	public GameObject unit;

	// Currently just creates one unit and adds it to the center of the map
	public void SetupScene() {
		// Place the unit in the center of the Camera
		Vector3 centerPos = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 10f));
		GameObject instance =
			Instantiate (unit, centerPos, Quaternion.identity) as GameObject;


	}
}
