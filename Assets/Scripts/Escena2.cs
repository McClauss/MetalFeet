using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escena2 : MonoBehaviour
{

    void Start()
    {

    }

    
    void Update()
    {
        PausarAudio();//Pausar-Despausar Audio
    }

    void PausarAudio(){
        if(Input.GetKeyDown(KeyCode.I)){
            ManagerSonido.Pausar();
        }
        if(Input.GetKeyDown(KeyCode.O)){
            ManagerSonido.DesPausar();
        }
    }
}
