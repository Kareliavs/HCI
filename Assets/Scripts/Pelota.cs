using UnityEngine;
using System.Collections;

public class Pelota : MonoBehaviour
{
    private Rigidbody rigitBody;
    

    public int puntuacion;
    public int puntuacionMaxima;

    public float temporizador;
    public int temporizadorInt;
    public bool ganar = false;
    public bool perder = false;

    public float tempo;
    public int tiempo_limite = 30;
    public float vel_crecimiento = 0.05f;
    // Use this for initialization
    void Start()
    {
        rigitBody = GetComponent<Rigidbody>();
        tempo = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (tempo > tiempo_limite)
        {
            perder = true;
        }
        if (tempo < tiempo_limite)
        {
            tempo += Time.deltaTime;

            Vector3 scale = transform.localScale;
            float tam = (float)(0.5 + tempo * vel_crecimiento);
            scale.Set(tam, tam, tam);
            transform.localScale = scale;
        }
        
       
    }

    void FixedUpdate()
    {

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
            ganar = true;
            collider.gameObject.SetActive(false);
        }
    }
}
