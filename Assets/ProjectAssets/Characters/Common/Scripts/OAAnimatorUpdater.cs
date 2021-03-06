﻿using UnityEngine;

/// Used to update animator for state machine.
/// Use this on characters with a rigidbody2D
[RequireComponent(typeof(Animator), typeof(Rigidbody2D))]
public class OAAnimatorUpdater : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    [SerializeField]
    private Rigidbody2D rigid;

    [SerializeField]
    private float deadZone = 0.001f;

    void Awake()
    {
        if (!animator)
        {
            animator = GetComponent<Animator>();
        }

        if (!rigid)
        {
            rigid = GetComponent<Rigidbody2D>();
        }
    }

    void Update()
    {
        // TODO: maybe have this handle flipping sprite renderer

        if (rigid.velocity.x > deadZone || rigid.velocity.x < -deadZone)
        {
            animator.SetBool("hasHorizontalMovement", true); 
        }
        else
        {
            animator.SetBool("hasHorizontalMovement", false); 
        }

        if (rigid.velocity.y > deadZone || rigid.velocity.y < -deadZone) // TODO: falling or jumping
        {
            animator.SetBool("hasVerticalMovement", true);
            animator.SetBool("isVerticalMovUpwards", rigid.velocity.y > 0);
        }
        else
        {
            animator.SetBool("hasVerticalMovement", false);
        }
    }
}
