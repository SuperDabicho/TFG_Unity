using UnityEngine;
using System.Collections;
using System.Collections.Generic;


[System.Serializable]
public class Primerobjeto : MonoBehaviour {


	public string[] respuestas= new string[4]{"C++", "Java", "C#","C"};
	public string[] preguntas= new string[4]{"Lenguaje usado en EDA",
		"Es como el sexo anal",
		"Deberiamos saber mucho \nmas de este para el TFG",
		"Lenguaje a casi bajo nivel \nen el que se programan lo S.O."};

	private int correctas=0;

	GameObject victoria;

	void Start()
	{
		bool[] sols = new bool[respuestas.Length];
		for (int a = 0; a < sols.Length; a++) {
			sols [a] = false;
		}
		GameObject [] preg=new GameObject[preguntas.Length];
		GameObject [] resp=new GameObject[respuestas.Length];
		//spawn object
		for(int i=0;i<preguntas.Length;i++){
			preg [i] = new GameObject("Pregunta"+i.ToString());
			preg [i].AddComponent<TextMesh> ();
			preg [i].GetComponent<TextMesh> ().text = preguntas [i];
			preg [i].AddComponent<BoxCollider2D>();
			preg [i].GetComponent<BoxCollider2D> ().isTrigger = true;
			preg [i].transform.position = new Vector3 (-13,(-5*i)+9, 0);
			preg [i].AddComponent<Solucion> ();
			preg [i].GetComponent<Solucion> ().SetSolucion (i);
		}


		for (int i = 0; i < respuestas.Length; i++) {
			bool respondida = true;
			int k = 0;
			while (respondida) {
				k = Random.Range (0, 4);
				respondida = sols [k];
			}
			sols [k] = true;
			resp [i] = new GameObject ("Respuesta" + i.ToString ());
			resp [i].AddComponent<TextMesh> ();
			resp [i].GetComponent<TextMesh> ().text = respuestas [k];
			resp [i].transform.position = new Vector3 (11, (-5 * i) + 9, 0);
			resp [i].AddComponent<Rigidbody2D> ();
			resp [i].GetComponent<Rigidbody2D> ().gravityScale = 0;
			resp [i].AddComponent<BoxCollider2D> ();
			resp [i].GetComponent<BoxCollider2D> ().isTrigger = true;
			resp [i].AddComponent<Solucion> ();
			resp [i].GetComponent<Solucion> ().SetSolucion (k);
			resp [i].AddComponent<TodoPoderoso> ();
		}

		//Crea el panel de victoria
		victoria = new GameObject("PanelVictoria");
		victoria.AddComponent<TextMesh> ();
		victoria.GetComponent<TextMesh>().text = "VICTORIA";
		victoria.GetComponent<TextMesh> ().fontSize = 80;
		victoria.transform.position = new Vector3 (-19,5,0);
		victoria.SetActive (false);

	}

	void Update () {
		for(int j=0; j<4; j++){
			if (preg [j].GetComponent<TextMesh> ().color.Equals(Color.green)) {
				correctas += 1;
			}
		}
		if (correctas == 4) {
			victoria.SetActive (true);
		} else
			correctas = 0;
	}



}
