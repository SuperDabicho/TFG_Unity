using UnityEngine;
using System.Collections;

public class Comprobar : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	void OnCollisionEnter2D(Collision2D other){
//		if (comprobar (other)) {
//			Debug.Log ("CORRECTO!!");
//		} else {
//			Debug.Log ("ERROOOR!!");
//		}
	}

	void OnCollisionStay2D(Collision2D other){
		if (comprobar (other)) {
			Debug.Log ("CORRECTO!!");
			other.transform.GetComponent<SpriteRenderer>().color = new Color(250, 250, 250);
		} else {
			Debug.Log ("ERROOOR!!");
		}
	}

	// Update is called once per frame
	void Update () {
	
	}

	bool comprobar(Collision2D other){
		Debug.Log ("crash!" + other);
		string correcta = other.transform.GetChild(0).transform.GetComponent<TextMesh>().text;
		string prueba = this.gameObject.transform.GetChild(0).transform.GetComponent<TextMesh>().text;
		Debug.Log (correcta + "" + prueba);
		return (correcta.Equals(prueba));
	}
}
