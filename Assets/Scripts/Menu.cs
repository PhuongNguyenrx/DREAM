using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{   
    public GameObject optionsmenu;
    public GameObject mainmenu;
   public void NewGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void Options()
    {
        optionsmenu.SetActive(true);
        mainmenu.SetActive(false);
    }
   public void Exit()
    {
        Application.Quit();
    }
    public void BacktoMenu()
    {
        optionsmenu.SetActive(false);
        mainmenu.SetActive(true);
    }
}
