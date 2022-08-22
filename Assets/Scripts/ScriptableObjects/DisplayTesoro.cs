using UnityEngine;
using UnityEngine.UI;

public class DisplayTesoro : MonoBehaviour
{
    public Tesoro _tesoro;
    public Text textoNombre;
    public Text textoDescripcion;
    public Image imagenTesoro;

    void Start()
    {
        _tesoro.MostrarDatos();
        textoNombre.text=_tesoro.nombreTesoro;
        textoDescripcion.text=_tesoro.descripcionTesoro;
        imagenTesoro.sprite=_tesoro.dibujoTesoro;
    }

}
