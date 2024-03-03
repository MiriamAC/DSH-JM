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

    private bool speedIncreased = false;

    public TextMeshProUGUI speedIncreasedText;

    public AudioSource source;

    public AudioClip starSound;
    
    private void Start()
    {
        PlayerDirection = Vector3.left;

        RestartMenu.SetActive(false);

        speedIncreasedText.enabled = false;
    }   

    private void Update()
    {
        playerController();
        transform.position += getPlayerDirection() * PlayerSpeed * Time.deltaTime;   

        scoreText.text = "" + score;

        if(score == 48){
            StartCoroutine(ShowSpeedIncreasedText());
        }
        
        if (score == 50 && !speedIncreased)
        {
            PlayerSpeed += 1.8f;
            speedIncreased = true; 
            
        }
        
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
        else if(other.gameObject.tag == "Star"){
             other.gameObject.SetActive(false);
             source.PlayOneShot(starSound);
        }

    }

    public void RestartBtn(){
    
        Time.timeScale = 1f;
        RestartMenu.SetActive(true);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

    IEnumerator ShowSpeedIncreasedText()
    {
        speedIncreasedText.enabled = true; 

        yield return new WaitForSeconds(1.0f); 

        speedIncreasedText.enabled = false;; 
    }

}
