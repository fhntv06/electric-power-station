using UnityEngine;
using UnityEngine.UI;

// File includes methods for global replace: variables and history navigation
public class GlobalNavigation : MonoBehaviour
{
    public GlobalVariables GlobalVariables;

    public void Back()
    {
        CloseActiveWindow();

        int index = GlobalVariables.HISTORY_WINDOW.LastIndexOf(GlobalVariables.PREV_WINDOW);

        GlobalVariables.HISTORY_WINDOW.RemoveAt(index + 1);
        GlobalVariables.PREV_WINDOW.SetActive(true);
        GlobalVariables.ACTIVE_WINDOW = GlobalVariables.PREV_WINDOW;
        GlobalVariables.PREV_WINDOW = GlobalVariables.HISTORY_WINDOW[index != 0 ? index - 1 : index];

    }

    public void AddWindowInHistory(GameObject activeWindow)
    {
        GlobalVariables.HISTORY_WINDOW.Add(activeWindow);
        GlobalVariables.PREV_WINDOW = GlobalVariables.ACTIVE_WINDOW;
        GlobalVariables.ACTIVE_WINDOW = activeWindow;
    }

    public void ReplaceGlobalVariablesTaskMode(string mode)
    {
        GlobalVariables.TASK_MODE = mode;
    }

    public void CloseActiveWindow()
    {
        GlobalVariables.ACTIVE_WINDOW.SetActive(false);
    }

    public void OpenNextWindow(GameObject window)
    {
        window.SetActive(true);
    }

    public void OpenPauseWindow(bool state)
    {
        GlobalVariables.PAUSE_WINDOW.SetActive(state);
        GlobalVariables.USER_FREEZE = state;
    }
    public void SwitcherContentPauseWindow(string targetName)
    {
        OpenPauseWindow(true);

        Transform parent = GlobalVariables.PAUSE_WINDOW_CONTENT.parent;
        foreach (Transform child in parent)
        {
            foreach (Transform inner in child)
            {
                if (child.name == "Menu") inner.GetComponent<Button>().interactable = (inner.name != targetName);
                if (child.name == "Content") inner.gameObject.SetActive(inner.name == targetName);
            }
        }
    }
    public void Quit()
    {
        Application.Quit();
    }
}
