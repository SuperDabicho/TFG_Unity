using UnityEngine;
using System.Collections;

public class Primerobjeto : MonoBehaviour {
	//store gameObject reference

	public string[] respuestas= new string[4]{"C","C++", "Java", "C#"};
	public string[] preguntas= new string[4]{"Lenguaje usado en EDA",
		"Es como el sexo anal",
		"Deberiamos saber mucho \nmas de este para el TFG",
		"Lenguaje a casi bajo nivel \nen el que se programan lo S.O."};
	public string[] soluciones = new string[4]{"C++", "Java", "C#", "C"};

	GameObject [] resp;
	GameObject [] preg;
	GameObject [] sol;

	void Start()
	{
		
		preg=new GameObject[preguntas.Length];
		resp=new GameObject[respuestas.Length];
		sol = new GameObject[soluciones.Length];
		//spawn object
		for(int i=0;i<preguntas.Length;i++){
			preg [i] = new GameObject("Pregunta"+i.ToString());
			preg [i].AddComponent<TextMesh> ();
			preg [i].GetComponent<TextMesh> ().text = preguntas [i];
			preg [i].AddComponent<BoxCollider2D>();
			preg [i].GetComponent<BoxCollider2D> ().isTrigger = true;
			preg [i].transform.position = new Vector3 (-13,(-5*i)+9, 0);
			sol [i] = new GameObject ("Solucion" + i.ToString ());
			sol [i].AddComponent<TextMesh> ();
			sol [i].GetComponent<TextMesh> ().text = soluciones [i];
			sol [i].GetComponent<TextMesh> ().color = new Color (0, 0, 0, 0);
			sol [i].transform.parent = preg [i].transform;
		}
		for (int i = 0; i < respuestas.Length; i++) {
			resp [i] = new GameObject("Respuesta"+i.ToString());
			resp [i].AddComponent<TextMesh> ();
			resp [i].GetComponent<TextMesh> ().text = respuestas [i];
			resp [i].transform.position = new Vector3 (11,(-5*i)+9, 0);
			resp [i].AddComponent<Rigidbody2D> ();
			resp [i].GetComponent<Rigidbody2D> ().gravityScale = 0;
			resp [i].AddComponent<BoxCollider2D>();
			resp [i].GetComponent<BoxCollider2D> ().isTrigger = true;
			resp [i].AddComponent<TodoPoderoso>();
		}


	}



}