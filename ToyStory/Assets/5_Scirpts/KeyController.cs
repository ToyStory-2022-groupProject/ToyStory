using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum KeyAction{Left, Right, Walk, Jump, KeyCount}
public static class KeySetting {public static Dictionary<KeyAction, KeyCode> keys = new Dictionary<KeyAction, KeyCode>();}

public class KeyController : MonoBehaviour
{
   KeyCode[] defaultKeys = new KeyCode[] {KeyCode.LeftArrow, KeyCode.RightArrow, KeyCode.RightControl, KeyCode.Space};
    private void Awake()
    {
        for (int i=0; i < (int)KeyAction.KeyCount; i++)
            KeySetting.keys.Add((KeyAction) i, defaultKeys[i]);
    }
}
