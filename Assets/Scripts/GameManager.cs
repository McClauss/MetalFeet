using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //Variable propia para instancia de escenas en el manager
    public static GameManager Instance;

    //Variables para Puntaje, Vidas y vida del jugador
    public static int puntaje;
    public static int vida;
    public static int vidaEnemigoNv1;
    public static int vidas;

    //Variable para control de Niveles
    public static int nivel=1;
    
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
        puntaje=0;
        vida=100;
        vidaEnemigoNv1=120;
    }

    void Update()
    {
        CambioEscena();
        
    }
    
    //Método para cambio de escena por teclado
    void CambioEscena(){
        if(Input.GetKeyDown(KeyCode.F1)){
            nivel=1;
            SceneManager.LoadScene("Escena-1");
        }else if(Input.GetKeyDown(KeyCode.F2)){
            nivel=2;
            SceneManager.LoadScene("Escena-2");
        }
    }

    //Método para adicionar/restar sangre segun colición
    public static void ModificaVida(int cantidad){
        vida=vida+cantidad;
        Debug.Log("Impacto!. Sangre restante: "+vida);
    }
    public static void ModificaVidaEnemigo(int cantidad){
        vidaEnemigoNv1=vidaEnemigoNv1+cantidad;
        Debug.Log("Impacto!. Sangre restante: "+vidaEnemigoNv1);
    }
    
    //Méotodo para modificar puntaje
    public static void ModificaPuntaje(int cantidad){
        puntaje=puntaje+cantidad;
        Debug.Log("Puntaje: "+puntaje+" más "+cantidad);
    }

    public static int GetPuntaje(){
        return puntaje;
    }
    public static int GetVida(){
        return vida;
    }
    public static int GetVidaEnemigo(){
        return vidaEnemigoNv1;
    }
    public static int GetNivel(){
        return nivel;
    }
}
