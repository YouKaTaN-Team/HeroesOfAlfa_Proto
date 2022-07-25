using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static Action GameIsOver;
    public bool isPlayerTurn;
    public int CurrentDiceValue;

    [Header("States: ")]
    public State CurrentState;
    public State[] States;

    [Header("Elements for states: ")]
    public MainUI MainUI;
    public Enemy Enemy;
    public Player Player;
    public DiceBoard DiceBoard;
    public SkillsPanel SkillsPanel;

    private void Start()
    {
        isPlayerTurn = true;
        SetState(States[0]);
    }

    private void FixedUpdate()
    {
        if (!CurrentState.isFinished)
        {
            CurrentState.Run();
        }
        else
        {
            var nextStateId = CurrentState.stateID + 1;
            NextState(nextStateId);
        }
    }

    private void NextState(int stateID)
    {
        SetState(States[stateID]);
    }

    private  void SetState(State state)
    {
        CurrentState = Instantiate(state);

        CurrentState.gameManager = this;
        CurrentState.mainUI = MainUI;
        CurrentState.enemy = Enemy;
        CurrentState.player = Player;
        CurrentState.diceBoard = DiceBoard;
        CurrentState.skillsPanel = SkillsPanel;

        CurrentState.Init();
    }

    public void ChangeTurn()
    {
        SetState(States[1]);
    }

    public void RestartGame()
    {
        LoadScene(0);
    }

    public void LoadScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }
}
