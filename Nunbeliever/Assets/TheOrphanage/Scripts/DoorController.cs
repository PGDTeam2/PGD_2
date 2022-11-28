using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField] private float autoCloseTime;
    [SerializeField] internal bool IsLocked;

    private bool m_isOpen;
    private bool m_openedByNun;

    private Animator m_animator;

    private void Awake()
    {
        m_animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Nun"))
        {
            if (!m_isOpen)
            {
                SetOpen(true);
                m_openedByNun = true;
                StartCoroutine(AutoCloseDoor());
            }
        }
    }

    IEnumerator AutoCloseDoor()
    {
        yield return new WaitForSeconds(autoCloseTime);
        if (m_openedByNun)
            SetOpen(false);
    }

    public void SetOpen(bool open)
    {
        m_openedByNun = false;
        m_isOpen = open;
        m_animator.SetBool("is_open", open);
    }

    public void ToggleDoor()
    {
        if (m_isOpen)
            SetOpen(false);
        else
            SetOpen(true);
    }

    public void OnInteract(bool hasKey)
    {
        if (hasKey || !IsLocked)
            ToggleDoor();
    }
}
