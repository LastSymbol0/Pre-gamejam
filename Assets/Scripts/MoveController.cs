using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour, IMoveController
{
    public float m_Distance = 0f;
    [SerializeField]
    private GameObject m_StartPoint;

    [SerializeField]
    float m_DistanceMouse = 0f;

    private bool IsBeingHeld = false;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(m_StartPoint.transform.position.x, m_StartPoint.transform.position.y, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (IsBeingHeld == true)
        {
            
            float koef = 1f;
            Vector2 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            m_DistanceMouse = Vector2.Distance(m_StartPoint.transform.localPosition, mousePos);
            m_Distance = Vector2.Distance(m_StartPoint.transform.localPosition, new Vector2(transform.localPosition.x, transform.localPosition.y));
            transform.position = (mousePos - new Vector2(m_StartPoint.transform.localPosition.x, m_StartPoint.transform.localPosition.y)) / (2f);
        }
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GetComponent<Renderer>().material.color = Color.red;
            IsBeingHeld = true;
        }
    }

    private void OnMouseUp()
    {
        IsBeingHeld = false;
        //transform.position = new Vector3(m_StartPoint.transform.position.x, m_StartPoint.transform.position.y, 0);
        GetComponent<Renderer>().material.color = Color.grey;
    }

    public float GetDistance()
    {
        return m_Distance;
    }
}
