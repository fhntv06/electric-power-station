using UnityEngine;

public class SwitcherElectricController : MonoBehaviour
{
    public Material materialOnOn;
    public Material materialOnOff;
    public Material materialOffOn;
    public Material materialOffOff;

    public Renderer lampOn;
    public Renderer lampOff;

    public string TypeElectricObject = "razedinitel";

    public GameObject[] animatedElements;

    public void ChangeStateSwitch(bool state)
    {
        gameObject.name = gameObject.name.Replace(state ? "off" : "on", state ? "on" : "off");

        if (lampOn != null)
            lampOn.material = state ? materialOnOn : materialOnOff;

        if (lampOff != null)
            lampOff.material = state ? materialOffOff : materialOffOn;

        transform.localRotation = Quaternion.Euler(state ? -45f : 45f, 0, 0);
        if (TypeElectricObject == "razedinitel") AnimationRazedinitel(state);
    }
    void AnimationRazedinitel(bool state)
    {
        foreach(GameObject element in animatedElements)
            element.GetComponent<Animator>().SetBool("rotate", state);
    }
}
