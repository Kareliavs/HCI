using UnityEngine;
using System.Collections;

public class Pelota : MonoBehaviour 
{
	private Rigidbody rigitBody;
	public int velocidad;

	public int puntuacion;
	public int puntuacionMaxima;

	public float temporizador;
	public int temporizadorInt;
	public bool ganar = false;
	public bool perder = false;
	// Use this for initialization
	void Start () 
	{
		rigitBody = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (temporizador <= 0) 
		{
			temporizador = 0;
			perder = true;
			Debug.Log ("Has perdido");
		}
		if (puntuacion < puntuacionMaxima) {
			temporizador -= Time.deltaTime;
			temporizadorInt = (int)temporizador;
		} 
		else 
		{
			ganar = true;
			Debug.Log ("Has ganado");
		}	

		
		Debug.Log("Puntuacion: " +puntuacion+" Tiempo:"+ temporizadorInt);
	}

	void FixedUpdate()
	{
		float horizontal = Input.GetAxis ("Horizontal");
		float vertical = Input.GetAxis ("Vertical");	

		Vector3 movimiento = new Vector3 (horizontal, 0, vertical);

		if (puntuacion >= puntuacionMaxima || temporizador <= 0)
		{
			movimiento = Vector3.zero;
			rigitBody.velocity = Vector3.Lerp (rigitBody.velocity, Vector3.zero, Time.deltaTime);
		}
		rigitBody.AddForce (movimiento * velocidad * Time.deltaTime);
	}

	void Puntuacion()
	{
		puntuacion++;
		//Debug.Log ("Puntuacion: " + puntuacion);
	}

	void OnTriggerEnter(Collider collider)
	{  
		if (collider.tag == "Recolectable" && !perder) 
		{
			Puntuacion ();
			collider.gameObject.SetActive (false);
		}
	}
}
