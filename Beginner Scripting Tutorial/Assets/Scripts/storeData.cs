using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class storeData : MonoBehaviour
{
    //Public Vars
    public player playerScript;

    //Private Vars
    static int score = 0;
    static short deaths = 0;   

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player") 
        {
            score = playerScript.GetScore();
            deaths = playerScript.GetDeaths();
        }
    }

    public static int GetScore() 
    {
        return score;
    }

    public static short GetDeaths() 
    {
        return deaths;
    }
}
