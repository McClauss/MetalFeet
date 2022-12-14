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

    bool enemigoBrazos=false;
    bool enemigoCorre=false;
    bool estaMuerto=false;

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

    //Variable para Respawn
    Vector3 posInicial;
    //Vector3 posNivel;

    void Start()
    {
        puedeSaltar=false;
        anim=GetComponent<Animator>();//Para traer valores del animador del personaje
        velocidadParado=velocidadM;
        velocidadAgachado=velocidadM*0.5f;
        posInicial=transform.position;
        //SpawnNivel();
    }

    void FixedUpdate(){
        transform.Rotate(0,x*Time.deltaTime*velocidadR,0);//Rotar
        transform.Translate(0,0,y*Time.deltaTime*velocidadM);//Moverse
    }
    void Update()
    {
        Animar();
        ConsultarM();
        //VerificaVida();
        VerificaCaida();
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
            AbrirBrazosE();
            CorrerE();
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
            if(estaMuerto==false){
                GameManager.ModificaVida(-10);
            }
        }
        else
        {
            tiempo=Temporizador(1);
            if(tiempo==0){
                anim.SetBool("golpeBajo",false);
            }
        }
    }

    /*Método para Verificar Vida*/
    /*void VerificaVida(){
        if(GameManager.GetVida()<=0){
            Debug.Log("Haz Muerto "+GameManager.GetVida());
            estaMuerto=true;
            anim.SetBool("estaMuerto",true);
        }
    }*/

    /*Método para Verificar Caida del Tablero*/
    void VerificaCaida(){
        /*Evalua si el jugador cayo del escenario*/
        if(transform.position.y <-10){
            Respawn();
            
        }
    }

    //Manejo Respawn
    void Respawn(){
        transform.position=posInicial;
    }
    
    /*
    //Para Respawn al Cambiar de Nivel
    void SpawnNivel(){
        if(GameManager.GetNivel()==2){
            posNivel=new Vector3(12.86f,0.51f,15.31f);
            transform.position=posNivel;
        }
    }
    */

    //Metodo para animacion de enemigo cuando se activa
    void AbrirBrazosE(){
        if(enemigoBrazos==true){
            animEnemigo.SetBool("abreBrazos",true);
            enemigoBrazos=false;
        }else{
           tiempo=Temporizador(2.5f);
           if(tiempo==0){
                animEnemigo.SetBool("abreBrazos",false);
           }
        }
    }

    //Metodo para que enemigo inicie a correr
    void CorrerE(){
        if(enemigoCorre==true){
            animEnemigo.SetBool("estaCorriendo",true);
            animEnemigo.SetBool("abreBrazos",false);
            enemigoCorre=false;
        }
        else{
           tiempo=Temporizador(2.5f);
           if(tiempo==0){
                animEnemigo.SetBool("estaCorriendo",false);
           }
        }
    }

    void OnTriggerEnter(Collider col){
        if(col.transform.gameObject.tag == "Lanza"){
            estaGolpeado=true;
        }else if(col.transform.gameObject.name == "SpotNv1_2"){
            enemigoBrazos=true;
        }else if(col.transform.gameObject.name == "SpotNv1_3"){
            enemigoBrazos=false;
            enemigoCorre=true;
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
