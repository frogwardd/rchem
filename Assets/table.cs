using UnityEngine;

public class table : MonoBehaviour
{
    [SerializeField] sys sys;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnMouseOver()
    {
        if (Input.GetMouseButton(0))
        {
            sys.selected_card.transform.position = transform.position;
        }
    }
}
