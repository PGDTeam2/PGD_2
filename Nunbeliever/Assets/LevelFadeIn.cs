using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelFadeIn : MonoBehaviour
{
    private GameObject m_whiteOutPanel;
    private float t;
    // Start is called before the first frame update
    void Start()
    {
        m_whiteOutPanel = GameObject.FindWithTag("WhiteOutPanel");
        t = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (t > 0) StartCoroutine(FadeOut());
    }
    IEnumerator FadeOut()
    {
        var image = m_whiteOutPanel.GetComponent<Image>();
        
        // Fade out white screen
        while (t > 0f)
        {
            t -= 0.05f;
            image.color = new Color(0f, 0f, 0f, t);
            yield return new WaitForSeconds(0.02f / Time.deltaTime);
        }
    }
}
