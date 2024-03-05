using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebtManager : MonoBehaviour
{
    public float startingDebt;
    public float currentDebt;
    public float currentShiftQuota;
    public float currentShiftEarnings;

    public void gainEarnings(float earn)
    {
        currentShiftEarnings += earn;
        Debug.Log("Current earned: " + currentShiftEarnings.ToString());
    }

    public void loseEarnings(float lose)
    {
        currentShiftEarnings -= lose;
        Debug.Log("Current earned: " + currentShiftEarnings.ToString());
    }
}
