using UnityEngine;

public class Lanza : MonoBehaviour
{
    public float speedL = 0.05f;
    public Vector3 direccionL=new Vector3(10,0,0);

    void Update()
    {
        Quaternion target=Quaternion.Euler(0,0,-90);
        transform.rotation=Quaternion.Slerp(transform.rotation,target,Time.deltaTime);
        transform.position += direccionL*speedL;
    }
}
