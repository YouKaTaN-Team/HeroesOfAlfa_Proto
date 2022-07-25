using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkillsPanel : MonoBehaviour
{
    public int SkillPoint;
    public bool WasChose;

    [SerializeField] private TextMeshProUGUI messageToDo;
    [SerializeField] private TextMeshProUGUI usualAttackTMP;
    [SerializeField] private TextMeshProUGUI powerAttackTMP;
    [SerializeField] private Toggle usualAttack;
    [SerializeField] private Toggle powerfullAttack;

    [SerializeField] private Toggle[] allSkils;

    [SerializeField] private Image enemyCheckMark_1;
    [SerializeField] private Image enemyCheckMark_2;

    private ToggleGroup allToggles;

    public void Init()
    {
        WasChose = false;
        WriteMessage("Choice skill: ");
        ActivateToggles(true);
        
        allToggles = GetComponent<ToggleGroup>();
        allToggles.SetAllTogglesOff();

        enemyCheckMark_1.enabled = false;
        enemyCheckMark_2.enabled = false;
    }

    public void WriteSkillPoints(int pointSkill_1, int pointSkill_2)
    {
        usualAttackTMP.text = pointSkill_1.ToString() + " points";
        powerAttackTMP.text = pointSkill_2.ToString() + " points";
    }

    public void UsualAttackChoice(int skillPoint)
    {
        WasChose = true;
        SkillPoint = skillPoint;
        WriteMessage("Usual attack was activated");
        enemyCheckMark_1.enabled = true;
        //usualAttack.graphic.GetComponent<Image>().enabled = true;
        ActivateToggles(false);
    }

    public void PowerfullAttackChoice(int skillPoint)
    {
        WasChose = true;
        SkillPoint = skillPoint;
        WriteMessage("Powerfull attack was activated");
        enemyCheckMark_2.enabled = true;
        //powerfullAttack.graphic.GetComponent<Image>().enabled = true;
        ActivateToggles(false);
    }

    public void WriteMessage(string message)
    {
        messageToDo.text = message;
    }

    public void ActivateToggles(bool activate)
    {
        if (activate)
        {
            foreach (Toggle toggle in allSkils)
            {
                toggle.interactable = true;
            }
        }
        else
        {
            foreach (Toggle toggle in allSkils)
            {
                toggle.interactable = false;
            }
        }
    }
}
