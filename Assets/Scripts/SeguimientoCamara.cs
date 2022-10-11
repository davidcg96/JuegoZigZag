using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeguimientoCamara : MonoBehaviour
{

    public Transform objetivo; //para almacenar los datos de ubicacion del personaje
    private Vector3 diferencia; //la diferencia entre la camara y el personaje

    void Awake() //se ejecuta cuando inicia
    {
        diferencia = transform.position-objetivo.position; //posicion camara - posicion personaje
    }

    //actualiza cada frame pero solo si hah camobios
    private void LateUpdate()
    {
        transform.position = objetivo.position+diferencia; //ubicacion de la camara en cada frame, es donde estaba, mas la diferencia
    }

}
