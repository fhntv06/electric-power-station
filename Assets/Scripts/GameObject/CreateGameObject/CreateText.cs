using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class CreateText : MonoBehaviour
{

    public GameObject prefabText;

    List<string> arTitles = new List<string> { "Первый", "Второй", "Threeth", "Fourth", "Fiveth", "Sixth" };

    void Start()
    {
        CreateParagraph();
    }
    void CreateParagraph()
    {
        int count = 0;
        foreach (string title in arTitles)
        {
            Transform text = Instantiate(prefabText, new Vector3(0, 0, 0), Quaternion.identity).transform;
            text.gameObject.GetComponent<Text>().text = arTitles[count];
            text.SetParent(transform);
            count++;
        }
    }
}
