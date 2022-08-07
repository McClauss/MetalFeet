using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlJugador : MonoBehaviour
{
    //Variables para Movimiento Estandar
    public float velocidadM=2.0f;//Velocidad Movimiento
    public float velocidadR=200.0f;//Velocidad Rotacion
    public float x,y;//Para obtener movimiento en ejes x,y

    private Animator anim;//Para animación Jugador
    public Animator animEnemigo;//Para animación Enemigo

    //Variables para manejo de Salto
    public Rigidbody rb;
    public float fuerzaSalto=5f;
    public bool puedeSaltar;

    //Variables para manejo de agachado
    public float velocidadParado;
    public float velocidadAgachado;

    //Variables para manejo de golpes recibidos
    bool estaGolpeado=false;
    
    //Variables para Temporizador
    float tiempoRestante=0;
    float tiempo=0;

    void Start()
    {
        puedeSaltar=false;
        anim=GetComponent<Animator>();//Para traer valores del animador del personaje
        //animEnemigo=GetComponent<Animator>();//Para traer valores del animador del enemigo1

        velocidadParado=velocidadM;
        velocidadAgachado=velocidadM*0.5f;
    }

    void FixedUpdate(){
        transform.Rotate(0,x*Time.deltaTime*velocidadR,0);//Rotar
        transform.Translate(0,0,y*Time.deltaTime*velocidadM);//Moverse
    }
    void Update()
    {
        Animar();
        ConsultarM();
    }

    void Mover(){
    }

    void Animar(){
        anim.SetFloat("VelX",x);
        anim.SetFloat("VelY",y);
    }

    void ConsultarM(){
        x=Input.GetAxis("Horizontal");        
        y=Input.GetAxis("Vertical");

        if(puedeSaltar==true){
            Saltar();
            Agachar();
            RecibirGolpeB();
            anim.SetBool("tocaSuelo",true);
        }
        else{
            EstaCayendo();
        }
    }

    void EstaCayendo(){
        anim.SetBool("tocaSuelo",false);
        anim.SetBool("salto",false);
    }

    void Saltar(){
        if(Input.GetKeyDown(KeyCode.Space)){
            anim.SetBool("salto",true);
            rb.AddForce(new Vector3(0,fuerzaSalto,0),ForceMode.Impulse);
        }
    }
    void Agachar(){
        if(Input.GetKey(KeyCode.LeftControl)){
            anim.SetBool("agachado",true);
            velocidadM=velocidadAgachado;
        }
        else{
            anim.SetBool("agachado",false);
            velocidadM=velocidadParado;
        }
    }

    void RecibirGolpeB(){
        if(estaGolpeado==true){
            anim.SetBool("golpeBajo",true);
            estaGolpeado=false;
        }
        else
        {
            tiempo=Temporizador(1);
            if(tiempo==0){
                anim.SetBool("golpeBajo",false);
            }
        }
    }

    //Método para detectar impactos de lanza
    void OnTriggerEnter(Collider col){
        if(col.transform.gameObject.tag == "Lanza"){
            estaGolpeado=true;
        }else if(col.transform.gameObject.name == "SpotNv1_2"){
            animEnemigo.SetBool("abreBrazos",true);
        }
    }

    //Temporizador
    float Temporizador(float tiempoLimite){
        tiempoRestante += Time.deltaTime;//Contador en ascenso
        if(tiempoRestante>=tiempoLimite){
            tiempoRestante=0;
            return tiempoRestante;
        }
        else{
            return tiempoRestante;
        }
    }
}
