using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public static GameManager instance = null;
	private BoardManager boardManager; 

	void Awake () {
		// Enforce singleton-ness
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);

		boardManager = GetComponent<BoardManager> ();
		boardManager.SetupScene ();
	
	}
}
