using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SqlConnectData : MonoBehaviour
{
    public void CallRegister() 
    {
        StartCoroutine(Register());
    }

    IEnumerator Register() 
    {
        WWWForm form = new WWWForm();

        form.AddField("playerName", SaveName.GetUserName());
        form.AddField("score", storeData.GetScore());
        form.AddField("deaths", storeData.GetDeaths());
        

        UnityWebRequest www = UnityWebRequest.Post("http://localhost/parcial2/register.php", form);

        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.Success) 
        {
            Debug.Log(www.downloadHandler.text + " cargando");
        }
    }
}
