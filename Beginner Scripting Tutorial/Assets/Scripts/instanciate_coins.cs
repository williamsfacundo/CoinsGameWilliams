using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instanciate_coins : MonoBehaviour
{
    //Public Vars
    public GameObject coinPrefab;

    public float coinYPosition = 3.9f;

    public Material yellowMaterial;
    public Material redMaterial;

    //Private Vars
    const short minX = -19;
    const short maxX = 20;
    const short minY = -19;
    const short maxY = 20;

    short coinsCounter;

    Vector3 coinPosition;   

    // Start is called before the first frame update
    void Start()
    {
        coinsCounter = System.Convert.ToInt16(Random.Range(40, 70));        

        for (short i = coinsCounter; i >= 1; i--) 
        {
            NewCoin();                        
        }
    }      

    void ChooseRandomCoinMaterial() 
    {
        short aux = System.Convert.ToInt16(Random.Range(1, 3));        

        if (aux == 1)
        {            
            coinPrefab.GetComponent<Renderer>().sharedMaterial = yellowMaterial;
        }
        else 
        {
            coinPrefab.GetComponent<Renderer>().sharedMaterial = redMaterial;
        }        
    }

    void GenerateCoinPosition() 
    {
        coinPosition = new Vector3(Random.Range(minX, maxX), coinYPosition, Random.Range(minY, maxY));

        //Check if the new coin position is not inside safe zone
        while (coinPosition.x > -8 && coinPosition.x < 8 && coinPosition.z > -8 && coinPosition.z < 8) 
        {
            coinPosition = new Vector3(Random.Range(minX, maxX), coinYPosition, Random.Range(minY, maxY));
        }
    }

    public void NewCoin() 
    {
        ChooseRandomCoinMaterial();

        GenerateCoinPosition();

        Instantiate(coinPrefab, coinPosition, Quaternion.identity);
    }
}
