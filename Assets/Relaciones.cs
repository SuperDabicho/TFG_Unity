using UnityEngine;
using System.Collections;
using System.Collections.Generic;


[System.Serializable]
public class Relaciones
{

    public string[] respuestas;
    public string[] preguntas;

	public Relaciones()
	{
        System.IO.StreamReader file = new System.IO.StreamReader("./Assets/PartidaGuardada.json");
        string json = file.ReadToEnd();
        JsonUtility.FromJsonOverwrite(json, this);
	}
}
