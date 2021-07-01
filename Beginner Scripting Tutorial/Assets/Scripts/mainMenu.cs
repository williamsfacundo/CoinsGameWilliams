using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
    //Public Vars
    public GameObject EnterName;

    public void ShowNameInputField() 
    {
        gameObject.SetActive(false);
        EnterName.SetActive(true);        
    }

    public void EndGame() 
    {
        Debug.Log("QUIT");
        Application.Quit();
    }

    public void GoToGameScene() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
