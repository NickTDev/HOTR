using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomOrder : MonoBehaviour
{
    public RecipeScriptableObject[] recipes;
    public RecipeScriptableObject currentRecipe;
    public GameObject ingredientSpace1;
    public GameObject ingredientSpace2;
    public GameObject ingredientSpace3;

    //Temporary
    public GameObject demonSpace;
    public GameObject demon;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            clearOrder();
            generateOrder();
        }
    }

    public void clearOrder()
    {
        GameObject[] old = GameObject.FindGameObjectsWithTag("sign");
        for (int i = 0; i < old.Length; i++)
        {
            Destroy(old[i]);
        }

        GameObject[] old2 = GameObject.FindGameObjectsWithTag("Demon");
        for (int i = 0; i < old2.Length; i++)
        {
            Destroy(old2[i]);
        }
    }

    public void newOrder(float waitTime)
    {
        clearOrder();
        Invoke("generateOrder", waitTime);
    }

    public void generateOrder()
    {
        int rand = Random.Range(0, recipes.Length);
        currentRecipe = recipes[rand];
        Debug.Log(rand);

        Instantiate(recipes[rand].ingredients[0].sign, ingredientSpace1.transform.position, Quaternion.identity);
        Instantiate(recipes[rand].ingredients[1].sign, ingredientSpace2.transform.position, Quaternion.identity);
        Instantiate(recipes[rand].ingredients[2].sign, ingredientSpace3.transform.position, Quaternion.identity);
        Instantiate(demon, demonSpace.transform.position, Quaternion.Euler(0, 90, 0));
    }
}
