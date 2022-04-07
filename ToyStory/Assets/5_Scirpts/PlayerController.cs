using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 0.1f;
    [SerializeField] float walkSpeed = 0;
    [SerializeField] float runSpeed = 1.0f;
    [SerializeField] float jumpPower = 3.0f;
    private CapsuleCollider col;
    private Rigidbody rb;
    private Animator anim;
    private AnimatorStateInfo currentBaseState;
    static int jumpState = Animator.StringToHash("Base Layer.Jump"); // 점프 스테이트만 가져옴
    void Start()
    {
        anim = GetComponent<Animator>();
        col = GetComponent<CapsuleCollider>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        currentBaseState = anim.GetCurrentAnimatorStateInfo(0);
        if(Input.GetKey(KeySetting.keys[KeyAction.LEFT]))
        {
              if(Input.GetKey(KeySetting.keys[KeyAction.WALK]))
            {
                anim.SetFloat("Speed", walkSpeed);
                transform.Translate(new Vector3(0,0,speed*0.5f*Time.deltaTime));
            }
            else
            {
                anim.SetFloat("Speed", runSpeed);
                transform.Translate(new Vector3(0,0,speed*Time.deltaTime));
            }
            transform.rotation = Quaternion.Euler(0,180,0);
            anim.SetBool("Move", true);
        }
        else if(Input.GetKey(KeySetting.keys[KeyAction.RIGHT]))
        {
            if(Input.GetKey(KeySetting.keys[KeyAction.WALK]))
            {
                anim.SetFloat("Speed", walkSpeed);
                transform.Translate(new Vector3(0,0,speed*0.5f*Time.deltaTime));
            }
            else
            {
                anim.SetFloat("Speed", runSpeed);
                transform.Translate(new Vector3(0,0,speed*Time.deltaTime));
            }
            transform.rotation = Quaternion.Euler(0,0,0);
            anim.SetBool("Move", true);  
        }
        else if(Input.GetKeyUp(KeySetting.keys[KeyAction.LEFT])||Input.GetKeyUp(KeySetting.keys[KeyAction.RIGHT]))
            anim.SetBool("Move", false);


        if (Input.GetKeyDown(KeySetting.keys[KeyAction.JUMP])) // 점프키를 누르면
        {
            if (!anim.IsInTransition(0)) // 현재 트랜지션이 수행 중이지 않다면
            {
                rb.AddForce(Vector3.up * jumpPower, ForceMode.VelocityChange);
                anim.SetBool("Jump", true); // 점프
            }
        } 
        if (currentBaseState.fullPathHash == jumpState && !anim.IsInTransition(0)) // 점프 중인 경우
        {
            anim.SetBool("Jump", false); // 이미 점프를 수행 중이므로 이제 FALSE로 설정
        }
        
    }
}
