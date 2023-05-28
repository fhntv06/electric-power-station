using System.Collections.Generic;
using UnityEngine;

public class ThingController : MonoBehaviour
{
    public GlobalVariables GlobalVariables;

    public RulesInfringementController RulesInfringement;
    
    public Transform PlayerThings;

    delegate void ListErrorsTypes(DataErrors error);
    public void PlayersTakeThing(Collider thing)
    {
        GameObject findedThing = PlayerThings.Find(thing.name).gameObject;
        if (!findedThing.activeSelf)
        {
            findedThing.SetActive(true);
            Destroy(thing.gameObject);
        }
    }

    // Checked things on player from arErrorThing array
    public void CheckThingOnPlayer()
    {
        foreach (Transform child in PlayerThings)
        {
            if (!child.gameObject.activeSelf)
            {
                foreach (DataErrors error in GlobalVariables.ErrorList.list)
                {
                    if (error.Name == child.name)
                    {
                        RulesInfringement.FormingListIndexsErrorsType(error);
                        print("Нарушение:" + child.name + " не надета!");
                    }
                }
            }
        }
    }

    public void ResetThingOnPlayer()
    {
        foreach(Transform child in PlayerThings) child.gameObject.SetActive(true);
    }
}
