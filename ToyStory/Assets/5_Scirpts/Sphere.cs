using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour
{
    float h;
    float v;
    
    Vector3 sphere;
    Vector3 currentSpeed;
    
    public float speed;
    public bool isMenu;
    
    //public Camera cam;
    bool isBorder;
    float wDown;
    public GameObject cams;
    Rigidbody _rigidbody;
    UIManager _mainManager;
    
    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _mainManager = GameObject.Find("GameUI").GetComponent<UIManager>();
    }

    void Update()
    {
        Menu();
        Move();
        Turn();
    }

    void Move()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");
        sphere = new Vector3(h, 0, v).normalized;
        if(!isBorder)
            transform.position += sphere * Time.deltaTime * speed * (isBorder ? 0.3f : 1);
    }
    void Turn()
    {
        // 키보드에 의한 회전
        transform.LookAt(transform.position + sphere);
        
    }

    void Menu()
    {
        Debug.Log(_mainManager.isSub);
        if (!_mainManager.isSub)
        {
            speed = 100;
        }
        else
        {
            speed = 0;
        }
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
