using UnityEngine;
using System.Collections;
using UnityEngine.UI; 
public class ControladorJuego : MonoBehaviour 
{
	public Text textoPuntuacion;
	public Text textoTiempo;

	public int puntuacion;
	public float tiempo;

	public GameObject pelota;
	private Animator animador;

	private bool ganar;
	private bool perder;
	// Use this for initialization
	void Start () 
	{
		pelota = GameObject.FindGameObjectWithTag ("Player");
		animador = GetComponent<Animator> ();

	}
	
	// Update is called once per frame
	void Update () 
	{
		ganar = pelota.GetComponent<Pelota> ().ganar;
		perder = pelota.GetComponent<Pelota> ().perder;

		puntuacion = pelota.GetComponent<Pelota> ().puntuacion;
		tiempo = pelota.GetComponent<Pelota> ().tempo;

		textoPuntuacion.text = "Puntuacion: " + puntuacion;
		textoTiempo.text = "Tiempo: " + Mathf.Floor(tiempo);

		animador.SetBool ("Ganar", ganar);
		animador.SetBool ("Perder", perder);
	}
	public void ActivarPelota()
	{
		pelota.GetComponent<Pelota> ().enabled = true;
	}
	public void CambiarNivel(int nivel)
	{
		Application.LoadLevel (nivel);
	}
}
