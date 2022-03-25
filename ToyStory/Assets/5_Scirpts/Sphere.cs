using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour
{
    float h;
    float v;
    Rigidbody move;
    Vector3 sphere;
    public float speed;
    //public Camera cam;
    bool isBorder;
    float wDown;
    public GameObject cams;

    void Awake()
    {
        move = GetComponent<Rigidbody>();
    }

    void Update()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");
    
        sphere = new Vector3(h, 0, v).normalized;
        Turn();
        transform.position += Vector3.zero;
        if(!isBorder)
             transform.position += sphere * Time.deltaTime * speed * (isBorder ? 0.3f : 1);
    }

    void Turn()
    {
        // 키보드에 의한 회전
        transform.LookAt(transform.position + sphere);
        
    }
    
    void FixedUpdate()
    {
        StopToWall();
    }

    void StopToWall()
    {
        Debug.DrawRay(transform.position, transform.forward * 15,  Color.magenta);
        isBorder = Physics.Raycast(transform.position,
            transform.forward, 15, LayerMask.GetMask("Wall"));
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        if (other.gameObject.layer == 7)
        {
            Camera cam = cams.GetComponent<Camera>();
            Debug.Log("여기는 들어오긴함");
            cam.Anim();
        }
    }
}
