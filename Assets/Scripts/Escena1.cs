using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escena1 : MonoBehaviour
{
    
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
    public Transform spotAntorcha24;
    public Transform spotAntorcha25;
    public Transform spotAntorcha26;
    public Transform spotAntorcha27;
    public Transform spotAntorcha28;
    public Transform spotAntorcha29;
    public Transform spotAntorcha30;
    public Transform spotAntorcha31;

    void Start()
    {
        IniciaAntorchas();
    }

    // Update is called once per frame
    void Update()
    {
        PausarAudio();//Pausar-Despausar Audio
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
        Instantiate(prefabAntorcha,spotAntorcha24.position,transform.rotation);
        Instantiate(prefabAntorcha,spotAntorcha25.position,transform.rotation);
        Instantiate(prefabAntorcha,spotAntorcha26.position,transform.rotation);
        Instantiate(prefabAntorcha,spotAntorcha27.position,transform.rotation);
        Instantiate(prefabAntorcha,spotAntorcha28.position,transform.rotation);
        Instantiate(prefabAntorcha,spotAntorcha29.position,transform.rotation);
        Instantiate(prefabAntorcha,spotAntorcha30.position,transform.rotation);
        Instantiate(prefabAntorcha,spotAntorcha31.position,transform.rotation);
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
