using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;

public class controller : MonoBehaviour
{
    
    public Transform t;
    [SerializeField] float speed = 5.0f;
    float animationTime = 0;
    float time = 0;
    Vector3 moveDirection;
    Camera c;
    Animator animator;
    bool isIdle = true;
    void Start()
    {
    }
    void FixedUpdate()
    {

       




        time += Time.deltaTime;
       
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * speed * 150.0f;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * speed * 3.0f;

        t.Rotate(0, x, 0);
        t.Translate(0, 0, z);


    }


}
