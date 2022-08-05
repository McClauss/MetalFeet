using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int puntaje;
    public int sangre;
    bool golpeado;

    public Animator anim;
    
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
        sangre=100;
        golpeado=false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //Modifica Sangre
    void ModificaSangre(int cantidad){
        sangre=sangre+cantidad;
    }

    //Deteccion Impacto proyectiles
    void OnTriggerEnter(Collider col){
        if(col.transform.gameObject.tag == "Lanza"){
            ModificaSangre(-10);
            anim.SetBool("estaGolpeado",true);
            golpeado=true;
            Debug.Log("Impacto!. Sangre restante: "+sangre);
            VerificaSangre();
            golpeado=false;
        }
    }

    void VerificaSangre(){
        anim.SetBool("estaGolpeado",false);
        if(sangre<=0){
            //anim.SetBool("estaMuerto",true);
            //camMuerte.SetActive(true);
            Debug.Log("Haz Muerto "+sangre);
        }
    }

    void CambioEscena(){
        if(Input.GetKeyDown(KeyCode.F1)){
            SceneManager.LoadScene("Escena-1");
        }else if(Input.GetKeyDown(KeyCode.F2)){
            SceneManager.LoadScene("Escena-2");
        }
    }

    public int GetPuntaje(){
        return puntaje;
    }
    public int GetVida(){
        return sangre;
    }
}
