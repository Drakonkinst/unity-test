using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// https://docs.unity3d.com/ScriptReference/Input.GetKeyDown.html
// https://docs.unity3d.com/ScriptReference/Rigidbody.AddForce.html
// https://docs.unity3d.com/ScriptReference/Transform.Translate.html

public class PlayerController : MonoBehaviour
{
    public float speed = 1;
    public float jumpForce = 20;

    Rigidbody playerRb;
    
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveDirection = Vector3.zero;
        
        if(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            moveDirection += Vector3.forward;
        }
        if(Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            moveDirection += Vector3.back;
        }
        if(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            moveDirection += Vector3.right;
        }
        if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            moveDirection += Vector3.left;
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            playerRb.AddForce(0, jumpForce, 0, ForceMode.Impulse);
        }

        transform.Translate(moveDirection * speed * Time.deltaTime);
    }
}
