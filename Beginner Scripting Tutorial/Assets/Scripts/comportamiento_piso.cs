using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class comportamiento_piso : MonoBehaviour
{
    //Private Vars    
    short minTime;
    short maxTime;
    float timerToFall;
    float fallingSpeed;
    float fallingDistance;

    bool startFalling;
    bool timerOn;

    Vector3 initialPosition;    
    
    // Start is called before the first frame update
    void Start()
    {
        minTime = GetRandomNumber(1, 5);
        maxTime = GetRandomNumber(5, 30);
        timerToFall = GetRandomNumber(minTime, maxTime);

        fallingSpeed = -1.8f;
        fallingDistance = 10;        

        startFalling = false;
        timerOn = true;

        initialPosition = gameObject.transform.position;        
    }

    // Update is called once per frame
    void Update()
    {        
        if (timerOn) 
        {
            timerToFall -= Time.deltaTime;
        }

        if (timerToFall < 0) 
        {
            if (timerOn != false)
            {
                timerOn = false;
            }            
        }

        if (timerOn == false) 
        {
            if (startFalling != true)
            {
                startFalling = true;
            }
        }

        if (startFalling == true) 
        {
            if (gameObject.transform.position.y > initialPosition.y - fallingDistance)
            {
                gameObject.transform.Translate(Vector3.up * fallingSpeed * Time.deltaTime);
            }
            else 
            {
                timerToFall = GetRandomNumber(minTime, maxTime);
                timerOn = true;
                startFalling = false;
                gameObject.transform.position = initialPosition;
            }
        }  
    }

    static private short GetRandomNumber(short minValue, short maxValue) 
    {
        short number = System.Convert.ToInt16(Random.Range(minValue, maxValue));

        return number;
    }
}
