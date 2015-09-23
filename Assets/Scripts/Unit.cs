using UnityEngine;
using System.Collections;

public class Unit : MonoBehaviour {

	public Sprite selectedSprite;
	public Sprite unselectedSprite;
	public int movementRange;

	private SpriteRenderer spriteRenderer;
	private bool isSelected;

	void OnMouseUpAsButton() {
		UpdateAppearance (true);
	}

	public void UpdateAppearance (bool selected) {
		isSelected = selected;
		spriteRenderer.sprite = selected ? selectedSprite : unselectedSprite;
	}

	bool isInMovementRange(Vector3 pos) {
		Debug.Log (Vector3.Distance (pos, transform.position));
		return Vector3.Distance (pos, transform.position) <= movementRange;
	}

	// Use this for initialization
	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		// Left click moves unit if selected
		if (Input.GetMouseButtonDown (0) && isSelected) {

			Vector3 newPos = Camera.main.ScreenToWorldPoint (Input.mousePosition);

			if (isInMovementRange(newPos)) {
				transform.position = new Vector3 (newPos.x, newPos.y, 0f);
			}
		
		// Right click deselects unit
		} else if (Input.GetMouseButtonDown (1)) {
			UpdateAppearance (false);
		}
	}
}
