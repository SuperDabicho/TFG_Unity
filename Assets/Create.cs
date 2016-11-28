using UnityEngine;
using System.Collections;
using System.IO;

public class Create : MonoBehaviour {
	public string config1;
	public int n;
	private GameObject[] pregs;
	private GameObject[] resps;

	// Use this for initialization
	void Start () {
		FileInfo config = new FileInfo ("Assets/"+config1);
		pregs = new GameObject[n];
		resps = new GameObject[n];
		for(int i=0; i<n; i++){
			pregs [i] = new GameObject ("Pregunta"+i.ToString());
			resps [i] = new GameObject ("Respuesta"+i.ToString());
			//add components
			pregs[i].AddComponent<TextMesh>();
		}
		StreamReader reader = config.OpenText ();
		string texto;
		do {
			texto = reader.ReadLine ();
			print (texto);
		} while(texto != null);

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

// 11,6 -8,45 -17,53
