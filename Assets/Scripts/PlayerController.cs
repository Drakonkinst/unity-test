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
    
    public float deathZone = 50.0f;
    public Vector3 respawnLocation = new Vector3(0, 3, 0);

    private Rigidbody playerRb;
    private Transform myTransform;
    private int deathCount;
    
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        myTransform = transform;
        
        deathCount = 0;
    }

    private void DoPlayerInput() {
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

        myTransform.Translate(moveDirection * speed * Time.deltaTime);
    }
    
    private void CheckDeath() {
        if(myTransform.position.y < -deathZone) {
            deathCount++;
            myTransform.position = respawnLocation;
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        CheckDeath();
        DoPlayerInput();
    }
}
