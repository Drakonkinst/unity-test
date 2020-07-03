using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 2;
    public float jumpForce = 20;
    public float RaycastLength = 1;
    public int timeToTurn = 2;

    private int direction = 0;
    private Transform myTransform;

    // Start is called before the first frame update
    void Start()
    {
        myTransform = transform;
        StartCoroutine("Oscillate");
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }

    IEnumerator Oscillate()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeToTurn);
            if (direction != 3)
            {
                direction++;
            }
            else
            {
                direction = 0;
            }
        }
    }

    private void move()
    {
        Vector3 moveDirection = Vector3.zero;

        if (direction == 0)  // left
        {
            moveDirection = Vector3.left;
        }
        else if(direction == 1) // up
        {
            moveDirection = Vector3.forward;
        }
        else if (direction == 2) // right
        {
            moveDirection = Vector3.right;
        }
        else // down
        {
            moveDirection = Vector3.back;
        }

        if (!Physics.Raycast(myTransform.position, moveDirection, RaycastLength))
        {
            myTransform.Translate(moveDirection * speed * Time.deltaTime);
        }

    }
}
