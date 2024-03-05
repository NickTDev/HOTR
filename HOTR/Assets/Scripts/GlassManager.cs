using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassManager : MonoBehaviour
{
    public List<string> listOfInside = new List<string>();

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            Debug.Log("Current Ingredients");
            for (int i = 0; i < listOfInside.Count; i++)
            {
                Debug.Log(listOfInside[i]);
            }
        }
    }
}
