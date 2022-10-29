using System;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.InputSystem;

public class Flashlight : MonoBehaviour
{
    [SerializeField] private new Light light;
    private bool _flashlightIsOn;

    private void Update()
    {
        if (!Keyboard.current.fKey.wasPressedThisFrame) return;
        _flashlightIsOn = !_flashlightIsOn;
        light.enabled = _flashlightIsOn;
    }
}