using UnityEngine;

public class Torch : MonoBehaviour
{
    public AnimationCurve curve;

    [SerializeField] private Light pointLight;

    private void Start()
    {
        curve.preWrapMode = WrapMode.PingPong;
        curve.postWrapMode = WrapMode.PingPong;
    }

    private void Update()
    {
        pointLight.intensity = curve.Evaluate(Time.time);
    }
}
