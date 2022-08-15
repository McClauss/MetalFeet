using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ragdoll : MonoBehaviour
{
    Collider[] ragdollColliders;
    Rigidbody[] mainRigidbodies;

    public Animator anim;
    public CapsuleCollider myCollider;
    public Rigidbody myRigidbody;
    public GameObject rig;
    public CapsuleCollider groundCheck;
    ControlJugador controlJugador;
    public bool getRagdoll;

    void Start()
    {
        GetDatosRagdoll();
        RagdollOff();
        controlJugador=GetComponent<ControlJugador>();
        //controlJugador=FIndObjectOfType<ControlJugador>();//Busca el componente en cada uno de los objetos en escena
    }

    // Update is called once per frame
    void Update()
    {
        VerificaVida();
        if(getRagdoll==true){//ejecutar ragdoll
            RagdollOn();
        }
    }

    void GetDatosRagdoll(){
        ragdollColliders=rig.GetComponentsInChildren<Collider>();
        mainRigidbodies=rig.GetComponentsInChildren<Rigidbody>();
    }

    void RagdollOff(){// Esta caminando, moviendose, vivo. Anmiator andando

        foreach(Collider col in ragdollColliders){
            col.enabled=false;
        }
        foreach(Rigidbody rigid in mainRigidbodies){
            rigid.isKinematic=true;
        }
        groundCheck.enabled=true;
        anim.enabled=true;
        myCollider.enabled=true;
        myRigidbody.isKinematic=false;
    }
    void RagdollOn(){
        
        anim.enabled=false;
        myCollider.enabled=false;
        myRigidbody.isKinematic=true;
        controlJugador.enabled=false;
        groundCheck.enabled=false;

        foreach(Collider col in ragdollColliders){
            col.enabled=true;
        }
        foreach(Rigidbody rigid in mainRigidbodies){
            rigid.isKinematic=false;
        }
    }

    void VerificaVida(){
        if(GameManager.GetVida()<=0){
            getRagdoll=true;
        }
    }

    //Para que se active el ragdoll al colisionar con X objeto con el tag "ActivarRagdoll"
    void OnCollisionEnter(Collision col){
        if(col.gameObject.CompareTag("ActivarRagdoll")){
            getRagdoll=true;
        }
    }
}
