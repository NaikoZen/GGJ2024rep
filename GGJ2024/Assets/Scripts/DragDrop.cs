using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDrop : MonoBehaviour
{
    private Vector3 offset;
    private Camera mainCamera;
    private string canoTagPrefix = "Cano";
    private string dropAreaTagPrefix = "DropArea";
    private bool posicaoCorreta = false;
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
                        posicaoCorreta = true;

                        if (TodosCanosPosicionadosCorretamente())
                        {
                            AtivarMeshRendererCilindroBadalo();
                        }
                    }
                }
                else
                {
                    Debug.LogError("Erro na conversão.");
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
        DragDrop[] canos = FindObjectsOfType<DragDrop>();
        foreach (DragDrop cano in canos)
        {
            if (!cano.posicaoCorreta)
            {
                return false;
            }
        }
        return true;
    }

    private void AtivarMeshRendererCilindroBadalo()
    {
        if (cilindroBadalo != null)
        {
            cilindroBadalo.GetComponent<MeshRenderer>().enabled = true;
        }
    }
}
