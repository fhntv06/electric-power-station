using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;

public class SortingController : MonoBehaviour
{
    public Dropdown dropdown;
    public Transform content;

    public List<Transform> children = new List<Transform>(0);

    public void FormingList()
    {
        dropdown.onValueChanged.AddListener(delegate { SortRulesAndInstructions(); });
        
        if (children.Count > 0)
            children.Clear();

        foreach (Transform card in content)
            children.Add(card);
    }
    public void SortRulesAndInstructions()
    {
        string tag = "";
        switch (dropdown.captionText.text)
        {
            case "Правила":
                tag = "Rule";
                break;
            case "Инструкции":
                tag = "Instruction";
                break;
        }

        foreach (Transform item in children)
        {
            if (tag != "")  
            {
                if (item.gameObject.CompareTag(tag))
                    item.gameObject.SetActive(true);
                else
                    item.gameObject.SetActive(false);
            } else
                item.gameObject.SetActive(true);
        }
    }
}
