using UnityEngine;

[CreateAssetMenu]

public class StartBattle : State
{
    private float time;
    private float delayBeforeStart;

    public override void Init()
    {
        delayBeforeStart = 2;

        player.Init();
        enemy.Init();

        diceBoard.ActivateTouchPad(false);
    }

    public override void Run()
    {
        if (isFinished) return;

        Waiting();
    }

    private void Waiting()
    {
        time += Time.deltaTime;
        if (time > delayBeforeStart)
        {
            isFinished = true;
        }
    }
}
