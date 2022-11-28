using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Key : MonoBehaviour
{
    private Animator m_animator;

    private void Awake()
    {
        m_animator = GetComponent<Animator>();
    }

    public void OnHoverChanged(bool isHovering)
    {
        m_animator.SetBool("is_visible", isHovering);
    }
}
