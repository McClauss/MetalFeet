using UnityEngine;

public class Antorcha : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        Quaternion target=Quaternion.Euler(-90,0,0);
        transform.rotation=Quaternion.Slerp(transform.rotation,target,5*Time.deltaTime);
    }
}
