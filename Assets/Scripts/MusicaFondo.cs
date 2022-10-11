using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicaFondo : MonoBehaviour
{
    public static MusicaFondo instance; //instancia de musicafondo

    //Cada vez que pierdes y se resetea el juego se crea una nueva instancia de musica y se reproducen todas a la vez, para evitar est usamos el if
    private void Awake()
    {
        if(instance == null) //sino hay ninguna instancia de musicafondo
        {
            instance = this; //creo la instancia
        }
        else
        {
            Destroy(gameObject);        //si la hay la destruyo   
        }
        DontDestroyOnLoad(gameObject); //esto hace que cuando se cargue de nuevo el juego, reinicie, no se destruya la musica
    }

}
