using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowTextOnHover : MonoBehaviour
{
    private Animator m_animator;

    private void Awake()
    {
        // this gameobject > Canvas > TextMeshPro text
        m_animator = GetComponent<Animator>();
    }

    public void OnHoverChanged(bool isHovering)
    {
        // Set the animator to change the text
        m_animator.SetBool("is_visible", isHovering);
    }
}
