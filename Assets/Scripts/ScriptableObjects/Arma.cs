using UnityEngine;


[CreateAssetMenu(fileName="Nueva Arma",menuName="Arma")]
public class Arma : ScriptableObject
{
   public string nombreArma;
   public string descripcionArma;
   public Sprite dibujoArma;
   //public int valorArma;
   //public int danoArma;

   public void MostrarDatos(){
        Debug.Log(nombreArma+" "+descripcionArma);    
   }
}
