using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DiceBoard : MonoBehaviour
{
    public bool HaveDiceValue;
    public bool WasRoll;
    public bool WasShake;

    [SerializeField] private GameObject dicePrefab;
    [SerializeField] private Transform spawnPointDice;
    [Range(0.1f, 1)]
    [SerializeField] private float forcePower;
    [SerializeField] private TextMeshProUGUI diceValueTMP;
    [SerializeField] private TextMeshProUGUI messageToDo;
    [SerializeField] private ParticleSystem shakeParticleSystem;
    [SerializeField] private RawImage activeZone;

    public Dice dice;
    private Vector3 forceDirection;
    private Vector3 diceRotation;

    private void OnEnable()
    {
        TouchPad.TouchStart += ShakeDice;
        TouchPad.TouchEnd += RollDice;
    }

    private void OnDisable()
    {
        TouchPad.TouchStart -= ShakeDice;
        TouchPad.TouchEnd -= RollDice;
    }

    public void Init()
    {
        WasRoll = false;
        WasShake = false;
    }

    public void ActivateTouchPad(bool activate)
    {
        if (activate)
        {
            activeZone.raycastTarget = true;
        }
        else
        {
            activeZone.raycastTarget = false;
        }
    }

    public void ShakeDice()
    {
        //if (WasShake) return;
        //WasShake = true;
        shakeParticleSystem.Play();
        WriteMessage("Shaking");
    }

    public void RollDice()
    {
        if (WasRoll) return;
        WasRoll = true;

        forceDirection = new Vector3(Random.Range(-2, 2), 0.1f, 1);

        diceRotation = new Vector3(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360));

        var newDice = Instantiate(dicePrefab, spawnPointDice.position, Quaternion.LookRotation(diceRotation));
        newDice.GetComponent<Rigidbody>().AddForce(forceDirection * forcePower, ForceMode.Impulse);
        dice = newDice.GetComponent<Dice>();

        shakeParticleSystem.Stop();

        WriteMessage(" ");
        ActivateTouchPad(false);
    }

    public void WriteMessage(string message)
    {
        messageToDo.text = message;
    }
}
