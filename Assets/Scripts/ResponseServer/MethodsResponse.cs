using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.Requests;
using UnityEngine;
using UnityEngine.Networking;

public class MethodsResponse : MonoBehaviour
{
    public GlobalVariables GlobalVariables;

    string urlData = "http://substation/data.php";

    UnityWebRequest request;
    public IEnumerator PostCommon(string urlData, string whatDataType, string otherParams)
    {
        string url = urlData + "?action=post&type=" + whatDataType + "&" + otherParams;
        UnityWebRequest request = UnityWebRequest.Get(url);

        yield return request.SendWebRequest();
    }

    public IEnumerator GetCommon(string urlData, string whatDataType)
    {
        string url = urlData + "?action=get" + "&type=" + whatDataType;
        request = UnityWebRequest.Get(url);
        request.SetRequestHeader("Content-Type", "application/json");

        yield return request.SendWebRequest();
        yield return new WaitForSeconds(.1f);
    }
    public void PostPassTask()
    {
        if (GlobalVariables.TASK_MODE == GlobalVariables.EXAM_MODE)
        {
            string otherParams = 
                "field=task&value=" + GlobalVariables.TASK_ID + 
                "&id=" + GlobalVariables.USER_ID + 
                "&balls=" + GlobalVariables.USER_BALLS + 
                "&award=" + GlobalVariables.USER_AWARD;
            StartCoroutine(PostCommon(urlData, "tasks", otherParams));
        }
    }
}
