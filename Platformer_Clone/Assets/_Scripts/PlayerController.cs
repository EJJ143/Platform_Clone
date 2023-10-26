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
    public GameObject spawnPoint;
    public GameObject turnHere;

    //All integers/floats go below this line
    public float speed;
    public float jumpForce;  
    public float fallDepth;
    public int wumpaFruit;
    public int lives;
     
   

    //All Vector3's go below this line
    private Vector3 spawnPosition;

    // Start is called before the first frame update
    void Start()
    {
        spawnPosition = spawnPoint.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
           //the A key goes LEFT
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            //the S key goes BACK
            transform.position += Vector3.back * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D)) 
        {
            //D key to go RIGHT
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        if(Input.GetKey(KeyCode.W))
        {
            //W key to go FORWARD
            transform.position += Vector3.forward * speed * Time.deltaTime;
        }    
    }
    private void Jump()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            //this is reserved for the jump function
        }
    }
    private void SpinAttack()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            //this is reserved for the spin attack, i felt like it should be left click but it can be whatever
        }
    }
    private void LoseALife()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "WumpaFruit")
        {
            ++wumpaFruit;
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
