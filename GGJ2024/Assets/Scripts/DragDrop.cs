using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDrop : MonoBehaviour
{
    Vector3 offset;
    public string dropAreaTag; // Tag da DropArea associada a este objeto
    private MeshRenderer meshRenderer;

    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void OnMouseDown()
    {
        offset = transform.position - MouseWorldPosition();
        GetComponent<Collider>().enabled = false;
    }

    private void OnMouseDrag()
    {
        transform.position = MouseWorldPosition() + offset;
    }

    private void OnMouseUp()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo))
        {
            if (hitInfo.transform.CompareTag(dropAreaTag))
            {
                // Desativa o MeshRenderer do "Cano"
                meshRenderer.enabled = false;

                // Ativa o MeshRenderer da DropArea
                MeshRenderer dropAreaRenderer = hitInfo.transform.GetComponent<MeshRenderer>();
                if (dropAreaRenderer != null)
                {
                    dropAreaRenderer.enabled = true;
                }

                transform.position = hitInfo.point;
            }
        }

        GetComponent<Collider>().enabled = true;
    }

    private Vector3 MouseWorldPosition()
    {
        Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(mouseRay, out hit))
        {
            return hit.point;
        }

        return Vector3.zero;
    }
}
