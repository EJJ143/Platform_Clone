using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldEnemyController : MonoBehaviour
{
    public float speed = 5f;
    public GameObject Point1;
    public GameObject Point2;

    private Vector3 position1;
    private Vector3 position2;

    public bool goingUpAndDown=false;
    
    
    // Start is called before the first frame update
    void Start()
    {

        position2 = Point2.transform.position;
        position1 = Point1.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        ShieldEnemyMove();
        HitShieldedEnemy();
    }

    private void ShieldEnemyMove()
    {
        RaycastHit hit;

        transform.position += transform.forward * speed * Time.deltaTime;
        if (goingUpAndDown == false)
        {
            if (transform.position.x <= position1.x)
            {

                transform.Rotate(0f, 180f, 0f);
            }
            if (transform.position.x >= position2.x)
            {

                transform.Rotate(0f, 180f, 0f);
            }
        }
        if (goingUpAndDown == true)
        {
            if (transform.position.z <= position1.z)
            {

                transform.Rotate(0f, 180f, 0f);
            }
            if (transform.position.z >= position2.z)
            {

                transform.Rotate(0f, 180f, 0f);
            }
        }


        if (Physics.Raycast(transform.position, transform.forward, out hit, 1.5f))
        {
            transform.Rotate(0f, 180f, 0f);
        }
    }

    private void HitShieldedEnemy()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.up, out hit, 1f))
        {
            if (hit.collider.tag == "Player")
            {
                this.gameObject.SetActive(false);
            }
        }
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 1f))
        {
            goingUpAndDown = true;
        }
        if (Physics.Raycast(transform.position, Vector3.up, out hit, 1f))
        {
            goingUpAndDown = false;
        }
    }
}
