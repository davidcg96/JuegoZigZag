using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ruta : MonoBehaviour
{

    public GameObject prefab; // variable dentro de ruta a la que le asignamos un prefab, bloque ruta para construir
    public Vector3 ultimaPosicion; //contiene la posicion del ultimo bloque que he creado, para ello copiar los valores de ese bloque
    public float diferenciaZ=0.71f;
    private int cuentaRuta = 0; 

    public void CrearNuevaParteRuta()
    {
        print("crear parte ruta");
        Vector3 nuevaPosicion=Vector3.zero; //iniciaiza la posicion a 0
        float opcion= Random.Range(0,100); //esto es para saber si es para la izquierda o la derecha
        if(opcion < 50) //50 porciento de probabilidad a izquierda y derecha
        {
            //le asigno la nueva posicion, que se mantiene en la y pero cambia en la x,z y ademas decimos que lo cree a la derecha
            nuevaPosicion = new Vector3(ultimaPosicion.x+diferenciaZ,ultimaPosicion.y, ultimaPosicion.z+diferenciaZ);
        }
        else
        {
            //se crea hacia la izquierda
            nuevaPosicion = new Vector3(ultimaPosicion.x - diferenciaZ, ultimaPosicion.y, ultimaPosicion.z + diferenciaZ);
        }

        GameObject g = Instantiate(prefab, nuevaPosicion,Quaternion.Euler(0,45,0)); //creamos el objeto rotado 45 grados en la nuevaposicion
        ultimaPosicion = g.transform.position; //actualizamos la posicion del bloque

        cuentaRuta++;
        if (cuentaRuta%5==0)
        {
            g.transform.GetChild(0).gameObject.SetActive(true); //caa 5 bloques activo un cristal
        }
    }

    public void IniciarConstruccion()
    {
        InvokeRepeating("CrearNuevaParteRuta", 1f, 0.5f); //llama a la funcion crear nueva parte ruta cada 0.5floats
    }

}
