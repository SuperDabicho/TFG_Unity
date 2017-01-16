using UnityEngine;
using System.Collections;


[System.Serializable]
public class Piratas {
	public Speaker[] speakers;
	public node[] nodes;


	public Piratas(){
		System.IO.StreamReader file = new System.IO.StreamReader("./Assets/piratas.json");
		string json = file.ReadToEnd();
		JsonUtility.FromJsonOverwrite(json, this);
	}

	public node nodeAt(int n){
		for (int i=0; i <nodes.Length;i++){
			if (nodes [i].id==n)
				return nodes [i];
		}
		return null;
	}
}