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

    // ����� ��� ������
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

        gameObject.GetComponent<Button>().interactable = false;
        transform.Find("Text").GetComponent<Text>().color = color;
        btnAnswer.interactable = true;
    }

    public void FormingArCheckButtons(string name)
    {
        arCheckButtons.Add(name);
    }
    public void EndAnswerOnQuestion()
    {
        List<Transform> arButtonNotCheck = new List<Transform>(5);

        // checked all buttons
        foreach (Transform child in transform)
            foreach (string buttonName in arCheckButtons)
                if (buttonName != child.name)
                    arButtonNotCheck.Add(child);

        // checked when person don't click for button
        foreach (Transform button in arButtonNotCheck)
        {
            print("������ � arButtonNotCheck: " + button.name);

            if (button.name.EndsWith(trueAnswer))
            {
                RuleInfringement.FormingListIndexsErrorsType(DataError);
                print("�� ����������: " + button.name);
            }
        }
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
