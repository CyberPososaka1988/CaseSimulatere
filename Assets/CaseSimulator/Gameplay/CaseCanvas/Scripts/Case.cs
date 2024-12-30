using System;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

namespace CaseSimulator.Gameplay.CaseSystem
{
    public class Case : MonoBehaviour
    {
        [DllImport("__Internal")]
        private static extern void AdCase();

        public static Action OnAdOpened;
        public static Action OnAdClosed;
        public static Action<CaseInfo> OnCaseSelected;

        [SerializeField] private CaseInfo _caseInfo;
        [SerializeField] private Text _nameText;
        [SerializeField] private Text _costText;

        private bool _rewardValid;

        private void OnEnable()
        {
            LanguageChecker.OnLanguageChecked += ChangeLang;

            if (LanguageChecker.GetLanguage() == Language.Ru)
            {
                _nameText.text = _caseInfo.RuName;
            }
            else
            {
                _nameText.text = _caseInfo.EnName;
            }

            _costText.text = $"{_caseInfo.Cost}";
        }

        private void OnDisable()
        {
            LanguageChecker.OnLanguageChecked -= ChangeLang;
        }

        private void ChangeLang(Language language)
        {
            if (language == Language.Ru)
            {
                _nameText.text = _caseInfo.RuName;
            }
            else
            {
                _nameText.text = _caseInfo.EnName;
            }
        }

        public void OpenCase()
        {
            if (_caseInfo.IsAdCase)
            {
                if (Application.isEditor)
                {
                    OnAdOpened?.Invoke();
                    Time.timeScale = 0;
                    OnRewarded();
                    GetReward();
                }
                else
                {
                    AdCase();
                    OnAdOpened?.Invoke();
                    Time.timeScale = 0;
                }
            }
            else
            {
                OnCaseSelected?.Invoke(_caseInfo);
            }
        }

        public void OnRewarded()
        {
            _rewardValid = true;
        }

        public void GetReward()
        {
            Time.timeScale = 1;
            OnAdClosed?.Invoke();

            if (_rewardValid)
            {
                OnCaseSelected?.Invoke(_caseInfo);
                _rewardValid = false;
            }
        }
    }
}