using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class qsettings : MonoBehaviour
{
    Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        Application.targetFrameRate = 144;
    }

    // Update is called once per frame
    public void setQuality()
    {
        QualitySettings.SetQualityLevel((int)slider.value);
    }
    private void Update()
    {
        Debug.Log(slider.value);
    }
}
