using UnityEngine;
using System.Collections;

public class MouseDrag : MonoBehaviour {

	private float xo;
	private float yo;

	void OnMouseDown(){
		xo = Input.mousePosition.x;
		yo = Input.mousePosition.y;
	}

	void OnMouseDrag(){
		Vector2 mouseposition = new Vector2 (Input.mousePosition.x, Input.mousePosition.y);
		Vector2 objPosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);

		transform.position = objPosition;
	}
}
