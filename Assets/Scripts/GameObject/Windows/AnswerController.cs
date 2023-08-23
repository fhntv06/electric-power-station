using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerController : MonoBehaviour
{
    public RulesInfringementController RuleInfringement;
    public DataErrors DataError;
    public GameObject TextTaskComplete;
    public GameObject hiddenWrapper;
    public GameObject hiddenWindow;

    public Navigation Navigation;

    public Button btnAnswer;

    string trueAnswer = "true";
    string falseAnswer = "false";
    public List<string> arCheckButtons = new List<string>(5);

    Color32 color;
    Color32 red = new Color32(255, 0, 0, 255);
    Color32 green = new Color32(45, 255, 0, 255);

    // метод для кнопок
    // example view name button: [name]_true / false
    // name must end for true or false
    public void CheckAnswerTheQuestion() // clickButton - Question_window
    {
        string name = gameObject.name;
        // coloring answers
        if (name.EndsWith(trueAnswer))
        {
            color = green;
        }

        if (name.EndsWith(falseAnswer))
        {
            color = red;
            RuleInfringement.FormingListIndexsErrorsType(DataError);
        }

        // gameObject.GetComponent<Button>().interactable = false;
        transform.Find("Text").GetComponent<Text>().color = color;
        btnAnswer.interactable = true;
    }

    public void FormingArCheckButtons(string name)
    {
        arCheckButtons.Add(name);
    }
    public void EndAnswerOnQuestion()
    {
        // checked all buttons
        foreach (Transform child in transform)
        {
            bool contain = arCheckButtons.Contains(child.name);
            if (!contain && child.name.EndsWith(trueAnswer))
                RuleInfringement.FormingListIndexsErrorsType(DataError);
        }

        arCheckButtons.Clear();
        hiddenWindow.GetComponent<AnswerController>().StartTransition();
    }

    // method for parent button
    public void StartTransition()
    {
        StartCoroutine(TheEndTask());
    }
    IEnumerator TheEndTask()
    {
        yield return new WaitForSeconds(2);
        TextTaskComplete.SetActive(true);
        hiddenWrapper.SetActive(false);
        yield return new WaitForSeconds(3);
        Navigation.openWindow.SetActive(true);
        RuleInfringement.AddedErrorInListErrors();
        hiddenWindow.SetActive(false);
    }
}
