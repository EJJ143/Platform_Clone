using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Authors: Johnson, Ethan
//         Suazo, Angel
//Last Modified:10/25/23
//Purpose: To handle all interactions between the players and their avatar
public class PlayerController : MonoBehaviour
{
    //All game objects go below this line
    //public GameObject spawnPoint;
    public GameObject turnHere;

    //All integers/floats go below this line
    public float speed;
    public float jumpForce = 8f;  
    public float fallDepth;
    public int wumpaFruitCollected = 0;
    public int lives = 3;

    //All Vector3's go below this line
    private Vector3 startPosition;

    // Start is called before the first frame update
    void Start()
    {
        startPosition =transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // WASD Movement
        if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("Move the player Left");
           //the A key goes LEFT
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            Debug.Log("Move the player Back");
            //the S key goes BACK
            transform.position += Vector3.back * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D)) 
        {
            Debug.Log("Move the player Right");
            //D key to go RIGHT
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        if(Input.GetKey(KeyCode.W))
        {
            Debug.Log("Move the player Forward");
            //W key to go FORWARD
            transform.position += Vector3.forward * speed * Time.deltaTime;
        }    
    }
    private void Respawn()
    {
        lives--;
        //brings the player back to the startPosition
        transform.position = startPosition;
        //check to see if player has 0 lives
        if (lives == 0)
        {
            //insert scenemanager here with endscreen
        }
    }


    private void Jump()
    {
        //Handles jumping 
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //this is reserved for the jump function

            //A.S working

        }
    }
    private void SpinAttack()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            //this is reserved for the spin attack, i felt like it should be left click but it can be whatever
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "WumpaFruit")
        {
            //if collide with a wumpa fruit add it to score and delete it
            wumpaFruitCollected++;
            other.gameObject.SetActive(false);
        }


        if (other.gameObject.tag == "TurnRight")
        {
            Rotate();
            transform.Rotate(0f, 90f, 0f);
            Debug.Log("you collided with the game object");
        }
    }
    public void Rotate(float xAngle = 0f, float rotationAngle = 90f, float zAngle = 0f, Space relativeTo = Space.Self)
    {
        
    }
}
