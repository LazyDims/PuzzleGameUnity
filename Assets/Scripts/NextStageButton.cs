using UnityEngine;

public class NextStageButton : MonoBehaviour
{
    public void OnClick()
    {
        if (StageManager.instance == null)
        {
            Debug.LogError("StageManager belum ada!");
            return;
        }

        StageManager.instance.NextStage();
    }
}
