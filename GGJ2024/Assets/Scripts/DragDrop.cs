using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDrop : MonoBehaviour
{
    private Vector3 offset;
    private Camera mainCamera;
    public string destinationTag = "DropArea";

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void OnMouseDown()
    {
        offset = transform.position - MouseWorldPosition();
        transform.GetComponent<Collider>().enabled = false;
    }

    private void OnMouseDrag()
    {
        Vector3 targetPosition = MouseWorldPosition() + offset;
        transform.position = targetPosition;
    }

    private void OnMouseUp()
    {
        var rayOrigin = Camera.main.transform.position;
        var rayDirection = MouseWorldPosition() - Camera.main.transform.position;
        RaycastHit hitInfo;
        if(Physics.Raycast(rayOrigin, rayDirection, out hitInfo))
        {
            if(hitInfo.transform.tag == destinationTag)
            {
                transform.position = hitInfo.transform.position;
            }
        }
        transform.GetComponent<Collider>().enabled = true;
    }

    private Vector3 MouseWorldPosition()
    {
        Vector3 mouseScreenPos = Input.mousePosition;
        mouseScreenPos.z = -mainCamera.transform.position.z;
        return mainCamera.ScreenToWorldPoint(mouseScreenPos);
    }
}
