using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI title;
    [SerializeField] private TextMeshProUGUI turnMessage;

    [SerializeField] private RectTransform resoursePanel;
    [SerializeField] private RectTransform diceBoardPanel;
    [SerializeField] private RectTransform skillsPanel;
    [SerializeField] private RectTransform resultPanel;

    public void ShowResultPanel()
    {
        resultPanel.gameObject.SetActive(true);
    }

    public void HideResultPanel()
    {
        resultPanel.gameObject.SetActive(false);
    }

    public void ShowTurnMessage(string message)
    {
        turnMessage.text = message;
    }

}
