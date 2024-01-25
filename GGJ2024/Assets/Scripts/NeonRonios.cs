using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class NeonRonios : MonoBehaviour, IPointerDownHandler
{
    public int idNeonronios;
    public Vector3 positionObj;
    public void OnPointerDown(PointerEventData eventData)
    {
        GameManager.instance.TryDick(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        positionObj = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
