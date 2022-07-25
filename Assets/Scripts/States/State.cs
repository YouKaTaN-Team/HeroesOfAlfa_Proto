using UnityEngine;

public abstract class State : ScriptableObject
{
    public bool isFinished { get; protected set; }

    public int stateID;

    [HideInInspector] public GameManager gameManager;
    [HideInInspector] public MainUI mainUI;
    [HideInInspector] public Enemy enemy;
    [HideInInspector] public Player player;
    [HideInInspector] public DiceBoard diceBoard;
    [HideInInspector] public SkillsPanel skillsPanel;

    public virtual void Init() { }
    public abstract void Run();
}
