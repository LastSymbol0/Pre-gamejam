using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class ChangeColorScript : MonoBehaviour
{
    public MoveController MoveController;

    public float TransparencyChanger = 0.0005f;

    public float StartTransparency = 0f;

    public float MaxTransparency = 0.5f;

    private SpriteRenderer spriteRenderer;

    private float m_CurrentTransparency = 0f;

    private float m_PrevDistance = 0f;

    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = MoveController.GetDistance();
        UnityEngine.Debug.Log(moveHorizontal);
        float currentDistance = moveHorizontal + m_PrevDistance;
        if (currentDistance <= m_PrevDistance)
        {
            if (m_CurrentTransparency > StartTransparency)
            {
                m_CurrentTransparency -= TransparencyChanger;
            }
            spriteRenderer.color = new Color(1f, 1f, 1f, m_CurrentTransparency);
        }
        else
        {
            if (m_CurrentTransparency < MaxTransparency)
            {
                m_CurrentTransparency += TransparencyChanger;
            }
            spriteRenderer.color = new Color(1f, 1f, 1f, m_CurrentTransparency);
        }
        m_PrevDistance = currentDistance;
    }
}
