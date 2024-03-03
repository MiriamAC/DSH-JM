using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public GameObject lastGround, groundPrefab, newGroundObject, starPrefab;
    private int groundDirection;
    public float starSpawnProbability;


    private void Start()
    {
        RandomGround();
    }

    private void RandomGround()
    {
        for(int i = 0; i < 90; i++)
        {
            newGround();
            
        }   
    }


 
    public void RandomGround2()
    {
        for(int i = 0; i < 1; i++)
        {

            newGround(); 
        }   
    }

    private void newGround()
    {
        groundDirection = Random.Range(0, 2);
        if(groundDirection == 0)
        {
            newGroundObject = Instantiate(groundPrefab, new Vector3(lastGround.transform.position.x - 1, lastGround.transform.position.y, lastGround.transform.position.z), Quaternion.identity);
            lastGround = newGroundObject;
        }
        else
        {
            newGroundObject = Instantiate(groundPrefab, new Vector3(lastGround.transform.position.x, lastGround.transform.position.y, lastGround.transform.position.z + 1f), Quaternion.identity);
            lastGround = newGroundObject;
           
        }

        if(Random.value < starSpawnProbability)
        {
             Instantiate(starPrefab, new Vector3(lastGround.transform.position.x, lastGround.transform.position.y + 1.5f, lastGround.transform.position.z), Quaternion.identity);
        }
    }

}