using UnityEngine;

public class Dice : MonoBehaviour
{
    public int DiceValue;
    [SerializeField] private Sensor[] sensors;

    private float delay;
    private float timeIdle;
    private Transform lastTransform;

    private void Start()
    {
        DiceValue = 0;
        delay = 1.5f;
    }

    private void Update()
    {
        //CheckMovement();

        SetDiceValue();
    }

    //private void LateUpdate()
    //{
    //    lastTransform.position = transform.position;
    //}

    public int GetDiceValue()
    {
        return DiceValue;
    }

    private int SetDiceValue()
    {
        for(int i = 0; i < sensors.Length; i++)
        {
            if (sensors[i].sensorIsActive)
            {
                DiceValue = sensors[i].Value;
            }
        }
        return DiceValue;
    }

    //private void CheckMovement()
    //{
    //    if (transform.position == lastTransform.position)
    //    {
    //        timeIdle += Time.deltaTime;

    //        if (timeIdle > delay)
    //        {
    //            Debug.Log("Dice is stopped after: " + timeIdle + " sec");
    //            GetDiceValue();
    //        }
    //    }
    //}

}
