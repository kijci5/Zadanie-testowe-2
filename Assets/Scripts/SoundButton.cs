using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundButton : ScriptedButton
{
    protected override void OnClick()
    {
        base.OnClick();
        PlaySound();
    }

    private void PlaySound()
    {
        PoolManager.instance.SpawnFromPool(PoolManager.PoolName.ButtonClickSound, transform.position, Quaternion.identity);
    }
}
