using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]

public class Attack : State
{
    private float currentAttackPoint;
    private float time;
    private float delayForDefense;

    public override void Init()
    {
        if (gameManager.isPlayerTurn)
        {
            player.Attack();
        }
        else
        {
            enemy.Attack();
        }

        delayForDefense = 0.5f;

        CalculateAttackPoints(gameManager.CurrentDiceValue, skillsPanel.SkillPoint);
    }

    public override void Run()
    {
        if (isFinished) return;

        AttackSomeOne();
    }

    private void AttackSomeOne()
    {
        time += Time.deltaTime;
        if (time > delayForDefense)
        {
            if (gameManager.isPlayerTurn)
            {
                enemy.GetAnimator().SetBool("Defense", true);
                enemy.GetDamage(currentAttackPoint);
            }
            else
            {
                player.GetAnimator().SetBool("Defense", true);
                player.GetDamage(currentAttackPoint);
            }

            Destroy(diceBoard.dice.gameObject);

            isFinished = true;
        }
    }

    private void CalculateAttackPoints(int valueDice, int skillPoint)
    {
        switch (valueDice)
        {
            case 1:
                currentAttackPoint = skillPoint * 0.7f;
                break;
            case 2:
                currentAttackPoint = skillPoint * 0.8f;
                break;
            case 3:
                currentAttackPoint = skillPoint * 0.9f;
                break;
            case 4:
                currentAttackPoint = skillPoint * 1f;
                break;
            case 5:
                currentAttackPoint = skillPoint * 1.1f;
                break;
            case 6:
                currentAttackPoint = skillPoint * 1.2f;
                break;

            default:
                currentAttackPoint = skillPoint * 0;
                Debug.Log("value not correct");
                break;
        }
    }
}
