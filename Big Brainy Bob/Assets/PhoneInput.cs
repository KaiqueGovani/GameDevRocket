using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneInput : MonoBehaviour
{
    public GameObject Panel;

    public void OpenKeyboard()
    {
        TouchScreenKeyboard.Open("", TouchScreenKeyboardType.NamePhonePad, false, false, false, false, "Enter your username");
        Panel.SetActive(false);
    }
}
