using System.Collections;
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

    string trueAnswer = "true";
    string falseAnswer = "false";
    
    Color32 color;
    Color32 red = new Color32(255, 0, 0, 255);
    Color32 green = new Color32(45, 255, 0, 255);

    // метод для кнопок
    // вид имени кнопки: [name]_true / false
    // имя должно оканчиваться на true / false
    public void CheckAnswerTheQuestion() // clickButton - Question_window
    {
        // подсветка ответов
        if (gameObject.name.EndsWith(trueAnswer))
        {
            color = green;
            hiddenWindow.GetComponent<AnswerController>().StartTransition();
        }

        if (gameObject.name.EndsWith(falseAnswer))
        {
            color = red;
            RuleInfringement.FormingListIndexsErrorsType(DataError);
        }

        gameObject.GetComponent<Button>().interactable = false;
        transform.Find("Text").GetComponent<Text>().color = color;
    }

    // метод для родителя кнопок
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
