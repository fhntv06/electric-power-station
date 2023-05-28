using UnityEngine;

public class BallsActionsController : MonoBehaviour
{

    public GlobalVariables GlobalVariables;
    public void PlusBall(int ball)
    {
        GlobalVariables.USER_BALLS += ball;
    }

    public void MinusBall(int ball)
    {
        if (GlobalVariables.USER_BALLS == 0) return;
        GlobalVariables.USER_BALLS -= ball;
    }

    public void CalcAward()
    {
        GlobalVariables.USER_AWARD = Mathf.RoundToInt(GlobalVariables.USER_BALLS / GlobalVariables.TASK_BALLS * GlobalVariables.USER_MAX_AWARD);
    }
}
