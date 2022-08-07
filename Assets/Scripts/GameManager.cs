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
    bool estaMuerto=false;

    //Para Instanciado de Antorchas
    public GameObject prefabAntorcha;
    public Transform spotAntorcha1;
    public Transform spotAntorcha2;
    public Transform spotAntorcha3;
    public Transform spotAntorcha4;
    public Transform spotAntorcha5;
    public Transform spotAntorcha6;
    public Transform spotAntorcha7;
    public Transform spotAntorcha8;
    public Transform spotAntorcha9;
    public Transform spotAntorcha10;
    public Transform spotAntorcha11;
    public Transform spotAntorcha12;
    public Transform spotAntorcha13;
    public Transform spotAntorcha14;
    public Transform spotAntorcha15;
    public Transform spotAntorcha16;
    public Transform spotAntorcha17;
    public Transform spotAntorcha18;
    public Transform spotAntorcha19;
    public Transform spotAntorcha20;
    public Transform spotAntorcha21;
    public Transform spotAntorcha22;
    public Transform spotAntorcha23;

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
        IniciaAntorchas();
    }

    // Update is called once per frame
    void Update()
    {
        CambioEscena();
        VerificaVida();
        VerificaCaida();
    }

    //Metodo que inicia prefabs de antorchas
    void IniciaAntorchas(){
        Instantiate(prefabAntorcha,spotAntorcha1.position,transform.rotation);
        Instantiate(prefabAntorcha,spotAntorcha2.position,transform.rotation);
        Instantiate(prefabAntorcha,spotAntorcha3.position,transform.rotation);
        Instantiate(prefabAntorcha,spotAntorcha4.position,transform.rotation);
        Instantiate(prefabAntorcha,spotAntorcha5.position,transform.rotation);
        Instantiate(prefabAntorcha,spotAntorcha6.position,transform.rotation);
        Instantiate(prefabAntorcha,spotAntorcha7.position,transform.rotation);
        Instantiate(prefabAntorcha,spotAntorcha8.position,transform.rotation);
        Instantiate(prefabAntorcha,spotAntorcha9.position,transform.rotation);
        Instantiate(prefabAntorcha,spotAntorcha10.position,transform.rotation);
        Instantiate(prefabAntorcha,spotAntorcha11.position,transform.rotation);
        Instantiate(prefabAntorcha,spotAntorcha12.position,transform.rotation);
        Instantiate(prefabAntorcha,spotAntorcha13.position,transform.rotation);
        Instantiate(prefabAntorcha,spotAntorcha14.position,transform.rotation);
        Instantiate(prefabAntorcha,spotAntorcha15.position,transform.rotation);
        Instantiate(prefabAntorcha,spotAntorcha16.position,transform.rotation);
        Instantiate(prefabAntorcha,spotAntorcha17.position,transform.rotation);
        Instantiate(prefabAntorcha,spotAntorcha18.position,transform.rotation);
        Instantiate(prefabAntorcha,spotAntorcha19.position,transform.rotation);
        Instantiate(prefabAntorcha,spotAntorcha20.position,transform.rotation);
        Instantiate(prefabAntorcha,spotAntorcha21.position,transform.rotation);
        Instantiate(prefabAntorcha,spotAntorcha22.position,transform.rotation);
        Instantiate(prefabAntorcha,spotAntorcha23.position,transform.rotation);
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
