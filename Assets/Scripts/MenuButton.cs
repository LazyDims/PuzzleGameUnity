using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
    [Header("Nama Region")]
    public string regionName; // contoh: "Jawa"

    public void OnClick()
    {
        // pastikan StageManager ada
        if (StageManager.instance == null)
        {
            Debug.LogError("StageManager belum ada di scene!");
            return;
        }

        StageManager.instance.LoadRegion(regionName);
    }
}
