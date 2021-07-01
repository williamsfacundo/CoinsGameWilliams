using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    //Public Vars
    public Text lifesText;
    public Text scoreText;
    public Text deathsText;
    public Text timerText;
    
    public Material yellowMaterial;

    public instanciate_coins coinGeneratorScript;
    public SqlConnectData sqlScript;

    //Private Vars
    int score = 0;
    short lifes = 3;
    short deaths = 0;
    float endGameTimer = 12f;    
    bool isCollidingWithFloor = false;

    private float zMoveVelocity = 8f;
    private float yMoveVelocity = 8f;
    private float jumpForce = 400f;
    private float maxYPositionToFall;
    float distanceToFall = 10f;

    KeyCode jumpKey = KeyCode.Space;    

    Vector3 initialPosition;
    Rigidbody _rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        //Set Initial position and how much the player can fall until respawn
        initialPosition = gameObject.transform.position;
        maxYPositionToFall = initialPosition.y - distanceToFall;

        _rigidbody = GetComponent<Rigidbody>();        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();

        PlayerJump();

        CheckIfPlayerHasFall();

        UpdateUIVars();

        PlayerDeath();

        ReduceTimer();

        EndGame();        
    }

    void PlayerMovement() 
    {
        gameObject.transform.Translate((Vector3.forward * yMoveVelocity * Time.deltaTime) * Input.GetAxis("Vertical"));
        gameObject.transform.Translate((Vector3.right * zMoveVelocity * Time.deltaTime) * Input.GetAxis("Horizontal"));
    }

    void PlayerJump() 
    {
        if (isCollidingWithFloor && Input.GetKeyDown(jumpKey))
        {
            _rigidbody.AddForce(Vector3.up * jumpForce);
            _rigidbody.useGravity = true;
        }
    } 

    void UpdateUIVars()
    {
        lifesText.text = "LIFES = " + lifes;
        scoreText.text = "SCORE = " + score;
        deathsText.text = "DEATHS = " + deaths;
        timerText.text = "" + System.Convert.ToInt32(endGameTimer);        
    }

    void PlayerDeath() 
    {
        if (lifes <= 0) 
        {
            deaths++;

            lifes = 3;

            gameObject.transform.position = initialPosition;

            if (score != 0) 
            { 
                System.Convert.ToInt32(score /= 2); 
            }
        }
    }

    void ScoreUp(int _score) 
    {
        score += _score;
    }

    void LifesDown(short value) 
    {
        lifes -= value;
    }

    void CheckIfPlayerHasFall()
    {
        if(gameObject.transform.position.y <= maxYPositionToFall)
        {
            LifesDown(1);

            gameObject.transform.position = initialPosition;            
        }
    }

    void ReduceTimer() 
    {
        if (endGameTimer > 0) 
        {
            endGameTimer -= Time.deltaTime;
        }        
    }
    
    void EndGame() 
    {
        if (endGameTimer < 0) 
        {
            sqlScript.CallRegister();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);            
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Detect if object collides with coin
        if (collision.gameObject.tag == "Coin") 
        {
            //Depending the color of the coin, the action it takes 
            if (collision.gameObject.GetComponent<Renderer>().sharedMaterial == yellowMaterial)
            {
                ScoreUp(10);
            }
            else 
            {
                LifesDown(1);
            }

            coinGeneratorScript.NewCoin();
            Destroy(collision.gameObject);
        }

        //Detect if object collides with floor
        if(collision.gameObject.tag == "Floor")
        {
            isCollidingWithFloor = true;
        }        
    }

    private void OnCollisionExit(Collision collision)
    {
        //Detect if player is no longer colliding with floor
        if (collision.gameObject.tag == "Floor")
        {
            isCollidingWithFloor = false;
        }        
    }

    public int GetScore() 
    {
        return score;
    }

    public short GetDeaths() 
    {
        return deaths;
    }
}
