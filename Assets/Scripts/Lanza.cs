using UnityEngine;

public class Lanza : MonoBehaviour
{
    public float speedL = 0.004f;
    public Vector3 direccionL=new Vector3(10,0,0);
    public int damage=10;

    // Update is called once per frame
    void Update()
    {
        Quaternion target=Quaternion.Euler(0,0,-90);
        transform.rotation=Quaternion.Slerp(transform.rotation,target,8*Time.deltaTime);
        transform.position += direccionL*speedL;
    }
}
