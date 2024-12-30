using System;
using System.Runtime.InteropServices;
using UnityEngine;

public class Adv : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void ShowAdv();

    public static Action OnAdShowed;
    public static Action OnAdFinished;

    private void Awake()
    {
        if (!Application.isEditor)
        {
            ShowAd();
        }
    }

    public void ShowAd()
    {
        ShowAdv();
        OnAdShowed?.Invoke();
        Time.timeScale = 0f;
    }

    public void StopAd()
    {
        OnAdFinished?.Invoke();
        Time.timeScale = 1;
    }
}