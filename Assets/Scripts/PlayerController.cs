using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// https://docs.unity3d.com/ScriptReference/Input.GetKeyDown.html
// https://docs.unity3d.com/ScriptReference/Rigidbody.AddForce.html
// https://docs.unity3d.com/ScriptReference/Transform.Translate.html

public class PlayerController : MonoBehaviour
{
    Rigidbody playerRb;
    
    // Start is called before the first frame update
    void Start()
    {
        playerRb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.Translate(Vector3.forward * Time.deltaTime);
        }
        else if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            transform.Translate(Vector3.back * Time.deltaTime);
        }

        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * Time.deltaTime);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * Time.deltaTime);
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            playerRb.AddForce(0, 5, 0, ForceMode.Impulse);
        }
    }
}
