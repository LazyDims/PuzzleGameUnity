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

        stageMap["Sumatra"] = new List<string>() { 
            "Aceh",
            "Bengkulu",
            "Lampung",
            "Riau",
            "Jambi",
            "Sumatera Utara",
            "Sumatera Barat",
            "Sumatera Selatan",
            };
        stageMap["Kalimantan"] = new List<string>() { "Kalimantan" };
        stageMap["Sulawesi"] = new List<string>() { "Sulawesi" };
        stageMap["Papua"] = new List<string>()
        {
            "Papua",
            "PapuaBarat",
            "PapuaBaratDaya",
            "PapuaPegunungan",
            "PapuaTengah",
            "PapuaSelatan"
        };
    }
    public void LoadRegion(string region)
    {
        if (!stageMap.ContainsKey(region))
        {
            Debug.LogError("Region tidak ditemukan: " + region);
            return;
        }

        currentRegion = region;
        currentIndex = Random.Range(0, stageMap[region].Count);

        // 🎵 pastikan BGM nyala
        AudioManager.instance.PlayBGM(
            AudioManager.instance.idleBGM
        );

        SceneManager.LoadScene(stageMap[region][currentIndex]);
    }
    public void NextStage()
    {
        currentIndex++;
        AudioManager.instance.PlayBGM(
            AudioManager.instance.idleBGM
        );

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
