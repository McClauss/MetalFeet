using UnityEngine;

public class OrbesHerencia : MonoBehaviour
{
    
    void Start()
    {
        CrearOrbes();
    }

    
    void Update()
    {
        
    }

    public void CrearOrbes(){
        //Orbe Curacion
        Debug.Log("ORBE CURACION");
        OrbeCuracion orbeCurar = new OrbeCuracion();
        orbeCurar.ActivarHabilidad("Orbe Curar");
        orbeCurar.Curar();
        orbeCurar.DarPista();

        Debug.Log("---------------------------------");
        //Orbe Tamano
        Debug.Log("ORBE AGRANDAR");
        Orbe orbeTamano = new Orbe();
        orbeTamano.valor=2;
        orbeTamano.nombre="Orbe Agrandar";
        orbeTamano.peso=3;
        orbeTamano.habilidad="Agrandar";

        orbeTamano.ActivarHabilidad(orbeTamano.nombre);
    }
}
