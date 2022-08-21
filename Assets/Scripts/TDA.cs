using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TDA : MonoBehaviour
{
    public GameObject arma;
    string tag;

    //Arrays para Orbes (Esferas de Salud)
    public GameObject[] orbes;
    public GameObject[] orbesJugador=new GameObject[5];
    int i;
    bool recogeOrbe;
    int contadorOrbes;

    //Lista para habilidades del Jugador
    public List<string> habilidades=new List<string>();
    public List<string> habilidadesJugador=new List<string>();
    bool banderaCuracion;
    int j;

    //Dictionary para inventario de armas (daño,nombre)
    public Dictionary<int,string> armas = new Dictionary<int,string>();
    public Dictionary<int,string> armasJugador = new Dictionary<int,string>();
    bool recogeArma;

    //Queue(Colas)FIFO
    Queue apellidos = new Queue();

    //Stack(Pilas)LIFO
    Stack nombres = new Stack();

    void Start()
    {
        //inicio array Orbes
        IniciaOrbes();

        //inicio lista de habilidades
        IniciaHabilidades();

        //inicio diccionaio de armas
        IniciaArmas();

        /*
        //Para Llenar la Queue
        apellidos.Enqueue("Hernandez");
        apellidos.Enqueue("Calderon");
        //Para sacar elemento de la Queue
        apellidos.Dequeue();
        //Para mostrar elemento de la Queue
        apellidos.Peak();
        */

        /*
        //Para llenar Stack
        nombres.Push("Claudio");
        nombres.Push("Marcel");
        //Para sacar del Stack
        nombres.Pop();
        //Para mostrar elemento del Stack
        nombres.Peak();

        */
    }

    void Update()
    {
        if(recogeOrbe==true){
            SumaOrbe();
        }
        if(recogeArma==true){
            SumaArma();
        }
    }

    void OnTriggerEnter(Collider col){
        if(col.transform.gameObject.tag == "Orbe"){
            tag=col.transform.gameObject.tag;
            recogeOrbe=true;
        }
        if(col.transform.gameObject.tag == "Hacha Corta"){
            tag=col.transform.gameObject.tag;
            recogeArma=true;
        }
    }


    //Gestión Orbes Salud
    void IniciaOrbes(){
        i=0;
        recogeOrbe=false;
        banderaCuracion=false;
        
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

    //Gestión Habilidades
    void IniciaHabilidades(){
        habilidades.Add("Curacion");
        habilidades.Add("Fuerza");
        habilidades.Add("Estamina");
        habilidades.Add("Velocidad");
        j=0;
        Debug.Log("Habilidades disponibles: "+habilidades.Count);//trae longitud de la lista
    }

    void SumaHabilidad(){
        for (int ind=0;ind<habilidadesJugador.Count;ind++){
            if(habilidadesJugador[ind]=="Curacion"){
                Debug.Log("Ya tienes la habilidad: "+habilidadesJugador[ind]);
                banderaCuracion=false;
            }else{
                /*habilidadesJugador.Add("Curacion");*/
                for(int jnd=0;jnd<habilidades.Count;jnd++){
                    if(habilidades[jnd]=="Curacion"){
                        habilidadesJugador.Insert(j,habilidades[jnd]);        
                        Debug.Log("Habilidad: "+habilidadesJugador[j]+" activada!");
                        j++;
                        banderaCuracion=false;       
                    }
                }
            }
        }
    }
    void RestaHabilidad(){
        habilidadesJugador.RemoveAt(j);//para Borrar un dato de la lista en X posición
    }
    void LimpiaHabilidades(){
        habilidadesJugador.Clear();//borra todos los elementos de la vista
    }

    //Gestión Armas
    void IniciaArmas(){
        recogeArma=false;
        armas.Add(1,"Manos");
        armasJugador.Add(1,"Manos");
        armas.Add(2,"Hacha Corta");
        armas.Add(3,"Espada Corta");
        armas.Add(4,"Hacha Larga");
        armas.Add(5,"Mandoble");
        armas.Add(6,"Arco");
    }

    void SumaArma(){
        armasJugador.Add(2,"Hacha Corta");
        arma.SetActive(false);
        Debug.Log("Arma: "+armasJugador[2]+" recogida!");
        recogeArma=false;
    }
}
