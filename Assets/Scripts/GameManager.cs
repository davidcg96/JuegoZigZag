using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public bool juegoIniciado; //variable para saber si el juego ha empezado

    public int puntaje; //puntuacion

    public Text textoPuntaje; //texto de la puntuacion
    public Text puntajeMaximoTexto; //texto del record de puntuacion

    private void Awake()
    {
        //OBTENER PUNTAJE MAXIMO
        puntajeMaximoTexto.text="Mejor "+ ObtenerPuntajeMaximo().ToString(); //MUESTRA EL RECORD
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            IniciarJuego();
        }
    }
    public void IniciarJuego()
    {
        juegoIniciado = true; //el juego ha empezado
        FindObjectOfType<Ruta>().IniciarConstruccion();
    }
    public void FinalizarJuego()
    {
        //reinicia juego
        SceneManager.LoadScene(0); //reiniciamos al caer
    }

    public void AumentarPuntaje()
    {
        puntaje++;      //aumenta puntuacion al cojer cristales
        textoPuntaje.text = puntaje.ToString();//cambiamos el texto de la puntuacion

        //si la puntuacion que obtengo es mayor que el record, actualizo el playerpref que es el que guarda y el texto de la pantalla
        if (puntaje > ObtenerPuntajeMaximo())
        {
            PlayerPrefs.SetInt("PuntajeMaximo",puntaje);
            puntajeMaximoTexto.text ="Mejor "+ puntaje.ToString();
        }
    }

    // metodo que obtiene el record
    public int ObtenerPuntajeMaximo()
    {
        //PlayerPrefs, guarda lo ocurrido en las sesiones pasadas
        int i = PlayerPrefs.GetInt("PuntajeMaximo");
        return i;
    }

}
