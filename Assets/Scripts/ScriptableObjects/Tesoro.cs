using UnityEngine;

[CreateAssetMenu(fileName="Nuevo Tesoro",menuName="Tesoro")]
public class Tesoro : ScriptableObject
{
    public string nombreTesoro;
   public string descripcionTesoro;
   public Sprite dibujoTesoro;
   //public int valorTesoro;

   public void MostrarDatos(){
        Debug.Log(nombreTesoro+" "+descripcionTesoro);    
   }
}
