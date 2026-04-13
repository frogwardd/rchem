using Unity.Mathematics;
using UnityEngine;

public class card : MonoBehaviour
{
    float mouseSize = 1;
    public int number;
    [SerializeField] bool mouseOver, selected;
    [SerializeField] sys sys;
    void Update()
    {
        if (!mouseOver && transform.localScale.x > 1 && Input.GetMouseButton(0))
        {
            mouseSize = math.max(transform.localScale.x -2 * Time.deltaTime, 1f);
            transform.localScale = new Vector3(mouseSize,mouseSize,0);
        }
    }
    void OnMouseOver()
    {
        mouseOver = true;
        if(transform.localScale.x < 1.1 && Input.GetMouseButton(0))
        {
            
            mouseSize = math.min(transform.localScale.x +2 * Time.deltaTime, 1.1f);
            selected = true;
            transform.localScale = new Vector3(mouseSize, mouseSize, 0);
            sys.selected_card = this.gameObject;
        }
    }
    void OnMouseExit()
    {
        mouseOver = false;
    }
}
