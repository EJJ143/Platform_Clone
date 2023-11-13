using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldEnemyController : MonoBehaviour
{
    public float speed = 5f;

    public bool goingRight;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ShieldTurtleMove();
        
    }

    private void ShieldTurtleMove()
    {
        RaycastHit hit;

        transform.position += transform.forward * speed * Time.deltaTime;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 1.5f))
        {
            transform.Rotate(0f, 180f, 0f);
        }
    }
    
}
