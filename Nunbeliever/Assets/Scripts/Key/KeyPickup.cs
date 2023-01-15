using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    private bool m_isHovering;
    private GameObject m_lastHover;
    private List<int> m_ownedKeys = new();
    private bool pressed;

    internal List<int> OwnedKeys { get { return m_ownedKeys; } }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
            pressed = true;
    }

    private void FixedUpdate()
    {
        if (Physics.Raycast(transform.position, transform.forward, out var hitInfo, 2))
        {
            if (hitInfo.collider.CompareTag("Key"))
            {
                // Send OnHoverChanged only when changed :)
                if (!m_isHovering)
                {
                    m_lastHover = hitInfo.collider.gameObject;
                    m_isHovering = true;
                    m_lastHover.SendMessage("OnHoverChanged", m_isHovering);
                }

                // Pickup key when pressing E
                if (pressed)
                {
                    if (hitInfo.collider.TryGetComponent<NightStandPickup>(out var nightstand))
                    {
                        if (nightstand.IsOpen)
                        {
                            m_ownedKeys.Add(hitInfo.collider.GetComponent<Key>().ID);
                            Destroy(nightstand.Key);
                        }
                    }
                    else
                    {
                        Destroy(hitInfo.collider.gameObject);
                        m_ownedKeys.Add(hitInfo.collider.GetComponent<Key>().ID);
                    }
                }
                return;
            }
        }

        // Make sure we have hovered over the key before
        if (m_lastHover != null)
        {
            // Send OnHoverChanged only when changed :)
            if (m_isHovering)
            {
                m_isHovering = false;
                m_lastHover.SendMessage("OnHoverChanged", m_isHovering);
            }
        }

        pressed = false;
    }
}
