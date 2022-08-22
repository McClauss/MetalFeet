using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIJuego : MonoBehaviour
{

    public Text textoPuntaje;
    public Text textoVida;

    private bool pausaActiva;
    private bool armaActiva;
    private bool tesoroActiva;
    public GameObject pausaMenu;
    public GameObject armaMenu;
    public GameObject tesoroMenu;

    /*
    public Image barraVida;
    public int vidaActual;
    public int maxVida=100;
    */

    void Start()
    {
        pausaMenu.SetActive(false);
        armaMenu.SetActive(false);
        tesoroMenu.SetActive(false);
    }

    void Update()
    {
        textoPuntaje.text="Puntaje: "+GameManager.GetPuntaje()+"pts";
        textoVida.text="Vida: "+GameManager.GetVida();
        //vidaActual=GameManager.GetVida();
        //barraVida.fillAmount=vidaActual/maxVida;

        TogglePausa();
        //ToggleArmas();
        //ToggleTesoros();
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
        armaActiva=false;
        tesoroActiva=false;
    }
    void PausaJuego(){
        pausaMenu.SetActive(true);
        Time.timeScale=0;
        pausaActiva=true;
    }

    void ArmaMenu(){
        armaMenu.SetActive(true);
        Time.timeScale=0;
        armaActiva=true;
        tesoroActiva=false;
    }

    void TesoroMenu(){
        tesoroMenu.SetActive(true);
        Time.timeScale=0;
        tesoroActiva=true;
        armaActiva=false;
    }

    public void MenuPrincipal(){
        SceneManager.LoadScene(0);
    }
    public void MenuArmas(){
        ArmaMenu();
    }
    public void MenuTesoros(){
        TesoroMenu();
    }
}
