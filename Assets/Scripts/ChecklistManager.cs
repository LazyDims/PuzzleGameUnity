using System.Collections.Generic;
using UnityEngine;

public class ChecklistManager : MonoBehaviour
{
    public static ChecklistManager instance;

    public ChecklistItemUI checklistPrefab;
    public Transform contentParent;

    private Dictionary<string, ChecklistItemUI> checklistDict = new();
    private int totalPiece;
    private int placedPiece;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        GenerateChecklist();
    }

    void GenerateChecklist()
    {
        GameObject[] pieces = GameObject.FindGameObjectsWithTag("PuzzlePiece");
        totalPiece = pieces.Length;

        foreach (GameObject piece in pieces)
        {
            string cleanName = piece.name.Replace(" (1)", "").Trim();

            if (!checklistDict.ContainsKey(cleanName))
            {
                ChecklistItemUI item =
                    Instantiate(checklistPrefab, contentParent);

                item.Setup(cleanName);
                checklistDict.Add(cleanName, item);
            }
        }

        UpdateCounter();
    }



    public void MarkCompleted(string cityName)
    {
        if (checklistDict.TryGetValue(cityName, out ChecklistItemUI item))
        {
            item.SetChecked();
            placedPiece++;
            UpdateCounter();
        }
    }

    void UpdateCounter()
    {
        GameManager.instance.UpdatePieceCounter(placedPiece, totalPiece);
    }
}
