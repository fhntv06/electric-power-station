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
        print(url);

        yield return request.SendWebRequest();
    }

    public UnityWebRequest GetCommon(string urlData, string whatDataType)
    {
        string url = urlData + "?action=get" + "&type=" + whatDataType;
        request = UnityWebRequest.Get(url);
        request.SetRequestHeader("Content-Type", "application/json");

        StartCoroutine(Get(request));

        print(request.result);

        return request;
    }

    public IEnumerator Get(UnityWebRequest request)
    {
        yield return request.SendWebRequest();
        yield return new WaitForSeconds(.1f);
    }

    public void PostPassTask()
    {
        int awards = Mathf.RoundToInt(GlobalVariables.USER_BALLS / GlobalVariables.TASK_BALLS * GlobalVariables.USER_MAX_AWARD);

        print(awards);
        string otherParams = 
            "field=task&value=" + GlobalVariables.TASKID + 
            "&id=" + GlobalVariables.USER_ID + 
            "&balls=" + GlobalVariables.USER_BALLS + 
            "&award=" + awards;
        StartCoroutine(PostCommon(urlData, "tasks", otherParams));
    }
}
