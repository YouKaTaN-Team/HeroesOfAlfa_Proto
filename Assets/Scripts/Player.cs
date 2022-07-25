using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public bool IsLife;

    [SerializeField] private Image indicatorHP;

    [SerializeField] private Animator animator;

    [SerializeField] private ParticleSystem usualAttack;
    [SerializeField] private ParticleSystem powerAttack;

    private float hp;
    private float hpFull;

    public void Init()
    {
        animator.SetBool("Idle", true);
        animator.SetBool("Attack", false);
        animator.SetBool("Defense", false);
        animator.ResetTrigger("Death");

        IsLife = true;
        hpFull = 200;
        hp = hpFull;
    }

    public void GetDamage(float damage)
    {
        hp -= damage;

        indicatorHP.fillAmount = hp / hpFull;

        if (hp < 0)
        {
            IsLife = false;
            animator.SetTrigger("Death");
        }
    }

    public void Attack()
    {
        animator.SetBool("Attack", true);
        usualAttack.Play();
    }

    public void StayIdle()
    {
        animator.SetBool("Idle", true);
        animator.SetBool("Attack", false);
        animator.SetBool("Defense", false);
    }

    public Animator GetAnimator()
    {
        return animator;
    }
}
