using UnityEngine;

public class Canion : MonoBehaviour
{
    
    public float rango=1000f;
    //public Camera camara;
    public Transform spotCanion; 

    //#region ignorarVariables
    public ParticleSystem flashEffect;
    public GameObject impactEffect;
    public AudioSource _audioS;
    public AudioClip _clipDisparo;
    public AudioClip _clipHit;
    //#endregion

    void Start()
    {
        
    }

    
    void Update()
    {
        //if(Input.GetKey(KeyCode.P)){
            Disparar();
        //}
    }

    void Disparar(){
        RaycastHit hit;
        flashEffect.Play();
        if(Physics.Raycast(spotCanion.transform.position,spotCanion.transform.forward,out hit,rango)){
            
            if(hit.transform.tag=="EnemigoNv1"){
                Debug.Log(hit.transform.tag);
                GameManager.ModificaVidaEnemigo(-20);
                //GameObject copiaImpacto = Instantiate(impactEffect,hit.point,Quaternion.LookRotation(hit.normal));//para poner efecto en el sitio donde hay impacto
                //Destroy(copiaImpacto,3f);
            }else if(hit.transform.tag=="Jugador"){
                Debug.Log(hit.transform.tag);
                GameManager.ModificaVida(-20);
            }
        }
    }
}
