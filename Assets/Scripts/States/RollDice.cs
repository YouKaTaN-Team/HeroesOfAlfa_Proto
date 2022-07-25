using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]

public class RollDice : State
{
    private float timeBeforeRoll;
    private float delayBeforeRoll;

    private float timeAfterRoll;
    private float delayToGetDiceValue;

    public override void Init()
    {
        diceBoard.Init();

        if (gameManager.isPlayerTurn)
        {
            diceBoard.ActivateTouchPad(true);
            diceBoard.WriteMessage("Touch and press for roll dice");
        }
        else
        {
            delayBeforeRoll = 2;//Random.Range(1, 2);
            diceBoard.ActivateTouchPad(false);
            diceBoard.WriteMessage("Waiting for enemy roll dice");
        }

        delayToGetDiceValue = 3;
    }

    public override void Run()
    {
        if (isFinished) return;

        Rolling();
    }

    private void Rolling()
    {
        if (gameManager.isPlayerTurn)
        {
            if (diceBoard.WasRoll)
            {
                timeAfterRoll += Time.deltaTime;
                if (timeAfterRoll > delayToGetDiceValue)
                {
                    gameManager.CurrentDiceValue = diceBoard.dice.GetDiceValue();
                    isFinished = true;
                }
            }
        }
        else
        {
            timeBeforeRoll += Time.deltaTime;
            if (timeBeforeRoll > delayBeforeRoll && timeBeforeRoll < delayBeforeRoll * 2)
            {
                diceBoard.ShakeDice();
            }

            if (timeBeforeRoll > delayBeforeRoll * 2)
            {
                diceBoard.RollDice();

                if (diceBoard.WasRoll)
                {
                    timeAfterRoll += Time.deltaTime;
                    if (timeAfterRoll > delayToGetDiceValue)
                    {
                        gameManager.CurrentDiceValue = diceBoard.dice.GetDiceValue();
                        Debug.Log("Dice value: " + diceBoard.dice.GetDiceValue().ToString());
                        isFinished = true;
                    }
                }
            }
        }
    }
}
