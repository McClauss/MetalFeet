using UnityEngine;

public class DestruirObjeto : MonoBehaviour
{
    public float delay=4f;

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
