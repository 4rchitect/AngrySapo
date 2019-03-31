using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(Animator))]
public class SapoAnimationController : MonoBehaviour
{
    public event Action OnJumpEvent;
    public event Action OnFallEvent;
    public event Action OnGroundEvent;

    private Animator animator;
    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Die()
    {

    }

    public void OnJump()
    {
        if (OnJumpEvent != null)
        {
            OnJumpEvent.Invoke();
        }
        animator.SetTrigger("OnJump");
    }

    public void OnFall()
    {
        if (OnFallEvent != null)
        {
            OnFallEvent.Invoke();
        }
        animator.SetTrigger("OnFall");

    }

    public void OnGround()
    {
        if (OnGroundEvent != null)
        {
            OnGroundEvent.Invoke();
        }
        animator.SetTrigger("OnGround");

    }


}
