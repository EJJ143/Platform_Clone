using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Author: [Suazo, Angel]
 * Last Updated: [11/12/2023]
 * [Handles side to side movement of turtle enemy]
 */

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

    // Start is called before the first frame update
    void Start()
    {
        forwardPos = forwardPoint.transform.position;
        backPos = backPoint.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        EnemyMove();
    }
    /// <summary>
    /// Make the enemy move forward and back
    /// </summary>
    private void EnemyMove()
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
}
