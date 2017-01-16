using UnityEngine;
using System.Collections;
using System.Collections.Generic;


[System.Serializable]
public class EditarJuego : MonoBehaviour {

	private Relaciones game= new Relaciones();
	public string[] respuestas;
	public string[] preguntas;
	GameObject [] preg;
	GameObject [] resp;
	private int correctas=0;

	GameObject victoria;

	void Start()
	{
		preguntas=game.preguntas;
		respuestas=game.respuestas;
		bool[] sols = new bool[respuestas.Length];
		for (int a = 0; a < sols.Length; a++) {
			sols [a] = false;
		}
		preg=new GameObject[preguntas.Length];
		resp=new GameObject[respuestas.Length];
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
