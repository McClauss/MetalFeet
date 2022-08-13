using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerSonido : MonoBehaviour
{
    //Variable propia para instancia de escenas en el manager
    public static ManagerSonido Instance;

    AudioSource _audSource;
    
    void Awake()
    {
        if(Instance==null){
            Instance=this;
            DontDestroyOnLoad(gameObject);
            _audSource=GetComponent<AudioSource>();
        }else{
            Destroy(gameObject);
        }
    }

    void Update()
    {
        
    }

    //Pausa Audio
    public static void Pausar(){
        Instance._audSource.Pause();
    }

    //Despausa Audio
    public static void DesPausar(){
        Instance._audSource.UnPause();
    }
}
