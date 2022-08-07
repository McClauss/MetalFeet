using UnityEngine;

public class ControlEnemigo : MonoBehaviour
{

    public Animator anim;
    
    void Start()
    {
        //anim=GetComponent<Animator>();
    }

    void FixedUpdate(){
        //transform.Rotate(0,x*Time.deltaTime*velocidadR,0);//Rotar
        //transform.Translate(0,0,y*Time.deltaTime*velocidadM);//Moverse
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
