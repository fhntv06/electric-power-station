using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEditor.PackageManager.Requests;

public class FormingListController : MonoBehaviour
{
    // prefabs Instruction and Rules
    public GameObject prefabCard;

    public GameObject message;
    public GameObject preloader;

    public Transform contentTextView;
    public Transform toggle;
    public Transform parentCard;

    public GameObject openWindow;
    public GlobalNavigation GlobalNavigation;
    public SortingController SortingController;

    public List<TextObject> listObjects = new List<TextObject>(0);
    TextObject dataObject;

    public string whatDataType;
    string urlData = "http://substation/data.php";

    string emptyText = "Раздел пуст";
    string errorText = "Данные не загружены.\r\nПопробуйте позже!";
    Color errorColor = new Color(255, 0, 0);
    string errorTypeDataText = "Ошибка сервера.\r\nНе верный формат данных!";

    public void getData()
    {
        if (parentCard.childCount != 0)
            return;

        message.SetActive(false);
        preloader.SetActive(true);

        foreach (Transform card in parentCard)
            Destroy(card.gameObject);

        StartCoroutine(GetCardCoroutine());
    }
    public void postPassInstruction()
    {
        StartCoroutine(PostPassInstruction());
    }
    void FormingBtnTextViewer(GameObject newCard, int count)
    {
        newCard.transform.Find("BtnView").GetComponent<ViewTextController>().content = contentTextView;
        newCard.transform.Find("BtnView").GetComponent<ViewTextController>().toggle = toggle;
        newCard.transform.Find("BtnView").GetComponent<ViewTextController>().TextObject = listObjects[count];

        newCard.transform.Find("BtnView").GetComponent<Navigation>().openWindow = openWindow;
        newCard.transform.Find("BtnView").GetComponent<Navigation>().GlobalNavigation = GlobalNavigation;
    }
    void FormingCardTextViewer(Response response)
    {
        int count = 0;
        foreach (CardStruct card in response.cards)
        {
            GameObject newCard = Instantiate(prefabCard, new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0));

            if (card.pass != true)
                newCard.transform.Find("Pass").GetComponent<Image>().enabled = false;

            newCard.tag = card.tag;

            newCard.transform.Find("Title").GetComponent<Text>().text = card.title;

            FormingBtnTextViewer(newCard, count);

            newCard.transform.SetParent(parentCard);
            count++;
        }

        SortingController.FormingList();
    }

    public IEnumerator GetCardCoroutine()
    {

        string url = urlData + "?action=get" + "&type=" + whatDataType;
        UnityWebRequest request = UnityWebRequest.Get(url);

        request.SetRequestHeader("Content-Type", "application/json");
        yield return request.SendWebRequest();
        yield return new WaitForSeconds(.1f);
        preloader.SetActive(false);

        if (request.result == UnityWebRequest.Result.ConnectionError)
        {
            message.SetActive(true);
            message.GetComponent<Text>().text = errorText;
            message.GetComponent<Text>().color = errorColor;

            yield return 0;

        } else
        {
            try
            {
                Response response = JsonUtility.FromJson<Response>(request.downloadHandler.text);

                if (response.cards.Length == 0)
                {
                    message.SetActive(true);
                    message.GetComponent<Text>().text = emptyText;
                }
                else
                {
                    message.SetActive(false);
                    FormingCardTextViewer(response);
                }
            }
            catch (Exception ex)
            {
                message.GetComponent<Text>().text = errorTypeDataText;
            }
        }
    }

    public IEnumerator PostPassInstruction()
    {
        string btnName = "";
        foreach (Transform child in toggle.Find("Btns"))
            if (child.name.StartsWith("Set_pass-"))
                btnName = child.name;

        int indexSeparatorName = btnName.IndexOf("_") + 1;
        int indexSeparatorId = btnName.IndexOf("-");
        string field = btnName.Substring(indexSeparatorName, indexSeparatorId - indexSeparatorName);
        string id = btnName.Substring(indexSeparatorId + 1);

        string url = urlData + "?action=post&type=" + whatDataType + "&field=" + field + "&value=1" + "&id=" + id;
        UnityWebRequest request = UnityWebRequest.Get(url);
        yield return request.SendWebRequest();

        getData();
    }
}
