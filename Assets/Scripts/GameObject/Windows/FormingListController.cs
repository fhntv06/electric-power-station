using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class FormingListController : MonoBehaviour
{
    public GlobalVariables GlobalVariables;
    public GlobalNavigation GlobalNavigation;
    public MethodsResponse MethodsResponse;
    // prefabs Instruction and Rules
    public GameObject prefabCard;

    public GameObject message;
    public GameObject preloader;

    public Transform parentCard;
    public Transform parentButtons;

    public Transform toggle;

    public SortingController SortingController;
    public GameObject TextViewWindow;
    public Transform contentText;

    public string whatDataType;
    string urlData = "http://substation/data.php";

    public string emptyText;
    public string errorText;
    public string errorTypeDataText;

    Color errorColor = new Color(255, 0, 0);
    
    Color fiveAwardColor = new Color(45, 255, 0);
    Color fourAwardColor = new Color(255, 247, 0);
    Color threeAwardColor = new Color(255, 102, 1);
    Color twoAwardColor = new Color(255, 0, 0);


    public void getData()
    {
        if (parentCard.childCount != 0)
            return;

        message.SetActive(false);
        preloader.SetActive(true);

        foreach (Transform card in parentCard)
            Destroy(card.gameObject);

        string otherParams = "";
        if (whatDataType == "exams")
            otherParams = "id=" + GlobalVariables.USER_ID;
        
        if (parentCard.gameObject.activeSelf)
            StartCoroutine(GetCardCoroutine(otherParams));
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
        parentButtons.GetComponent<ViewTextController>().DataRule = GlobalVariables.InstructionAndRuleList.list[count];
        
        foreach (Transform child in parentButtons)
        {
            if (child.name.EndsWith("Exam"))
            {
                child.GetComponent<Button>().interactable = GlobalVariables.AUTH_USER;
                child.Find("Auth_text").gameObject.SetActive(!GlobalVariables.AUTH_USER);
            } else
            {
                child.GetComponent<Button>().interactable = true;
            }
        }
    }

    void FormingCardResponse(Response response)
    {
        int count = 0;

        foreach (CardStruct card in response.cards)
        {
            Transform newCard = Instantiate(prefabCard, new Vector3(0, 0, 0), Quaternion.identity).transform;
            Text Title = newCard.Find("Title").GetComponent<Text>();

            if (whatDataType == "tasks" || whatDataType == "instructionandrule")
            {
                Transform BtnView = newCard.Find("BtnView");
                BtnView.GetComponent<FormingListController>().parentButtons = parentButtons;
                BtnView.GetComponent<FormingListController>().GlobalVariables = GlobalVariables;
                BtnView.GetComponent<Button>().onClick.AddListener(delegate { void wrapperMethod() { ReadId(); } });

                switch (whatDataType)
                {
                    case "instructionandrule":
                        FormingInstructionAndRuleCard(count, card, newCard, Title, BtnView);
                        break;
                    case "tasks":
                        FormingTasksCard(count, card, newCard, Title);
                        break;
                }
            }

            if (whatDataType == "exams")
                FormingExams(card, newCard, Title);

            newCard.SetParent(parentCard);

            count++;
        }

        if (SortingController != null)
            SortingController.FormingList();
    }
    void FormingExams(CardStruct card, Transform newCard, Text Title)
    {
        Text Award = newCard.Find("Award").GetComponent<Text>();
        Text Result = newCard.Find("Result").GetComponent<Text>();
        print(card.task);
        Title.text = GlobalVariables.TasksList.list[card.task].title;

        Result.text = GlobalVariables.USER_MAX_BALLS_METRIC / GlobalVariables.USER_MAX_AWARD * card.award + " / " + GlobalVariables.USER_MAX_BALLS_METRIC;
        Award.text = card.award.ToString();
        
        switch (card.award)
        {
            case 5:
                Result.color = fiveAwardColor;
                Award.color = fiveAwardColor;
                break;
            case 4:
                Result.color = fourAwardColor;
                Award.color = fourAwardColor;
                break;
            case 3:
                Result.color = threeAwardColor;
                Award.color = threeAwardColor;
                break;
            case 2:
            case 1:
            case 0:
                Result.color = twoAwardColor;
                Award.color = twoAwardColor;
                break;
        }

        newCard.Find("Number").GetComponent<Text>().text = (card.id + 1).ToString();
    }
    void FormingInstructionAndRuleCard(int count, CardStruct card, Transform newCard, Text Title, Transform BtnView)
    {
        BtnView.GetComponent<Navigation>().openWindow = parentCard.GetComponent<Navigation>().openWindow;
        BtnView.GetComponent<Navigation>().GlobalNavigation = parentCard.GetComponent<Navigation>().GlobalNavigation;
        BtnView.GetComponent<ViewTextController>().content = contentText;
        BtnView.GetComponent<ViewTextController>().DataRule = GlobalVariables.InstructionAndRuleList.list[count];
        BtnView.GetComponent<ViewTextController>().toggle = toggle;

        newCard.Find("Pass").GetComponent<Image>().enabled = card.pass;
        newCard.tag = GlobalVariables.InstructionAndRuleList.list[count].Tag;
        newCard.name = "Rule_" + GlobalVariables.InstructionAndRuleList.list[count].Id;

        Title.text = GlobalVariables.InstructionAndRuleList.list[count].Title;
    }

    void FormingTasksCard(int count, CardStruct card, Transform newCard, Text Title)
    {
        newCard.Find("Pass").GetComponent<Image>().enabled = card.pass;

        newCard.tag = GlobalVariables.TasksList.list[count].tag;
        newCard.name = "Card_" + GlobalVariables.TasksList.list[count].id;
        Title.text = GlobalVariables.TasksList.list[count].title;
    }
    public void ReadId()
    {
        string name = gameObject.transform.parent.name;
        int indexId = name.IndexOf("_");
        string id = name.Substring(indexId + 1);
        FormingBtnTextViewer(Convert.ToInt32(id));
    }

    public IEnumerator GetCardCoroutine(string otherParams)
    {
        string url = urlData + "?action=get" + "&type=" + whatDataType + "&" + otherParams;
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
        }
        else
        {
            Response response = JsonUtility.FromJson<Response>(request.downloadHandler.text);
            if (response.cards.Length != 0)
            {
                message.SetActive(false);
                FormingCardResponse(response);
            }
            else
            {
                message.SetActive(true);
                message.GetComponent<Text>().text = emptyText;
            }
        }
    }
}
