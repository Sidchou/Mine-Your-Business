using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lantern : MonoBehaviour
{
    [SerializeField]
    Animator animator;
    public static Action BadCoal;

    public void AnimateGoodCoal() {
        animator.SetTrigger("Shake1");
        
    }
    public void AnimateBadCoal()
    {
        animator.SetTrigger("Shake2");
        BadCoal?.Invoke();
    }
}
