using UnityEngine;

public class AutoPuzzlePiece : MonoBehaviour
{
    public float snapDistance = 7.0f;

    private Transform targetSpot;
    private bool isDragging;
    private bool isCorrect;
    private Vector3 offset;

    private SpriteRenderer sr;
    private string cleanName;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.sortingOrder = 5;

        cleanName = gameObject.name.Replace(" (1)", "").Trim();

        GameObject targetObj = GameObject.Find(cleanName);

        if (targetObj != null)
            targetSpot = targetObj.transform;
        else
            Debug.LogWarning("Target tidak ditemukan: " + cleanName);
    }

    void OnMouseDown()
    {
        if (isCorrect) return;

        isDragging = true;
        sr.sortingOrder = 10;

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        offset = transform.position - new Vector3(mousePos.x, mousePos.y, 0);
    }

    void OnMouseUp()
    {
        if (isCorrect || targetSpot == null) return;

        isDragging = false;

        float dist = Vector2.Distance(transform.position, targetSpot.position);

        if (dist <= snapDistance)
        {
            transform.position = targetSpot.position;
            isCorrect = true;

            sr.sortingOrder = 1;
            GetComponent<Collider2D>().enabled = false;

            GameManager.instance.AddScore(cleanName);
            ChecklistManager.instance.MarkCompleted(cleanName);
        }
        else
        {
            sr.sortingOrder = 5;
        }
    }

    void Update()
    {
        if (isDragging)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(mousePos.x, mousePos.y, 0) + offset;
        }
    }
}
