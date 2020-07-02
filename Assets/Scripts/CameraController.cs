using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float distance = 10.0f;
    public float height = 3.0f;
    
    GameObject playerCharacter;
    // Start is called before the first frame update
    void Start()
    {
        playerCharacter = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = (playerCharacter.transform.position + new Vector3(0, height, -distance));
    }
}
