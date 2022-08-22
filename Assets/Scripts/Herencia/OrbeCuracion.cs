using UnityEngine;

public class OrbeCuracion : Orbe
{
    public void Curar(){
        Debug.Log("Orbe Curar Aplicado");
        GameManager.ModificaPuntaje(10);
    }

    public override void DarPista(){
        Debug.Log("Pista: Tocas el Gas Verde y Adios para Siempre");
    }
}
