using UnityEngine;
using System.Collections;

public class Unit : MonoBehaviour {

	public GameObject range; // The visual representation of the units range
	public Sprite selectedSprite;
	public Sprite unselectedSprite;
	public int movementRange;

	private SpriteRenderer spriteRenderer;
	private bool isSelected;
	private GameObject rangeInstance;

	void OnMouseUpAsButton() {
		UpdateAppearance (true);
	}

	public void UpdateAppearance (bool selected) {
		isSelected = selected;
		spriteRenderer.sprite = selected ? selectedSprite : unselectedSprite;

		rangeInstance.GetComponent<SpriteRenderer>().enabled = selected;
	}

	bool isInMovementRange(Vector3 pos) {
		Debug.Log (Vector3.Distance (pos, transform.position));
		return Vector3.Distance (pos, transform.position) <= movementRange;
	}

	// Use this for initialization
	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer>();

		// Add the range indicator
		rangeInstance = Instantiate (range, transform.position, Quaternion.identity) as GameObject;

		// Scale it to represent the movementRange accurately
		float rangeScale = movementRange * 2;
		rangeInstance.transform.localScale = new Vector3 (rangeScale, rangeScale, 0f);

		UpdateAppearance (false);
	}
	
	// Update is called once per frame
	void Update () {
		// Left click moves unit if selected
		if (Input.GetMouseButtonDown (0) && isSelected) {

			Vector3 newPos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			newPos = new Vector3(newPos.x, newPos.y, 0f);

			if (isInMovementRange(newPos)) {
				transform.position = newPos;
				rangeInstance.transform.position = newPos;
			}
		
		// Right click deselects unit
		} else if (Input.GetMouseButtonDown (1)) {
			UpdateAppearance (false);
		}
	}
}
