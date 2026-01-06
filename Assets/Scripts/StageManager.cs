using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class StageManager : MonoBehaviour
{
    public static StageManager instance;

    private Dictionary<string, List<string>> stageMap =
        new Dictionary<string, List<string>>();

    private string currentRegion;
    private int currentIndex;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            InitStage();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void InitStage()
    {
        stageMap["Jawa"] = new List<string>()
        {
            "JawaBarat",
            "JawaTengah",
            "JawaTimur"
        };

        stageMap["Sumatra"] = new List<string>() { "Sumatra" };
        stageMap["Kalimantan"] = new List<string>() { "Kalimantan" };
        stageMap["Sulawesi"] = new List<string>() { "Sulawesi" };
        stageMap["Papua"] = new List<string>() { "Papua" };
    }

    // DIPANGGIL DARI MENU
    public void LoadRegion(string region)
    {
        currentRegion = region;
        currentIndex = Random.Range(0, stageMap[region].Count);
        SceneManager.LoadScene(stageMap[region][currentIndex]);
    }

    // DIPANGGIL SAAT NEXT
    public void NextStage()
    {
        currentIndex++;

        if (currentIndex < stageMap[currentRegion].Count)
        {
            SceneManager.LoadScene(stageMap[currentRegion][currentIndex]);
        }
        else
        {
            SceneManager.LoadScene("MenuScreen");
        }
    }
}
