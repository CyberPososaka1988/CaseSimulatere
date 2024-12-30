using System;
using System.Runtime.InteropServices;
using UnityEngine;

public class LanguageChecker : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern bool GetLang();

    public static Action<Language> OnLanguageChecked;

    [SerializeField] private Language _editorLanguage;
    private static Language _language;

    private void Awake()
    {
        if (!Application.isEditor)
        {
            if (GetLang())
            {
                _language = Language.En;
            }
            else
            {
                _language = Language.Ru;
            }
        }
        else
        {
            _language = _editorLanguage;
        }

        OnLanguageChecked?.Invoke(_language);
    }

    public static Language GetLanguage()
    {
        return _language;
    }
}