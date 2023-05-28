using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitcherAnimationController : MonoBehaviour
{
    Animator animator;
    public void SetTriggerWalk()
    {
        animator.SetTrigger("Walk");
    }

    public void SetTriggerStand()
    {
        animator.SetTrigger("Stand");
    }
    IEnumerator Start()
    {
        animator = GetComponent<Animator>();
        yield return new WaitForSeconds(3);
        animator.SetTrigger("Stand");
    }

    public void SetAnimatorInt(int animId)
    {
        animator.SetInteger("animationId", animId);
    }
}
