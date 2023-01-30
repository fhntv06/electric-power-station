using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Authentification : MonoBehaviour
{
    public GlobalVariables GlobalVariables;
    public GlobalNavigation GlobalNavigation;

    public List<InputField> inputFieldsAuth;
    public List<InputField> inputFieldsAuthRequest;
    public GameObject RequestTextErrorAuth;

    public List<InputField> inputFieldsReg;
    public List<InputField> inputFieldsRegRequest;
    public GameObject RequestTextErrorReg;

    string type;

    bool emptyRequestField;
    public void Auth()
    {
        emptyRequestField = RequestField(inputFieldsAuthRequest);
        if (emptyRequestField)
        {
            type = "auth";
            StartCoroutine(SendCoroutine());
        }
    }

    public void Reg()
    {
        emptyRequestField = RequestField(inputFieldsRegRequest);

        if (emptyRequestField)
        {
            type = "reg";
            StartCoroutine(SendCoroutine());
        }
    }

    bool RequestField(List<InputField> inputFields)
    {
        bool notError = true;
        foreach (InputField field in inputFields)
        {
            if (field.text == "")
            {
                notError = false;
                field.transform.Find("error").gameObject.SetActive(true);
                // выводить текст "ѕоле не заполнено"
            } else
            {
                // не работает ValidField
                // notError = ValidField(field.text, field.name);
                field.transform.Find("error").gameObject.SetActive(false);

                if (!notError)
                {
                    // выводить текст "введите ..."
                    field.transform.Find("valid").gameObject.SetActive(true);
                } else
                {
                    field.transform.Find("valid").gameObject.SetActive(false);
                }
            }
        }
        
        return notError;
    }

    bool ValidField(string textField, string type)
    {
        string pattern;
        switch (type) {
            case "login":
            case "password":
                pattern = @"[^0-9a-zA-Z]+";
                return Regex.Match(textField, pattern).Success;
            case "name":
            case "fullname":
                pattern = @"[^a-zA-Z]+";
                return Regex.IsMatch(textField, pattern, RegexOptions.IgnoreCase);
            case "phone":
                pattern = "[0-9]{3}-[0-9]{3}-[0-9]{4}";
                return  Regex.IsMatch(textField, pattern, RegexOptions.IgnoreCase);
            case "email":
                pattern = @"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" + @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$";
                return  Regex.IsMatch(textField, pattern, RegexOptions.IgnoreCase);
        }

        return false;
    }
    private IEnumerator SendCoroutine()
    {
        List<InputField> inputField;

        WWWForm form = new WWWForm();


        inputField = type == "auth" ? inputFieldsAuth : inputFieldsReg;


        foreach (InputField field in inputField)
        {
            form.AddField(field.name, field.text);
        }

        form.AddField("type", type);

        WWW www = new WWW("http://substation/auth.php", form);
        yield return www;

        if (www.error != null)
        {
            Debug.Log("Error: " + www.error);
            yield break;
        }

        Debug.Log("Server response: " + www.text);

        if (www.text == "1")
        {
            GlobalVariables.AUTH_USER = true;
            GlobalNavigation.CloseActiveWindow();
            GlobalNavigation.OpenNextWindow(GlobalVariables.LC_WINDOW);
            GlobalNavigation.ReplaceGlobalVariablesWindow(GlobalVariables.LC_WINDOW);


        } else
        {
            GameObject RequestText = type == "auth" ? RequestTextErrorAuth : RequestTextErrorReg;
            RequestText.SetActive(true);
            RequestText.GetComponent<Text>().text = www.text;
        }
    }
}