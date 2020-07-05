using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseButton : ScriptedButton
{
    [SerializeField] GameObject objectToClose;

    protected override void OnClick()
    {
        base.OnClick();
        Close(objectToClose);
    }

    private void Close(GameObject toClose)
    {
        toClose.SetActive(false);
    }
}
