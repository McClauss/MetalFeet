using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //Variable propia para instancia de escenas en el manager
    public static GameManager Instance;

    //Variables para Puntaje, Vidas y vida del jugador
    public int puntaje;
    public int vida;
    public int vidas;

    //Variables para Temporizador
    float tiempoRestante=0;
    float tiempo=0;

    //Variable para Respawn
    Vector3 posInicial;

    //Varaible para Animador del Jugador
    private Animator anim;

    //Para manejo de animación muerte
    public bool estaMuerto=false;
    void Awake()
    {
        if(Instance==null){
            Instance=this;
            DontDestroyOnLoad(gameObject);
        }else{
            Destroy(gameObject);
        }
    }
    void Start()
    {
        anim=GetComponent<Animator>();
        posInicial=transform.position;
        puntaje=0;
        vida=100;
        vidas=3;
    }

    // Update is called once per frame
    void Update()
    {
        CambioEscena();
        VerificaVida();
        VerificaCaida();
    }
    
    //Método para cambio de escena por teclado
    void CambioEscena(){
        if(Input.GetKeyDown(KeyCode.F1)){
            SceneManager.LoadScene("Escena-1");
        }else if(Input.GetKeyDown(KeyCode.F2)){
            SceneManager.LoadScene("Escena-2");
        }
    }

    //Método para detectar impactos de lanza
    void OnTriggerEnter(Collider col){
        if(col.transform.gameObject.tag == "Lanza"){
            if(estaMuerto==false){
                ModificaVida(-10);
                Debug.Log("Impacto!. Sangre restante: "+vida);
            }
        }
    }

    //Método para adicionar/restar sangre segun colición
    void ModificaVida(int cantidad){
        vida=vida+cantidad;
    }

    //Método para verificar si jugador está vivo
    void VerificaVida(){
        if(vida<=0){
            Debug.Log("Haz Muerto "+vida);
            estaMuerto=true;
            anim.SetBool("estaMuerto",true);
        }
    }

    /*Método para Verificar Caida del Tablero*/
    void VerificaCaida(){
        /*Evalua si el jugador cayo del escenario*/
        if(transform.position.y <-10){
            vidas--;
            if(vidas<=0){
                Debug.Log("No te quedan vidas "+vidas);
            }else{
                Respawn();
            }
        }
    }

    //Manejo Respawn
    void Respawn(){
        vida=100;
        transform.position=posInicial;
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
    public int GetPuntaje(){
        return puntaje;
    }
    public int GetVida(){
        return vida;
    }
}
