using System.Collections;
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
    
    Color32 color;
    Color32 red = new Color32(255, 0, 0, 255);
    Color32 green = new Color32(45, 255, 0, 255);

    // ����� ��� ������
    // ��� ����� ������: [name]_true / false
    // ��� ������ ������������ �� true / false
    public void CheckAnswerTheQuestion()
    {
        // ��������� �������
        if (gameObject.name.EndsWith(trueAnswer))
            color = green;
            StartCoroutine(TheEndTask());


        if (gameObject.name.EndsWith(falseAnswer))
            color = red;

        gameObject.GetComponent<Button>().interactable = false;
        transform.Find("Text").GetComponent<Text>().color = color;
    }

    // ����� ��� �������� ������
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
