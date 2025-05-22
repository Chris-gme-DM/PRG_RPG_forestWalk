using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationManage : MonoBehaviour
{
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void SetAnimatorValues(float moveX, float move›)
    {
        animator.SetFloat("moveX", moveX);
        animator.SetFloat("moveY", move›);
    }
}
