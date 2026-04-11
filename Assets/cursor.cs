using UnityEngine.UI;
using UnityEngine;

public class cursor : MonoBehaviour
{
    [SerializeField] RectTransform rect;
    Image image;
    [SerializeField] Sprite cursorClick, cursorUnclick;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        image = GetComponent<Image>();
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        rect.position = Input.mousePosition;
        if (Input.GetMouseButton(0))
        {
            image.sprite = cursorClick;
        }
        else
        {
            image.sprite = cursorUnclick;
        }
    }
}
