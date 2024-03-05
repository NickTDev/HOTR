using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeviceScript : MonoBehaviour
{
    public IngredientScriptableObject deviceValues;
    public float waitTimer;
    public bool inUse = false;

    public void useDevice()
    {
        inUse = true;
        GetComponentInChildren<DeviceTimerScript>().startTimer();
        Invoke("stopDevice", waitTimer);
    }

    void stopDevice()
    {
        inUse = false;
        Debug.Log("Device is done");
    }
}
