using UnityEngine;

public class AutoPuzzlePiece : MonoBehaviour
{
    public float snapDistance = 0.7f;

    private Transform targetSpot;
    private bool isDragging = false;
    private bool isCorrect = false;
    private Vector3 offset;

    void Start()
    {
        // Ambil nama object & bersihkan "(1)"
        string rawName = gameObject.name;
        string cleanName = rawName.Replace(" (1)", "").Trim();

        // Cari object target di PetaBlank
        GameObject targetObj = GameObject.Find(cleanName);

        if (targetObj != null)
        {
            targetSpot = targetObj.transform;
        }
        else
        {
            Debug.LogWarning("Target tidak ditemukan untuk: " + cleanName);
        }
    }

    void OnMouseDown()
    {
        if (isCorrect) return;
        isDragging = true;

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

            GameManager.instance.AddScore(gameObject.name);
            GetComponent<Collider2D>().enabled = false;
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
