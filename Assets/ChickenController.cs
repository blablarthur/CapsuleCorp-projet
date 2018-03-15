using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.Networking;

public class ChickenController : NetworkBehaviour
{
    public Transform t;
    [SerializeField] float speed = 5.0f;
    [SerializeField] float minAnimationTime = 2.0f;
    [SerializeField] float maxAnimationTime = 5.0f;
    float animationTime = 0;
    float time = 0;
    Vector3 moveDirection;

    Animator animator;
    bool isIdle = true;

	
	
	void FixedUpdate () {
        time += Time.deltaTime;
        if (!isLocalPlayer)
        {
            return;
            
        }
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;
        Debug.Log("x: " + x + "  z: "+ z);
        t.Rotate(0, x, 0);
        t.Translate(0, 0, z);


    }

    
}
