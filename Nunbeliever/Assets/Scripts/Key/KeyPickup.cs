using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    private bool m_isHovering;
    private GameObject m_lastHover;
    private bool m_hasKey;

    internal bool HasKey { get { return m_hasKey; } }

    private void FixedUpdate()
    {
        if (Physics.Raycast(transform.position, transform.forward, out var hitInfo, 2))
        {
            if (hitInfo.collider.CompareTag("Key"))
            {
                Debug.Log(hitInfo.distance);
                if (!m_isHovering)
                {
                    m_lastHover = hitInfo.collider.gameObject;
                    m_isHovering = true;
                    m_lastHover.SendMessage("OnHoverChanged", m_isHovering);
                }

                if (Input.GetKeyDown(KeyCode.E))
                {
                    m_hasKey = true;
                    Destroy(hitInfo.collider.gameObject);
                }
                return;
            }
        }
        if (m_lastHover != null)
        {
            if (m_isHovering)
            {
                m_isHovering = false;
                m_lastHover.SendMessage("OnHoverChanged", m_isHovering);
            }
        }

    }
}
