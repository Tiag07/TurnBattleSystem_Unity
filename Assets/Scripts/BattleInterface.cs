﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace BattleSystem
{
    public class BattleInterface : MonoBehaviour
    {
        [SerializeField] TMP_Text txtFightersSequence;
        [SerializeField] TMP_Text txtCurrentFighter;
        [SerializeField] Button btnStartTurn, btnSkipTurn;
        [SerializeField] GameObject pnlChooseAction;
        [SerializeField] Color titleColor;
        string titleColorHex;

        public void Start()
        {
            titleColorHex = string.Concat("#", ColorUtility.ToHtmlStringRGB(titleColor));
            txtFightersSequence.enabled = false;
            pnlChooseAction.SetActive(false);
            btnSkipTurn.gameObject.SetActive(false);
            btnStartTurn.gameObject.SetActive(true);
        }
        public void OnFightersOrderSorted(List<Fighter> fighters)
        {
            txtFightersSequence.text = string.Concat("<color=",titleColorHex,">Order:</color><br>");
            foreach(Fighter fighter in fighters)
            {
                txtFightersSequence.text += string.Concat(fighter.nickName, " <color=", titleColorHex, ">", fighter.currentHp, "/", fighter.currentHp, "</color>",  "<br>");
            }
            txtFightersSequence.enabled = true;

            Fighter currentFighter = fighters[0];
            RefreshCurrentFighterInterface(currentFighter);
        }

        void RefreshCurrentFighterInterface(Fighter currentFighter)
        {     
            txtCurrentFighter.text = string.Concat("<color=", titleColorHex, ">Fighter Turn:</color><br>", currentFighter.nickName);
            txtCurrentFighter.text += string.Concat("<br><color=", titleColorHex, ">HP:</color><br>", currentFighter.maxHp, "/", currentFighter.currentHp);
        }

        public void EnableOrDisableControlUI(bool controlledFighterTurn)
        {
            if (controlledFighterTurn)
            {
                btnStartTurn.gameObject.SetActive(false);
                pnlChooseAction.SetActive(true);
                btnSkipTurn.gameObject.SetActive(false);
            }
            else
            {
                pnlChooseAction.SetActive(false);
                btnSkipTurn.gameObject.SetActive(true);
            }
            
        }

    }
}