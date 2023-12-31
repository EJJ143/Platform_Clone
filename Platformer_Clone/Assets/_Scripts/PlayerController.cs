using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Authors: Johnson, Ethan
//         Suazo, Angel
//Last Modified:11/12/23
//Purpose: To handle all interactions between the players and their avatar
public class PlayerController : MonoBehaviour
{
    // This is the game object for the wumpas to be cloned
    public GameObject Wumpas;

    private Rigidbody rigidBody;

    //All integers/floats go below this line
    public float spinSpeed = 5f;
    public float speed;
    public float jumpForce = 8f;  
    public float fallDepth = 10f;
    public int wumpaFruitCollected = 0;
    public int lives = 3;

    //All Vector3's go below this line
    private Vector3 startPosition;

    private bool isGrounded;
    public bool attacking;
    private bool waiting = false;

    private Renderer objectRenderer;

    // These are the colors for showing the spin attack
    public Material redMaterial;
    public Material greenMaterial;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        rigidBody = GetComponent<Rigidbody>();
        objectRenderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // WASD Movement
        Move();
        Turn();
        Jump();
        SpinAttack();
        if (transform.position.y <= -10)
        {
            Respawn();
        }
    }
    
    /// <summary>
    /// Handles all movement for player
    /// </summary>
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
    /// <summary>
    /// Handles the snap turning of 90 degrees with Q & E
    /// </summary>
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
            if (hit.collider.tag == "RegularEnemy")
            {
                isGrounded = false;
            }
            else
            {
                isGrounded = true;
                Debug.Log("on ground");
            }
        }
        else
        {
            isGrounded = false;
            Debug.Log("not on the ground");
        }
        
        if (Input.GetKeyDown(KeyCode.Space)&& isGrounded == true)
        {
            rigidBody.AddForce(Vector3.up *jumpForce, ForceMode.Impulse);
        }
    }

    /// <summary>
    /// Handles players spinning attack action.
    /// </summary>
    private void SpinAttack()
    {
        if (waiting == false)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (waiting == false)
                {
                    StartCoroutine(Attack());
                }

            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Crate")
        {
            if (attacking == true)
            {
                other.gameObject.SetActive(false);
                Instantiate(Wumpas, other.transform.position, other.transform.rotation);
            }
        }
        if (other.gameObject.tag == "WumpaFruit")
        {
            //if collide with a wumpa fruit add it to score and delete it
            wumpaFruitCollected += 2;
            other.gameObject.SetActive(false);
            //adds an extra life if player collects 100 wumpa fruits
            if (wumpaFruitCollected == 100)
            {
                lives++;
            }
        }
        if (other.gameObject.tag == "Portal") 
        {
            startPosition = other.gameObject.GetComponent<Portal>().newSpawn.transform.position;
            transform.position = startPosition;
        }
        if (other.gameObject.tag == "Turtle")
        {
            if (attacking == true)
            {
                other.gameObject.SetActive(false);
            }
            else
            {
                Respawn();
            }
        }
        if (other.gameObject.tag == "Shielded Enemy")
        {
            Respawn();
        }
        if (other.gameObject.tag == "Spikes")
        {
            Respawn();
        }
        if (other.gameObject.tag == "RegularEnemy")
        {
            if (isGrounded == false)
            {
                other.gameObject.SetActive(false);
            }
            if (attacking == true)
            {
                other.gameObject.SetActive(false);
            }
            if (attacking == false && isGrounded == true )
            {
                Respawn();
            }
        }
    }
    public IEnumerator Attack()
    {

        objectRenderer.material = redMaterial;
        attacking = true;
        yield return new WaitForSeconds(1f);
        objectRenderer.material = greenMaterial;
        attacking = false;
        waiting = true;
        StartCoroutine(Wait());

    }
    public IEnumerator Wait()
    {
        yield return new WaitForSeconds(1.5f);
        waiting = false;
    }
}
