using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDrop : MonoBehaviour
{
    private Vector3 offset;
    private Camera mainCamera;
    private string canoTagPrefix = "Cano";
    private string dropAreaTagPrefix = "DropArea";
    private int correctDroped = 0;

    public GameObject cilindroBadalo;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            offset = transform.position - MouseWorldPosition();
            GetComponent<Collider>().enabled = false;
        }
    }

    private void OnMouseDrag()
    {
        Vector3 targetPosition = MouseWorldPosition() + offset;
        transform.position = targetPosition;
    }

    private void OnMouseUp()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo))
        {
            string dropAreaTag = hitInfo.transform.gameObject.tag;
            string canoTag = gameObject.tag;

            if (dropAreaTag.StartsWith(dropAreaTagPrefix) && canoTag.StartsWith(canoTagPrefix))
            {
                if (int.TryParse(dropAreaTag.Substring(dropAreaTagPrefix.Length), out int dropAreaNumber) &&
                    int.TryParse(canoTag.Substring(canoTagPrefix.Length), out int canoNumber))
                {
                    if (dropAreaNumber == canoNumber)
                    {
                        transform.position = hitInfo.transform.position;
                        correctDroped++;

                        if (TodosCanosPosicionadosCorretamente())
                        {
                            if (cilindroBadalo != null)
                            {
                                cilindroBadalo.GetComponent<MeshRenderer>().enabled = true;
                            }
                        }
                    }
                }
                else
                {
                    Debug.LogError("erro");
                }
            }
        }

        GetComponent<Collider>().enabled = true;
    }

    private Vector3 MouseWorldPosition()
    {
        Vector3 mouseScreenPos = Input.mousePosition;
        mouseScreenPos.z = -mainCamera.transform.position.z;
        return mainCamera.ScreenToWorldPoint(mouseScreenPos);
    }

    private bool TodosCanosPosicionadosCorretamente()
    {
        return correctDroped == GameObject.FindGameObjectsWithTag(canoTagPrefix).Length;
    }
}
