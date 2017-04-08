using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movements : MonoBehaviour {
    public float moveSpeed = 1f;
    public bool direction=false;
    public float tiempo_cambio;
    private float cont;
    public float change_direction=1;
     
    // Use this for initialization
    void Start () {
        cont = tiempo_cambio / 2;
		
	}
	
	// Update is called once per frame
	void Update () {
        
        if(direction==true)
        {
            //Moves Forward and back along z axis                           //Up/Down
            transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed * change_direction);
        }
        else
        {
            //Moves Left and right along x Axis                               //Left/Right
            transform.Translate(Vector3.right * Time.deltaTime * moveSpeed * change_direction);
        }       
        if(cont>=tiempo_cambio)
        {
            change_direction *= -1;
            cont = 0;
        }
        cont += moveSpeed;
    }
}
