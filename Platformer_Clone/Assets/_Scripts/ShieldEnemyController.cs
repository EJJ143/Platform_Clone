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
        if (goingRight)
        {
            if (transform.position.x >= rightPos.x)
            {
                goingRight = false;
                Debug.Log("goingRight is now false");
            }
            else
            {
                transform.position += Vector3.forward * speed * Time.deltaTime;
            }          
        }
        if (!goingRight)
        {
            if (transform.position.x >= leftPos.x)
            {
                goingRight = true;
                Debug.Log("goingRight is now true");
            }
            else
            {
                transform.position += transform.forward * speed * Time.deltaTime;
            }
        }


    }
}
