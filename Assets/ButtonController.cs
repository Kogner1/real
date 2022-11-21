using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{

    [SerializeField] private string NextScene = "Win";

    public void NewGameButton()
    {
        SceneManager.LoadScene(NextScene);
    }




    void Start()
    {
        
    }

   
    void Update()
    {
        
    }

    

}

