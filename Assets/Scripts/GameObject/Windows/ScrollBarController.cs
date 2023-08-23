using UnityEngine;
using UnityEngine.UI;

public class ScrollBarController : MonoBehaviour
{
    // script set on scrollbar

    // added interactive in elements
    float borderScroll = 0.3f;

    public GameObject toggle;

    private void Update()
    {
        if (!gameObject.activeSelf)
            toggle.GetComponent<Toggle>().interactable = true;

    }
    float GetValueScrollBarComponent()
    {
        return gameObject.GetComponent<Scrollbar>().value;
    }
    public void GetPosition()
    {
        float value = GetValueScrollBarComponent();
        toggle.GetComponent<Toggle>().interactable = value < borderScroll || !gameObject.activeSelf;
    }
}
