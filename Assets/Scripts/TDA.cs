using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TDA : MonoBehaviour
{
    //Arrays
    public GameObject[] orbes;
    public GameObject[] orbesJugador=new GameObject[10];
    int i;
    bool recogeOrbe;

    //Lista
    public List<string> habilidades=new List<string>();
    public List<string> habilidadesJugador=new List<string>();
    bool banderaCuracion;
    int j;

    void Start()
    {
        //inicio array
        i=0;
        recogeOrbe=false;
        banderaCuracion=false;

        //inicio lista de habilidades
        habilidades.Add("Curacion");
        habilidades.Add("Fuerza");
        habilidades.Add("Estamina");
        habilidades.Add("Velocidad");
        j=0;
        Debug.Log("Habilidades disponibles: "+habilidades.Count);//trae longitud de la lista
    }

    void Update()
    {
        if(recogeOrbe==true){
            SumaOrbe();
        }
    }

    void OnTriggerEnter(Collider col){
        if(col.transform.gameObject.tag == "Orbe"){
            recogeOrbe=true;
        }
    }

    void SumaOrbe(){
        orbesJugador[i]=orbes[i];
        orbes[i].SetActive(false);
        i++;
        GameManager.ModificaVida(10);
        if (banderaCuracion==false){
            SumaHabilidad();
        }
        Debug.Log("Orbe recogido en posición: "+i);
        recogeOrbe=false;
    }

    void SumaHabilidad(){
        /*habilidadesJugador.Add("Curacion");*/
        habilidadesJugador.Insert(j,"Curacion");//inserta en la lista en X posicion
        Debug.Log("Habilidad: "+habilidadesJugador[j]+" activada!");
        j++;
        banderaCuracion=true;
    }
    void RestaHabilidad(){
        habilidadesJugador.RemoveAt(j);//para Borrar un dato de la lista en X posición
    }
    void LimpiaHabilidades(){
        habilidadesJugador.Clear();//borra todos los elementos de la vista
    }
}
