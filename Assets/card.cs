using Unity.Mathematics;
using UnityEngine;

public class card : MonoBehaviour
{
    float mouseSize = 1;
    bool mouseOver;
    void Update()
    {
        if (!mouseOver && transform.localScale.x > 1)
        {
            mouseSize = math.max(transform.localScale.x -2 * Time.deltaTime, 1f);
            transform.localScale = new Vector3(mouseSize,mouseSize,0);
        }
    }
    void OnMouseOver()
    {
        mouseOver = true;
        if(transform.localScale.x < 1.1)
        {
            mouseSize = math.min(transform.localScale.x +2 * Time.deltaTime, 1.1f);
            transform.localScale = new Vector3(mouseSize, mouseSize, 0);
        }
    }
    void OnMouseExit()
    {
        mouseOver = false;
    }
    void OnMouseDrag()
    {
        float x = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
        float y = Camera.main.ScreenToWorldPoint(Input.mousePosition).y;
        transform.position = new Vector3(x,y,0);
    }
}
