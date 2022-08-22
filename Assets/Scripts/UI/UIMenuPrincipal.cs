using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMenuPrincipal : MonoBehaviour
{
    public void Jugar(){
        //SceneManager.LoadScene("Escena-1");
        SceneManager.LoadScene(1);
    }

    public void Opciones(){
        SceneManager.LoadScene(2);
    }

    public void Salir(){
        Application.Quit();
    }
}
