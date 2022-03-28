using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour
{
    float h;
    float v;
    Vector3 sphere;
    public float speed;
    public bool isMenu;
    
    //public Camera cam;
    bool isBorder;
    float wDown;
    public GameObject cams;
    Rigidbody move;
    UIManager _uiManager;
    
    void Awake()
    {
        move = GetComponent<Rigidbody>();
        _uiManager = GameObject.Find("GameUI").GetComponent<UIManager>();
    }

    void Update()
    {
        Debug.Log(_uiManager.isSub);
        if(_uiManager.isSub)
            Move();
        Turn();
        transform.position += Vector3.zero;
        if(!isBorder)
             transform.position += sphere * Time.deltaTime * speed * (isBorder ? 0.3f : 1);
    }

    void Move()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");
        sphere = new Vector3(h, 0, v).normalized;
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
            CameraManager cam = cams.GetComponent<CameraManager>();
            Debug.Log("여기는 들어오긴함");
            cam.Anim();
        }
    }
}
