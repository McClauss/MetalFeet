using UnityEngine;

public class DestruirObjeto : MonoBehaviour
{
    public float delay=3f;
    public GameObject jugador;
    
    void Start()
    {
        if(gameObject.tag!="orbeMorado"){
           if(gameObject.tag!="gargola"){
                Destroy(gameObject,delay);
            }
        }
    }

    
    void Update()
    {
        
    }
}
