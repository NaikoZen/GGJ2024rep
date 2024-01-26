using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class DragDrop : MonoBehaviour
{
    Vector3 offset;
    public string destinationTag = "DropArea";

    private void OnMouseDown()
    {
        offset = transform.position - MouseWorldPosition();
        transform.GetComponent<Collider>().enabled = false;
    }

    void OnMouseDrag()
    {
        transform.position = MouseWorldPosition() + offset;
    }

    void OnMouseUp()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo))
        {
            if (hitInfo.transform.CompareTag(destinationTag))
            {
                transform.position = hitInfo.point;
            }
        }
        transform.GetComponent<Collider>().enabled = true;
    }

    Vector3 MouseWorldPosition()
    {
        Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(mouseRay, out hit))
        {
            return hit.point;
        }

        return Vector3.zero; // Pode ser necessário ajustar esse valor de retorno, dependendo do contexto.
    }
}
