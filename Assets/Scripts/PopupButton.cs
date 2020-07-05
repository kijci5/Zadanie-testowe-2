using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupButton : ScriptedButton
{
    [SerializeField] GameObject popup;

    protected override void Awake()
    {
        base.Awake();
        HidePopup();
    }
    protected override void OnClick()
    {
        base.OnClick();
        ShowPopup();
    }

    private void ShowPopup()
    {
        popup.SetActive(true);
    }

    private void HidePopup()
    {
        popup.SetActive(false);
    }
}
