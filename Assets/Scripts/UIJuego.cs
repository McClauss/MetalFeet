using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIJuego : MonoBehaviour
{

    public Text textoPuntaje;
    public Text textoVida;

    private bool pausaActiva;
    public GameObject pausaMenu;

    /*
    public Image barraVida;
    public int vidaActual;
    public int maxVida=100;
    */

    void Start()
    {
        pausaMenu.SetActive(false);
    }

    void Update()
    {
        textoPuntaje.text="Puntaje: "+GameManager.GetPuntaje()+"pts";
        textoVida.text="Vida: "+GameManager.GetVida();
        //vidaActual=GameManager.GetVida();
        //barraVida.fillAmount=vidaActual/maxVida;

        TogglePausa();
    }

    public void TogglePausa(){
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(pausaActiva){
                ResumeJuego();
            }else{
                PausaJuego();
            }
        }
    }

    void ResumeJuego(){
        pausaMenu.SetActive(false);
        Time.timeScale=1;
        pausaActiva=false;
    }
    void PausaJuego(){
        pausaMenu.SetActive(true);
        Time.timeScale=0;
        pausaActiva=true;
    }

    public void MenuPrincipal(){
        SceneManager.LoadScene(0);
    }
}
