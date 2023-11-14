using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Authors: Johnson, Ethan
//         Suazo, Angel
//Last Modified:11/12/23
//Purpose: To handle the turles movement
public class TurtleEnemy : MonoBehaviour
{
    //game objects to determine how far left/right enemy goes
    public GameObject forwardPoint;
    public GameObject backPoint;

    // boundary points for left and right 
    private Vector3 forwardPos;
    private Vector3 backPos;

    //how fast enemy travels
    public float speed;

    //the direction it is going 
    public bool goingForward;
    public bool xAxisMovement;
    

    // Start is called before the first frame update
    void Start()
    {
        forwardPos = forwardPoint.transform.position;
        backPos = backPoint.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        TurtleEnemyMove();
    }
    /// <summary>
    /// Make the enemy move forward and back
    /// </summary>
    private void TurtleEnemyMove()
    {
        RaycastHit hit;
        if (xAxisMovement == true)
        {
            if (goingForward == true)
            {
                //once the enemy reaches the forwardPos - goingForward is false
                if (transform.position.x >= forwardPos.x)
                {
                    goingForward = false;
                }
                else
                {
                    //translate the enemy back by speed using Time.deltaTime
                    transform.position += transform.right * speed * Time.deltaTime;
                }
            }
            else
            {
                //once the enemy reaches the backPos - goingForward is true
                if (transform.position.x <= backPos.x)
                {
                    goingForward = true;
                }
                else
                {
                    //translate the enemy forward by speed using Time.deltaTime
                    transform.position += -transform.right * speed * Time.deltaTime;
                }
            }
        }
        else
        {
            if (goingForward == true)
            {
                //once the enemy reaches the forwardPos - goingForward is false
                if (transform.position.z <= forwardPos.z)
                {
                    goingForward = false;
                }
                else
                {
                    //translate the enemy back by speed using Time.deltaTime
                    transform.position += Vector3.back * speed * Time.deltaTime;
                }
            }
            else
            {
                //once the enemy reaches the backPos - goingForward is true
                if (transform.position.z >= backPos.z)
                {
                    goingForward = true;
                }
                else
                {
                    //translate the enemy forward by speed using Time.deltaTime
                    transform.position += Vector3.forward * speed * Time.deltaTime;
                }
            }
        }
        
        if (Physics.Raycast(transform.position, -transform.forward, out hit, 1f))
        {
            goingForward = true;
        }
        if (Physics.Raycast(transform.position, transform.forward,out hit, 1f))
        {
            goingForward = false;
        }
            
        
    }
}
