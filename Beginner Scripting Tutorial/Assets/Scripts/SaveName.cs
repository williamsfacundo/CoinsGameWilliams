using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveName : MonoBehaviour
{    
    //Public Vars
    public InputField userNameField;

    static string userName = "";      

    // Update is called once per frame
    void Update()
    {
        userName = userNameField.text;
    }

    public static string GetUserName() 
    {
        return userName;
    }
}
