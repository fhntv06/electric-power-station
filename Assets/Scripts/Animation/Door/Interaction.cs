using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Door
}
public class Interaction : MonoBehaviour
{
    public ItemType type;
    public bool flag = false;
    public void ChangeStateAnimateOpenClose()
    {
        if (type == ItemType.Door)
        {
            flag = !flag;
            GetComponent<Animator>().SetBool("Open", flag);
            GetComponent<Animator>().SetBool("Close", !flag);
        }
    }
}
