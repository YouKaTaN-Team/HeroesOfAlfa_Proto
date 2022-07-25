using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]

public class EndTurn : State
{
    private float time;
    private float delay;

    public override void Init()
    {
        mainUI.ShowTurnMessage(">> END TURN <<");

        player.StayIdle();
        enemy.StayIdle();

        skillsPanel.ActivateToggles(false);

        delay = 1;
    }

    public override void Run()
    {
        if (isFinished) return;

        CheckResults();
    }

    private void CheckResults()
    {
        time += Time.deltaTime;
        if (time > delay)
        {
            if (player.IsLife & enemy.IsLife)
            {
                if (gameManager.isPlayerTurn)
                {
                    gameManager.isPlayerTurn = false;
                }
                else
                {
                    gameManager.isPlayerTurn = true;
                }
                 
                gameManager.ChangeTurn();
            }
            else
            {
                isFinished = true;
            }
        }
    }
}
