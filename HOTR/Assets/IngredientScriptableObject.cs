using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/IngredientScriptableObject", order = 1)]
public class IngredientScriptableObject : ScriptableObject
{
    public string ingredientName;
    public bool isHeld;
    public GameObject toSpawn;
    public GameObject sign;
}
