using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Vector3 PlayerDirection;
    public float PlayerSpeed;

    private void Start()
    {
        PlayerDirection = Vector3.left;
    }   

    private void Update()
    {
        playerController();
        transform.position += getPlayerDirection() * PlayerSpeed * Time.deltaTime;   
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
}
