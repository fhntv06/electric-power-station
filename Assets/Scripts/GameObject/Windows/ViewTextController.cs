using UnityEngine;
using UnityEngine.UI;

public class ViewTextController : MonoBehaviour
{
    public Transform content;

    public DataRule DataRule;

    // ������ prefab titleBig
    public GameObject prefabTitleBig;

    // ������ prefab titleSmall
    public GameObject prefabTitleSmall;

    // ������ prefab text
    public GameObject prefabText;

    public Transform toggle;

    string replaceHim = "<br>";
    string endLine = "\r\n    ";

    void FormingText(string text, GameObject prefab)
    {
        Transform newText = Instantiate(prefab, new Vector3(0, 0, 0), Quaternion.identity).transform;
        newText.localScale = new Vector3(1, 1, 1);
        newText.GetComponent<Text>().text = text.Replace(replaceHim, endLine);
        newText.SetParent(content);
    }
    
    public void InsertDataContent(int indexToggleBtn)
    {
        foreach (Transform text in content)
            Destroy(text.gameObject);

        FormingText(DataRule.Title, prefabTitleBig);

        int count = 0;
        foreach (Transform item in toggle.Find("Btns"))
        {
            if (count == indexToggleBtn)
            {
                item.gameObject.SetActive(true);

                if (item.name.StartsWith("To"))
                    item.name = "To_tasks-" + DataRule.id;

                if (item.name.StartsWith("Set"))
                    item.name = "Set_pass-" + DataRule.id;
            }

            count++;
        }

        for (int i = 0; i < DataRule.titlesSmall.Length; i++)
        {
            FormingText(DataRule.titlesSmall[i], prefabTitleSmall);
            FormingText(DataRule.paragraphs[i], prefabText);
        }
    }
}
