using System;
using System.Runtime.InteropServices;
using UnityEngine;

public class PlatformChecker : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void GetPlatform();

    [SerializeField] private Platform _editorPlatform;
    public static Action<Platform> OnPlatformChecked;

    private void Start()
    {
        if (Application.isEditor)
        {
            SetPlatform();
        }
        else
        {
            GetPlatform();
        }
    }

    public void SetPlatform(string deviceType)
    {
        if (deviceType == "desktop")
        {
            OnPlatformChecked?.Invoke(Platform.PC);
        }
        else
        {
            OnPlatformChecked?.Invoke(Platform.Mobile);
        }
    }

    private void SetPlatform()
    {
        OnPlatformChecked?.Invoke(_editorPlatform);
    }
}