using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]

public class EndBattle : State
{
    public override void Init()
    {
        mainUI.ShowResultPanel();

        if (player.IsLife)
        {
            mainUI.ShowTurnMessage(">> YOU WIN <<");
        }
        else
        {
            mainUI.ShowTurnMessage(">> YOU LOSE <<");
        }
    }

    public override void Run()
    {
        if (isFinished) return;
    }
}
