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
    /*public Image star1;
    public Image star2;
    public Image star3;
    public Color redd;*/

    private bool ganar;
	private bool perder;
	// Use this for initialization
	void Start () 
	{
		pelota = GameObject.FindGameObjectWithTag ("Player");
		animador = GetComponent<Animator> ();
        //star1 = GameObject.Find("star1").GetComponent<Image>();
        //star2 = GameObject.Find("star2").GetComponent<Image>();
        //star3 = GameObject.Find("star3").GetComponent<Image>();
        //redd = new Color(159, 111, 111);

    }
	
	// Update is called once per frame
	void Update () 
	{
		ganar = pelota.GetComponent<Pelota> ().ganar;
		perder = pelota.GetComponent<Pelota> ().perder;
        puntuacion = pelota.GetComponent<Pelota> ().puntuacion;
		tiempo = pelota.GetComponent<Pelota> ().tempo;
        

        /*if (tiempo > 5)
        {
            star1.color = redd;
        }*/
         
        textoTiempo.text = ": " + Mathf.Floor(tiempo);

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
