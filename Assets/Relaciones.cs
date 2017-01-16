using UnityEngine;
using System.Collections;
using System.Collections.Generic;


[System.Serializable]
public class Relaciones
{
	private string ruta;
    public string[] respuestas;
    public string[] preguntas;

	public Relaciones(){
	}
	public Relaciones(string ruta)
	{
		this.ruta = ruta;
        System.IO.StreamReader file = new System.IO.StreamReader(ruta);
        string json = file.ReadToEnd();
        JsonUtility.FromJsonOverwrite(json, this);
	}

	public void guardarPartida(){
		string json = JsonUtility.ToJson (this);
		System.IO.StreamWriter file = new System.IO.StreamWriter(ruta);
	}
}
