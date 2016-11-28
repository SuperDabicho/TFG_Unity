using UnityEngine;
using System.Collections;

public class TodoPoderoso : MonoBehaviour {

	private GameObject fondo;

	// Use this for initialization
	void Start () {
		//fondo = this.gameObject;
	}

	void OnMouseDown(){
		Debug.Log (this.name);
		Cursor.visible = false;
		transform.GetComponent<TextMesh> ().fontStyle = FontStyle.Bold;
	}
	void OnMouseUp(){
		Cursor.visible = true;
		transform.GetComponent<TextMesh> ().fontStyle = FontStyle.Normal;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDrag(){
		Vector3 mouseposition = new Vector3 (Input.mousePosition.x, Input.mousePosition.y);
		Vector3 objPosition = Camera.main.ScreenToWorldPoint (mouseposition);
		objPosition.z = 0;

		transform.position = objPosition;
	}
	//fondo.GetComponent<Renderer>().material.color = new Color(255, 0, 0);

	void OnTriggerEnter2D(Collider2D other){
		if (comprobar (other)) {
			Debug.Log ("CORRECTO!!");
			transform.GetComponent<TextMesh>().color = new Color(0, 255, 0);
			other.transform.GetComponent<TextMesh>().color = new Color(0, 255, 0);
		} else {
			transform.GetComponent<TextMesh>().color = new Color(255, 0, 0);
			Debug.Log ("ERROOOR!!");
		}
	}

	void OnTriggerExit2D(Collider2D other){
		transform.GetComponent<TextMesh> ().color = Color.white;
		other.transform.GetComponent<TextMesh> ().color = Color.white;
	}

	bool comprobar(Collider2D other){
		string correcta = other.transform.GetChild(0).transform.GetComponent<TextMesh>().text;
		string prueba = transform.GetComponent<TextMesh>().text;
		Debug.Log (correcta + " " + prueba);
		return (correcta.Equals(prueba));
	}
}
