using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(Rigidbody))]

public class PlayerController : MonoBehaviour
{
    [SerializeField] float walkspeed;
    [SerializeField] float runspeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     if(Input.GetKey(KeySetting.keys[KeyAction.Left]))   
     {
        Debug.Log("left");
     }
     else if(Input.GetKey(KeySetting.keys[KeyAction.Right]))   
     {
         Debug.Log("Right");
     }
     if(Input.GetKey(KeySetting.keys[KeyAction.Walk]))   
     {
         Debug.Log("Walk");
     }
     if(Input.GetKey(KeySetting.keys[KeyAction.Jump]))   
     {
         Debug.Log("Jump");
     }
    }
}