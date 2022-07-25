using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIRotator : MonoBehaviour
{
    public Canvas UICanvas;
    private GameObject mainCamera;

    private void OnEnable()
    {
        GameManager.GameIsOver += HideCanvas;
    }

    private void OnDisable()
    {
        GameManager.GameIsOver -= HideCanvas;
    }


    private void Awake()
    {
        mainCamera = GameObject.FindWithTag("MainCamera");
    }

    private void LateUpdate()
    {
        RotateCanvas();
    }

    public void RotateCanvas()
    {
        if (mainCamera != null)
        {
            var camXform = mainCamera.transform;
            var forward = transform.position - camXform.position;
            forward.Normalize();
            var up = Vector3.Cross(forward, camXform.right);

            UICanvas.GetComponent<RectTransform>().localRotation = Quaternion.Inverse(transform.rotation) * Quaternion.LookRotation(forward, up);
        }
    }

    public void HideCanvas()
    {
        UICanvas.enabled = false;
    }
}
