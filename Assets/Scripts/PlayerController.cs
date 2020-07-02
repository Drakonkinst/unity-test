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
        playerRb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        else if(Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime);
        }

        if(Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            playerRb.AddForce(0, jumpForce, 0, ForceMode.Impulse);
        }
    }
}
