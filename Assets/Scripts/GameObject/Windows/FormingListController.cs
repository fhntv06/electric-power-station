using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.EventSystems;

public class FormingListController : MonoBehaviour
{
    public GlobalVariables GlobalVariables;
    public MethodsResponse MethodsResponse;
    // prefabs Instruction and Rules
    public GameObject prefabCard;

    public GameObject message;
    public GameObject preloader;

    public Transform parentCard;
    public Transform parentButtons;

    public Transform toggle;

    public SortingController SortingController;

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

        GetCardCoroutine();
    }
    public void postPassInstruction()
    {
        string btnName = "";
        foreach (Transform child in toggle.Find("Btns"))
            if (child.name.StartsWith("Set_pass-"))
                btnName = child.name;

        int indexSeparatorName = btnName.IndexOf("_") + 1;
        int indexSeparatorId = btnName.IndexOf("-");
        string field = btnName.Substring(indexSeparatorName, indexSeparatorId - indexSeparatorName);
        string id = btnName.Substring(indexSeparatorId + 1);
        string otherParams = "field=" + field + "&value=" + "1&" + "id=" + id;

        StartCoroutine(MethodsResponse.PostCommon(urlData, whatDataType, otherParams));

        getData();
    }
    void FormingBtnTextViewer(int count)
    {
        parentButtons.GetComponent<ViewTextController>().DataRule = GlobalVariables.DATA_INSTRUCTION_AND_RULE[count];

        foreach (Transform child in parentButtons)
            child.GetComponent<Button>().interactable = true;
    }

    void FormingCardResponse(Response response)
    {
        int count = 0;
        foreach (CardStruct card in response.cards)
        {
            GameObject newCard = Instantiate(prefabCard, new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0));
            Text Title = newCard.transform.Find("Title").GetComponent<Text>();
            Transform BtnView = newCard.transform.Find("BtnView");

            if (card.pass != true)
                newCard.transform.Find("Pass").GetComponent<Image>().enabled = false;


            newCard.tag = GlobalVariables.DATA_TASKS[count].tag;
            newCard.name = "Task_" + GlobalVariables.DATA_TASKS[count].id;
            Title.text = GlobalVariables.DATA_TASKS[count].title;
            BtnView.GetComponent<FormingListController>().parentButtons = parentButtons;
            BtnView.GetComponent<FormingListController>().GlobalVariables = GlobalVariables;
            BtnView.GetComponent<Button>().onClick.AddListener(delegate { void wrapperMethod() { ReadId(); } });

            newCard.transform.SetParent(parentCard);

            count++;
        }

        if (SortingController != null)
            SortingController.FormingList();
    }

    void ReadId()
    {
        string name = gameObject.transform.parent.name;
        int indexId = name.IndexOf("_");
        string id = name.Substring(indexId + 1);
        FormingBtnTextViewer(Convert.ToInt32(id));


        foreach (Transform child in parentButtons)
            child.GetComponent<Button>().interactable = true;
    }

    public void GetCardCoroutine()
    {
        UnityWebRequest request = (UnityWebRequest)MethodsResponse.GetCommon(urlData, whatDataType);

        preloader.SetActive(false);

        if (request.result == UnityWebRequest.Result.ConnectionError)
        {
            message.SetActive(true);
            message.GetComponent<Text>().text = errorText;
            message.GetComponent<Text>().color = errorColor;
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
                    FormingCardResponse(response);
                }
            }
            catch (Exception ex)
            {
                message.GetComponent<Text>().text = errorTypeDataText;
            }
        }
    }
}
