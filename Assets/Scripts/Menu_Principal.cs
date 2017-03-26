using UnityEngine;
using System.Collections;

public class Menu_Principal : MonoBehaviour 
{
	public void Iniciar(int nivel)
	{
		Application.LoadLevel (nivel);
	}
	public void Salir()
	{
		Application.Quit ();
		Debug.Log ("El juego ha salido");
	}
}
