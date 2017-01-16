using UnityEngine;
using System.Collections;

public class ContoladorPirata : MonoBehaviour {
	private Piratas game= new Piratas();
	// Use this for initialization
	GameObject fraseActual;
	GameObject [] siguientes;
	node actual;
	node[] sig;
	GameObject fondo;
	public Sprite imagenFondo = Resources.Load<Sprite>("taberna");
	GameObject emisor;


	void Start () {
		fraseActual=new GameObject("FraseActual");
		emisor = new GameObject ("Emisor");
		emisor.AddComponent<SpriteRenderer> ();
		emisor.transform.localScale = new Vector3 (10, 10, 0);
		emisor.transform.position = new Vector3 (18,11, 0);
		cambio (0);
		fraseActual.transform.position = new Vector3 (-21,11, 0);
		fondo = new GameObject("Fondo");

		fondo.AddComponent<SpriteRenderer> ();
		fondo.transform.localScale=new Vector3(6, 6, 1);

//		Sprite[] textures = Resources.LoadAll<Sprite> ("Textures");
//		string[] names = new string[textures.Length];
//		for (int i = 0; i < names.Length; i++)
//			names [i] = textures [i].name;
//		imagenFondo = textures[0];




		fondo.GetComponent<SpriteRenderer> ().sprite = imagenFondo;
		fondo.GetComponent<SpriteRenderer> ().sortingOrder = -1;

	}

	void cambio(int n){
		string img = game.speakers[game.nodeAt(n).speaker].img;
		Sprite foto= Resources.Load<Sprite> (img);
		emisor.GetComponent<SpriteRenderer> ().sprite = foto;
		if(n!=0)
			
		for (int i=0; i<actual.outgoing.Length;i++)
			Destroy (siguientes [i]);

		actual = game.nodeAt (n);
		fraseActual.AddComponent<TextMesh> ();
		fraseActual.GetComponent<TextMesh> ().text = actual.text;

		siguientes= new GameObject[actual.outgoing.Length];
		sig = new node[actual.outgoing.Length];
		if (actual.outgoing.Length > 1) {
			for (int i = 0; i < actual.outgoing.Length; i++) {
				sig [i] = game.nodeAt (actual.outgoing [i]);
				siguientes [i] = new GameObject ("Respuesta" + i);
				siguientes [i].AddComponent<TextMesh> ();
				siguientes [i].GetComponent<TextMesh> ().text = i + 1 + "- " + sig [i].text;
				siguientes [i].transform.position = new Vector3 (-16, (-5 * i) + 6, 0);
			}
		} else {
			siguientes [0] = new GameObject ("Respuesta");
			siguientes [0].AddComponent<TextMesh> ();
			siguientes [0].GetComponent<TextMesh> ().text ="Presiona 1 para continuar";
			siguientes [0].transform.position = new Vector3 (-16, 6, 0);

		}
	}
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			cambio(actual.outgoing[0]);
		}
		if (Input.GetKeyDown (KeyCode.Alpha2)) {
			cambio(actual.outgoing[1]);
		}
		if (Input.GetKeyDown (KeyCode.Alpha3)) {
			cambio(actual.outgoing[2]);
		}
		if (Input.GetKeyDown (KeyCode.Alpha4)) {
			cambio(actual.outgoing[3]);
		}
	}


}
