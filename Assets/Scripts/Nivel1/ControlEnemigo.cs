using UnityEngine;

public class ControlEnemigo : MonoBehaviour
{

    //Atributos Enemigo
    int vida=50;
    int fuerza=10;
    int nivel= 1;

    //Animador Enemigo
    public Animator anim;

    //Para manejo de animación muerte
    bool estaMuerto=false;
    
    //Para seguimiento de jugador
    public Transform posJugador;
    public float speedE = 1.025f;
    public float distanciaTopeOb=4f;
    public float distanciaTopeAt=2f;
    
    public enum TipoAccion{
        seguir,
        observar,
        atacar
    }
    public TipoAccion accionEnemigo;
    
    void Start()
    {
        anim=GetComponent<Animator>();
        accionEnemigo=TipoAccion.observar;
    }

    void FixedUpdate(){
        //transform.Rotate(0,x*Time.deltaTime*velocidadR,0);//Rotar
        //transform.Translate(0,0,y*Time.deltaTime*velocidadM);//Moverse
    }

    // Update is called once per frame
    void Update()
    {
        LeeTipoAccion();
    }

    //Funcion para Ver Tipo de Ataque Seteado en Inspector
    void LeeTipoAccion(){
        switch(accionEnemigo){
            case TipoAccion.seguir:
            SeguirJugador();
            break;
            case TipoAccion.observar:
            ObservarJugador();
            break;
            default:
            ObservarJugador();
            break;
        }
    }

    //Función para observar a jugador
    void ObservarJugador(){
        //transform.LookAt(posEnemigo);
        transform.LookAt(Vector3.Lerp(transform.position,posJugador.position,speedE* Time.deltaTime));
    }

    //Funcion para seguir jugador hasta una distancia
    void SeguirJugador(){
        float distancia=Vector3.Distance(transform.position,posJugador.position);//mide distancia entre posicion vs posicion dos
        Debug.Log("Distancia Medida Enemigo: "+gameObject.tag+" es: "+distancia);
        if (distancia>distanciaTopeOb){
           transform.position = Vector3.Lerp(transform.position,posJugador.position,speedE* Time.deltaTime);
           ObservarJugador();
        }
        else{
            ObservarJugador();
        }
    }
}
