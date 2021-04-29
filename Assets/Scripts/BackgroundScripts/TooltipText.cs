using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TooltipText : MonoBehaviour
{
    public static TooltipText instance;
    [Header("Objects")]
    [SerializeField]
    TMP_Text tooltipText;

    private void Awake()
    {
        instance = this;
    }

    public void SetText(string text)
    {
        tooltipText.SetText(text);
    }
}
