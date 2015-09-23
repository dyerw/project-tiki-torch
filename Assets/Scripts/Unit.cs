using UnityEngine;
using System.Collections;

public class Unit : MonoBehaviour {

	public Sprite selectedSprite;
	public Sprite unselectedSprite;

	private SpriteRenderer spriteRenderer;
	private bool isSelected;

	void OnMouseUpAsButton() {
		UpdateAppearance (true);
	}

	public void UpdateAppearance (bool selected) {
		Debug.Log (selected);
		isSelected = selected;
		spriteRenderer.sprite = selected ? selectedSprite : unselectedSprite;
	}

	// Use this for initialization
	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0) && isSelected) {
			Vector3 newPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			transform.position = new Vector3(newPos.x, newPos.y, 0f);
		}
	}
}
