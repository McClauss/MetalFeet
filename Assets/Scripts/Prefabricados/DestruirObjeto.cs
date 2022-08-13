using UnityEngine;

public class DestruirObjeto : MonoBehaviour
{
    public float delay=2f;

    void Start()
    {
        if(gameObject.tag!="orbeMorado"){
            Destroy(gameObject,delay);
        }
    }
    
    void Update()
    {
        
    }
}
