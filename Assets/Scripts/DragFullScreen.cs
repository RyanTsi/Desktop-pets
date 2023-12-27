using UnityEngine;

public class DragFullScreen : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 offset;
    public GameObject gameObject;
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // 当鼠标左键按下时
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject == gameObject)
                {
                    isDragging = true;
                    offset = gameObject.transform.position - GetMouseWorldPosition();
                }
            }
        }

        if (Input.GetMouseButtonUp(0)) // 当鼠标左键释放时
        {
            isDragging = false;
        }

        if (isDragging)
        {
            Vector3 newPosition = GetMouseWorldPosition() + offset;
            transform.position = newPosition;
        }
    }

    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = -Camera.main.transform.position.z;
        return Camera.main.ScreenToWorldPoint(mousePosition);
    }
}