using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSnapper : MonoBehaviour
{
    private Vector3 offset;
    private bool isDragging = false;

    void OnMouseDown()
    {
        // Get the offset between the object's position and mouse click point
        offset = gameObject.transform.position - GetMouseWorldPos();
        isDragging = true;
    }

    void OnMouseUp()
    {
        isDragging = false;
    }

    void Update()
    {
        if (isDragging)
        {
            // Move the object with the mouse
            transform.position = GetMouseWorldPos() + offset;
        }
    }

    // Get the mouse position in the world coordinates
    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = Camera.main.WorldToScreenPoint(transform.position).z;  // Maintain object depth
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
}
