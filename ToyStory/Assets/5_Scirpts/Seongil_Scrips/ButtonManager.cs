using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class ButtonManager : MonoBehaviour
{
    Animator _animator;
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        //Debug.Log(EventSystem.current.IsPointerOverGameObject());
    }

    public void ZoomOut()
    {
        _animator.SetTrigger("isExit");
    }

    public void ZoomIn()
    {
        _animator.SetTrigger("isOver");
    }
}
