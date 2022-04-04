using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Movement), typeof(Animator))]
public class Animation : MonoBehaviour
{
    Movement movement;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {   
        movement = GetComponent<Movement>();
        animator = GetComponent<Animator>();
        movement.onMove += PlayMoveAnimation;
        movement.onStopMove += StopMoveAnimation;
        movement.onClicked += StopAnimation;
    }

   
    void PlayMoveAnimation()
    {
        if (transform.position.x == movement.direction.x)
        {
            return;
        }
        animator.SetBool("isMove", true);
    }
    void StopMoveAnimation()
    {
        animator.SetBool("isMove", false);
    }
    void StopAnimation()
    {
    }
}
