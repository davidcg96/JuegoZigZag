using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPersonaje : MonoBehaviour
{

    private Rigidbody rb; //cuerpo para controlar la fisica del muñeco
    private bool caminarDerecha = true; //establece si hemos girado la posicion en la que anda el muñeco

    //variables para detectar si el muñeco se ha caido 
    public Transform comienzoRayo; //posicion del rayo de deteccion
    private Animator animator; //variable de animacion

    //variable para el estado del juego
    private GameManager gameManager;

    //objeto para el efecto del cristal
    public GameObject efectoCristal;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>(); //obtenemos el cuerpo del muleco
        animator = GetComponent<Animator>();//inizializar animator
        gameManager=FindObjectOfType<GameManager>();  //busca y asigna el gamemanager
    }

    // Update is called once per frame
    void Update()
    {
        //compruebo si se ha pulsado entre para iniciar el juego
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CambiarDireccion();
        }
        //lanzo un rayo para comprobar si hay algo debajo del personaje y sino cambiar de estado a cayendo
        RaycastHit contacto;
        if (!Physics.Raycast(comienzoRayo.position,-transform.up,out contacto,Mathf.Infinity)) //si no hay algo debajo, posicion_comienzo, rayo hacia abajo, valor devuelto y raoy infinito
        {
            animator.SetTrigger("cayendo");
        }
        // miro si me he caido para reiniciar
        if(transform.position.y < -2)
        {
            gameManager.FinalizarJuego();
        }
        
    }

    private void FixedUpdate()
    {
        //primero miramos si el juego se ha iniciado
        if (!gameManager.juegoIniciado)
        {
            return;
        }
        else
        {
            animator.SetTrigger("ComienzoJuego");
        }
        //esto hace que el muñeco avance, deltatime es el tiempo que ha tardado en recorre el cuadro anterior
        rb.transform.position = transform.position + transform.forward * 2 * Time.deltaTime;

    }
    //cambio de posicion de 45 a -45
    private void CambiarDireccion()
    {
        if (!gameManager.juegoIniciado)
        {
            return;
        }
        caminarDerecha =!caminarDerecha; //me cambia de true a false y de false a true
        if (caminarDerecha) //si estaba caminando hacia la derecha
        {
            transform.rotation= Quaternion.Euler(0, 45, 0);//rota hacia la izquierda
        }
        else 
        {
            transform.rotation = Quaternion.Euler(0, -45, 0);//rota hacia la derecha
        }
    }

    //cuando choca con el cristal
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "cristal")
        {           
            gameManager.AumentarPuntaje(); //subimo puntuacion
            // esto hace que se cree efecto de cristal en la posicion del jugador sin rotacion
            GameObject g= Instantiate(efectoCristal, comienzoRayo.transform.position,Quaternion.identity);
            Destroy(g,2);//elimina el efecto del cristala pasados 2 segundos que coincide con el parametro de efectocristal
            Destroy(other.gameObject); //eliminamos el cristal
        }
    }
}
