using UnityEngine;
using System.Collections;

public class Unit : MonoBehaviour {

	public BoardManager boardManager;

	void OnMouseUpAsButton() {
		// Notify boardManager
		boardManager.WasSelected (this);
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
