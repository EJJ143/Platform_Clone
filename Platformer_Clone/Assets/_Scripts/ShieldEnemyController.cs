using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldEnemyController : MonoBehaviour
{
    public GameObject rightPoint;
    public GameObject leftPoint;

    private Vector3 rightPos;
    private Vector3 leftPos;

    public float speed = 5f;

    public bool goingRight;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rightPos = rightPoint.transform.position;
        leftPos = leftPoint.transform.position;

        ShieldTurtleMove();
    }

    private void ShieldTurtleMove()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 1.5f))
        {
            if (goingRight == true)
            {
                goingRight = false;
            }
            else
            {
                goingRight = true;
            }
        }
        if (goingRight == true)
        {
            transform.position += transform.forward * speed * Time.deltaTime;       
        }
        if (!goingRight)
        {
            transform.position += -transform.forward * speed * Time.deltaTime;
        }


    }
}
