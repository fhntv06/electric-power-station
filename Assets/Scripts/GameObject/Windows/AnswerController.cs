using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.UI;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;

public class AnswerController : MonoBehaviour
{
    public GameObject TextTaskComplete;
    public GameObject openWindow;
    public GameObject hidden;
    public GameObject hiddenWindow;

    public Navigation Navigation;

    string trueAnswer = "true";
    string falseAnswer = "false";
    
    Color color = new Color(45, 255, 0, 255);
    Color red = new Color(255, 0, 0, 255);
    Color green = new Color(45, 255, 0, 255);

    // ����� ��� ������
    // ��� ����� ������: [name]_true / false
    // ��� ������ ������������ �� true / false
    public void CheckAnswerTheQuestion()
    {
        // ��������� �������
        if (gameObject.name.EndsWith(trueAnswer))
            color = green;
            StartCorrutines();


        if (gameObject.name.EndsWith(falseAnswer))
            color = red;

        gameObject.GetComponent<Button>().interactable = false;
        transform.Find("Text").GetComponent<Text>().color = color;
    }

    // ����� ��� �������� ������
    public void StartCorrutines()
    {
        StartCoroutine(TheEndTask());

    }
    IEnumerator TheEndTask()
    {
        yield return new WaitForSeconds(2);
        TextTaskComplete.SetActive(true);
        hidden.SetActive(false);
        yield return new WaitForSeconds(3);
        Navigation.OpenTargetWindow();
        hiddenWindow.SetActive(false);
    }
}
