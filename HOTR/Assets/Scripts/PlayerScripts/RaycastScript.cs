using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastScript : MonoBehaviour
{
    Camera cam;
    public LayerMask mask;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        //Draw Ray
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 10f;
        mousePos = cam.ScreenToWorldPoint(mousePos);
        Debug.DrawRay(transform.position, mousePos-transform.position, Color.blue);

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100, mask))
            {
                if (hit.transform.tag == "Ingredient")
                {
                    GameObject[] ingredients = GameObject.FindGameObjectsWithTag("Ingredient");
                    for (int i = 0; i < ingredients.Length; i++)
                    {
                        ingredients[i].GetComponent<IngredientScript>().ingredientValues.isHeld = false;
                    }

                    hit.transform.GetComponent<IngredientScript>().ingredientValues.isHeld = true;
                    player.GetComponentInChildren<HeldManager>().currentHeldIngredient = hit.transform.GetComponent<IngredientScript>().ingredientValues;
                    Debug.Log("Currently Holding: " + hit.transform.GetComponent<IngredientScript>().ingredientValues.name);
                }
                else if (hit.transform.tag == "Glass")
                {
                    if (player.GetComponentInChildren<HeldManager>().isHoldingCup == false)
                    {
                        if (player.GetComponentInChildren<HeldManager>().currentHeldIngredient.name != "NullIngredient")
                        {
                            Debug.Log("Added Ingredient to Cup");
                            hit.transform.GetComponentInChildren<GlassManager>().listOfInside.Add(player.GetComponentInChildren<HeldManager>().currentHeldIngredient.name);
                        }
                    }
                }
                else if (hit.transform.tag == "Bar")
                {
                    if (player.GetComponentInChildren<HeldManager>().isHoldingCup == true)
                    {
                        hit.transform.GetComponent<CheckOrderCorrect>().checkIfCorrect();
                    }
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100, mask))
            {
                if (hit.transform.tag == "Glass")
                {
                    if (player.GetComponentInChildren<HeldManager>().isHoldingCup == true)
                    {
                        Debug.Log("Setting Down Glass");
                        player.GetComponentInChildren<HeldManager>().isHoldingCup = false;
                    }
                    else
                    {
                        Debug.Log("Picking Up Glass");
                        player.GetComponentInChildren<HeldManager>().isHoldingCup = true;
                    }
                }
                else if (hit.transform.tag == "Device")
                {
                    if (player.GetComponentInChildren<HeldManager>().isHoldingCup == true)
                    {
                        Debug.Log("Loading into Device");
                        GameObject.Find("MixingCup").GetComponentInChildren<GlassManager>().listOfInside.Add(hit.transform.GetComponent<DeviceScript>().deviceValues.name);
                        player.GetComponentInChildren<HeldManager>().isHoldingCup = false;
                        hit.transform.GetComponent<DeviceScript>().useDevice();
                    }
                    else if (player.GetComponentInChildren<HeldManager>().isHoldingCup == false && hit.transform.GetComponent<DeviceScript>().inUse == false)
                    {
                        Debug.Log("Taking out of Device");
                        player.GetComponentInChildren<HeldManager>().isHoldingCup = true;
                    }
                }
            }
        }
    }
}
