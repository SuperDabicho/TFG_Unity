using UnityEngine;
using System.Collections;

public class Solucion : MonoBehaviour {
	private int solucion;

	public void SetSolucion(int s){
		this.solucion = s;
	}

	public int GetSolucion(){
		return this.solucion;
	}
}
