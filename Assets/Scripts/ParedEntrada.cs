using UnityEngine;

public class ParedEntrada : MonoBehaviour
{
    
    //Para Instanciado de Proyectil Prefab
    public GameObject prefabLanza;
    public Transform spotLanza1;
    public Transform spotLanza2;
    public Transform spotLanza3;
    public Transform spotLanza4;
    public Transform spotLanza5;
    public Transform spotLanza6;

    //Para medir distancia del jugador
    public Transform posJugador;

    //Temporizador
    float tiempoRestante=0;
    float tiempo=0;

    void Update()
    {
        MedirDistancia();
    }

    //Mide distancia con el jugador
    void MedirDistancia(){
        float distancia=Vector3.Distance(transform.position,posJugador.position);

        //Debug.Log("Distancia es: "+distancia);
        Disparar(distancia);   
    }

    void Disparar(float distancia){
        
        if(distancia>0.1f && distancia<9){
            tiempo=Temporizador(1);
            if(tiempo==0){
                Instantiate(prefabLanza,spotLanza1.position,transform.rotation);
                Instantiate(prefabLanza,spotLanza2.position,transform.rotation);
                Instantiate(prefabLanza,spotLanza3.position,transform.rotation);
                Instantiate(prefabLanza,spotLanza4.position,transform.rotation);
                Instantiate(prefabLanza,spotLanza5.position,transform.rotation);
                Instantiate(prefabLanza,spotLanza6.position,transform.rotation);
            }
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
