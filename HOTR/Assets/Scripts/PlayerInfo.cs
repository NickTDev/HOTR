using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerInfo : MonoBehaviour
{
    public TextMeshProUGUI heldIngText;
    public TextMeshProUGUI heldCupText;
    public TextMeshProUGUI debtText;
    public TextMeshProUGUI quotaText;
    public TextMeshProUGUI earningsText;

    DebtManager debtManager;
    HeldManager heldManager;

    private void Start()
    {
        debtManager = GameObject.Find("DebtManager").GetComponent<DebtManager>();
        heldManager = GameObject.Find("Player").GetComponentInChildren<HeldManager>();
    }

    private void FixedUpdate()
    {
        heldIngText.text = "Held Ingredient: " + heldManager.currentHeldIngredient.ingredientName;
        if (heldManager.isHoldingCup)
        {
            heldCupText.text = "Held Glass: Glass";
        }
        else
        {
            heldCupText.text = "Held Glass: None";
        }

        debtText.text = "Current Debt: " + debtManager.currentDebt.ToString();
        quotaText.text = "Shift Quota: " + debtManager.currentShiftQuota.ToString();
        earningsText.text = "Earnings: " + debtManager.currentShiftEarnings.ToString();
    }
}
