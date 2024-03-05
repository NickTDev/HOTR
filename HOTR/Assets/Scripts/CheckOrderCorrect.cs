using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckOrderCorrect : MonoBehaviour
{
    RandomOrder currentOrder;
    List<string> currentContents;
    DebtManager debtManager;
    public float newOrderWaitTime;

    private void Start()
    {
        debtManager = GameObject.Find("DebtManager").GetComponent<DebtManager>();
    }

    public void checkIfCorrect()
    {
        bool isCorrect = true;
        currentOrder = GameObject.Find("OrderManager").GetComponent<RandomOrder>();
        currentContents = GameObject.Find("MixingCup").GetComponentInChildren<GlassManager>().listOfInside;

        if (currentContents.Count != currentOrder.currentRecipe.numIngredients)
        {
            isCorrect = false;
        }
        else
        {
            for (int i = 0; i < currentOrder.currentRecipe.numIngredients; i++)
            {
                if (currentContents[i] != currentOrder.currentRecipe.ingredients[i].name)
                {
                    isCorrect = false;
                    break;
                }
            }
        }

        if (isCorrect)
        {
            Debug.Log("Order is Correct");
            debtManager.gainEarnings(currentOrder.currentRecipe.price / 2);
        }
        else
        {
            Debug.Log("Order Failed");
            debtManager.loseEarnings(currentOrder.currentRecipe.price);
        }

        //Clear and Prepare for Next Order
        currentContents.Clear();
        currentOrder.newOrder(newOrderWaitTime);
    }
}
