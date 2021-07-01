using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin_controller : MonoBehaviour
{
    //Public Vars
    public Material yellowMaterial;
    public Material redMaterial;

    //Private Vars
    float timerToChangeColor = 3.5f;
    float distanceToFall;

    Vector3 initialPosition;
    Vector3 newCoinPosition;        

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = gameObject.transform.position;
        distanceToFall = initialPosition.y - 4f;
    }

    // Update is called once per frame
    void Update()
    {
        CheckIfCoinHasFall();

        if (timerToChangeColor > 0)
        {
            ReduceTimer();
        }
        else 
        {
            ChangeMaterial();
            timerToChangeColor = 3.5f;
        }                
    }

    void CheckIfCoinHasFall()
    {
        if (gameObject.transform.position.y <= distanceToFall)
        {            
            newCoinPosition = new Vector3(Random.Range(-19, 20), 3.9f, Random.Range(-19, 20));
            gameObject.transform.position = newCoinPosition;            
        }
    }

    void ReduceTimer() 
    {
        timerToChangeColor -= Time.deltaTime;
    }

    void ChangeMaterial() 
    {
        if (gameObject.GetComponent<Renderer>().sharedMaterial == yellowMaterial)
        {
            gameObject.GetComponent<Renderer>().sharedMaterial = redMaterial;
        }
        else 
        {
            gameObject.GetComponent<Renderer>().sharedMaterial = yellowMaterial;
        }
    }    
}
