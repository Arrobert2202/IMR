using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CactusController : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void StartAttack()
    {
        animator.SetBool("IsAttacking", true);
    }

    public void EndAttack()
    {
        animator.SetBool("IsAttacking", false);
    }

    void Update()
    {
        
    }
}
