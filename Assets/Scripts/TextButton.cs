using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextButton : ScriptedButton
{
    [SerializeField] TextMeshProUGUI text;

    protected override void Awake()
    {
        base.Awake();
        text.enabled = false;
        text.text = "";
    }

    protected override void OnClick()
    {
        base.OnClick();
        ShowText();
    }

    private void ShowText()
    {
        StartCoroutine(ShowTextCoroutine());
    }

    private IEnumerator ShowTextCoroutine()
    {
        text.enabled = true;
        text.text = "Sample text";

        yield return new WaitForSeconds(3f);

        text.enabled = false;
        text.text = "";
    }
}
