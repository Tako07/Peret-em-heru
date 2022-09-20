using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameScene(){
        SceneManager.LoadScene("StartLevel_Desert");
    }

    public void showControlls(){
        SceneManager.LoadScene("How2Play");
    }

    public void showMainMenu(){
        SceneManager.LoadScene("MenuScene");
    }

    public void quitGame(){
        Application.Quit();
    }
}
