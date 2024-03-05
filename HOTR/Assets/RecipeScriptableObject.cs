using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/RecipeScriptableObject", order = 2)]
public class RecipeScriptableObject : ScriptableObject
{
    public string recipeName;
    public int numIngredients;
    public IngredientScriptableObject[] ingredients;
    public float price;
}
