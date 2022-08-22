using UnityEngine;
using UnityEngine.UI;

public class DisplayArma : MonoBehaviour
{
    public Arma _arma;
    public Text textoNombre;
    public Text textoDescripcion;
    public Image imagenArma;
   
    void Start()
    {
        _arma.MostrarDatos();
        textoNombre.text=_arma.nombreArma;
        textoDescripcion.text=_arma.descripcionArma;
        imagenArma.sprite=_arma.dibujoArma;
    }

}
