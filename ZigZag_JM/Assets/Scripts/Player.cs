using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public Vector3 PlayerDirection;
    public float PlayerSpeed;
    public GroundSpawner groundSpawner;

    public float score;
    public TextMeshProUGUI scoreText;

    public GameObject RestartMenu;

    private void Start()
    {
        PlayerDirection = Vector3.left;
        RestartMenu.SetActive(false);
    }   

    private void Update()
    {
        playerController();
        transform.position += getPlayerDirection() * PlayerSpeed * Time.deltaTime;   

        scoreText.text = "" + score;
    }

    public Vector3 getPlayerDirection() { return PlayerDirection; }

    private void playerController()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            PlayerMove();
        }
    }

    private void PlayerMove()
    {
        if(PlayerDirection.x == -1)
        { 
            PlayerDirection = Vector3.forward;
        }
        else
        {
            PlayerDirection = Vector3.left;
        }   
    }

    void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            groundSpawner.RandomGround2();

            score += 1;
        }
    }

    private void OnTriggerEnter(Collider other){
        
        if (other.gameObject.tag == "Dead"){
        
            Time.timeScale = 0f;
            RestartMenu.SetActive(true);

        }

    }

    public void RestartBtn(){
    
        Time.timeScale = 1f;
        RestartMenu.SetActive(true);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
}
