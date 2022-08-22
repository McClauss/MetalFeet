using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbe : MonoBehaviour
{
    public int valor;
    public string nombre;
    public string habilidad;
    public float peso;
    public float color;

    public void ActivarHabilidad(string nombreO){
        Debug.Log("Habilidad "+nombreO+" Activada!");
    }

    public virtual void DarPista(){
        Debug.Log("Pista: Evita tocar el gas verde!");
    }
}
