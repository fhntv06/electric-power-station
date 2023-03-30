using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.Requests;
using UnityEngine;
using UnityEngine.Networking;

public class MethodsResponse : MonoBehaviour
{
    public GlobalVariables GlobalVariables;

    public string whatDataType;
    string urlData = "http://substation/data.php";

    UnityWebRequest request;
    public IEnumerator PostCommon(string urlData, string whatDataType, string otherParams)
    {
        string url = urlData + "?action=post&type=" + whatDataType + "&" + otherParams;
        UnityWebRequest request = UnityWebRequest.Get(url);
        yield return request.SendWebRequest();
    }

    public UnityWebRequest GetCommon(string urlData, string whatDataType)
    {
        string url = urlData + "?action=get" + "&type=" + whatDataType;
        request = UnityWebRequest.Get(url);
        request.SetRequestHeader("Content-Type", "application/json");

        StartCoroutine(Get(request));

        return request;
    }

    public IEnumerator Get(UnityWebRequest request)
    {
        yield return request.SendWebRequest();
        yield return new WaitForSeconds(.1f);
    }

    public void PostPassTask()
    {
        string otherParams = "type=tasks&field=task&value=" + GlobalVariables.TASKID + "&id=" + GlobalVariables.USER_ID + "&balls=" + GlobalVariables.USER_BALLS;
        print(otherParams);
        StartCoroutine(PostCommon(urlData, whatDataType, otherParams));
    }
}
