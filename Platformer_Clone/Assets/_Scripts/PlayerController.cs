using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Authors: Johnson, Ethan
//         Suazo, Angel
//Last Modified:10/25/23
//Purpose: To handle all interactions between the players and their avatar
public class PlayerController : MonoBehaviour
{
    //All game objects go below this line
    //public GameObject spawnPoint;
    public GameObject turnHere;
    public Portal portal;
    private Rigidbody rigidBody;

    //All integers/floats go below this line
    public float speed;
    public float jumpForce = 8f;  
    public float fallDepth = 10f;
    public int wumpaFruitCollected = 0;
    public int lives = 3;

    //All Vector3's go below this line
    private Vector3 startPosition;

    private bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // WASD Movement
        Move();
        Turn();
        Jump();
        if (transform.position.y <= -10)
        {
            Respawn();
        }
    }
    
    private void Move()
    {
        if (Input.GetKey(KeyCode.W))
        {
            Debug.Log("Move the player Forward");
            //W key to go FORWARD
            transform.position += -transform.forward * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("Move the player Left");
            //the A key goes LEFT
            transform.position += transform.right * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            Debug.Log("Move the player Back");
            //the S key goes BACK
            transform.position += transform.forward * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            Debug.Log("Move the player Right");
            //D key to go RIGHT
            transform.position += -transform.right * speed * Time.deltaTime;
        }
    }
    private void Turn()
    {
        if (Input.GetKeyUp(KeyCode.Q))
        {
            transform.Rotate(0f, -90f, 0f);
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            transform.Rotate(0f, 90f, 0f);
        }
    }
    /// <summary>
    /// Handles the respawn function
    /// </summary>
    private void Respawn()
    {
        lives--;
        //brings the player back to the startPosition
        transform.position = startPosition;
        //check to see if player has 0 lives
        if (lives == 0)
        {
            SceneManager.LoadScene(2);
        }
    }

    /// <summary>
    /// Handles the player jump
    /// </summary>
    private void Jump()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, 1.5f))
        {
            isGrounded = true;
            Debug.Log("on ground");
        }
        else
        {
            isGrounded = false;
            Debug.Log("not on the ground");
        }
        
        if (Input.GetKeyDown(KeyCode.Space)&& isGrounded == true)
        {
            rigidBody.AddForce(Vector3.up *jumpForce, ForceMode.Impulse);
            
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
        if (other.gameObject.tag == "Portal") 
        {
            startPosition = other.gameObject.GetComponent<Portal>().newSpawn.transform.position;
            transform.position = startPosition;
        }
        if (other.gameObject.tag == "Turtle")
        {
            Respawn();
        }
    }
   
}
