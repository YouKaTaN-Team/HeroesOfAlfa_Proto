using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]

public class StartTurn : State
{
    private float time;
    private float delayBeforeTurn;

    public override void Init()
    {
        if (gameManager.isPlayerTurn)
        {
            mainUI.ShowTurnMessage(">> YOU TURN <<");

            skillsPanel.Init();
            skillsPanel.WriteSkillPoints(15, 20);
        }
        else
        {
            mainUI.ShowTurnMessage(">> ENEMY TURN <<");

            skillsPanel.Init();
            skillsPanel.WriteMessage("Enemy chooses a skill... ");
            skillsPanel.WriteSkillPoints(17, 22);

            delayBeforeTurn = 3; //Random.Range(2, 3);
        }
    }

    public override void Run()
    {
        if (isFinished) return;

        WaitingChoiceSkill();
    }

    private void WaitingChoiceSkill()
    {
        if (gameManager.isPlayerTurn)
        {
            if (skillsPanel.WasChose)
            {
                isFinished = true;
            }
        }
        else
        {
            time += Time.deltaTime;
            if (time > delayBeforeTurn)
            {
                var enemyChoice = Random.Range(0, 2);

                if(enemyChoice == 0)
                {
                    skillsPanel.UsualAttackChoice(17);
                }
                else
                {
                    skillsPanel.PowerfullAttackChoice(22);
                }
                
                isFinished = true;
            }
        }
    }
}
