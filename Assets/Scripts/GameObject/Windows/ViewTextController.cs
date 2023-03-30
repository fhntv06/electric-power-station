using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ViewTextController : MonoBehaviour
{
    public Transform content;

    public DataRule DataRule;

    // пример prefab titleBig
    public GameObject prefabTitleBig;

    // пример prefab titleSmall
    public GameObject prefabTitleSmall;

    // пример prefab text
    public GameObject prefabText;

    public Transform toggle;

    string replaceHim = "<br>";
    string endLine = "\r\n    ";

    void FormingText(string text, GameObject prefab)
    {
        GameObject newText = Instantiate(prefab, new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0));
        newText.transform.localScale = new Vector3(1, 1, 1);
        newText.GetComponent<Text>().text = text.Replace(replaceHim, endLine);
        newText.transform.SetParent(content);
    }
    
    public void InsertDataContent(int indexToggleBtn)
    {
        foreach (Transform text in content)
            Destroy(text.gameObject);

        FormingText(DataRule.titleBig, prefabTitleBig);

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
