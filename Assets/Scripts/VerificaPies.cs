using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerificaPies : MonoBehaviour
{
    public ControlJugador controlJugador;
    
    void Start()
    {
        
    }
    
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider col){
        controlJugador.puedeSaltar=true;
    }

    private void OnTriggerExit(Collider col){
        controlJugador.puedeSaltar=false;
    }
}
