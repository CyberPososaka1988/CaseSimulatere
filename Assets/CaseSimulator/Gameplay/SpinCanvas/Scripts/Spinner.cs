using CaseSimulator.Gameplay.MoneySystem;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace CaseSimulator.Gameplay.SpinSystem
{
    public class Spinner : MonoBehaviour
    {
        public static Action<CaseInfo> OnCaseSpinned;

        [SerializeField] private Button _spinButton;
        [SerializeField] private Button _backButton;
        [SerializeField] private RectTransform _spinPanel;
        [SerializeField] private WinArrow _winArrow;
        [SerializeField] private ItemSpawner _spawner;
        [Space]
        [SerializeField] private float _spinMaxSpeed;
        [SerializeField] private float _breakSpeed;
        [SerializeField] private float _stopSpinSpeed;
        [SerializeField] private float _spawnSpread;
        [SerializeField] private float _spinSpread;

        private float _spinSpeed;
        private bool _isSpin;

        private void OnEnable()
        {
            Vector2 newPos = new Vector3(UnityEngine.Random.Range(-_spawnSpread, 0), _spinPanel.position.y);
            _spinPanel.anchoredPosition = newPos;
            _spinButton.gameObject.SetActive(true);
            _backButton.gameObject.SetActive(true);
        }

        public void StartSpin()
        {
            Bank.RemoveMoney(_spawner.Case.Cost);
            _isSpin = true;
            _spinSpeed = _spinMaxSpeed;
            _spinButton.gameObject.SetActive(false);
            _backButton.gameObject.SetActive(false);
        }

        private void Update()
        {
            if (_isSpin)
            {
                if(_spinSpeed > _stopSpinSpeed)
                {
                    Vector2 newPos = new Vector2(_spinPanel.anchoredPosition.x - _spinSpeed * Time.deltaTime, _spinPanel.anchoredPosition.y);
                    _spinPanel.anchoredPosition = newPos;
                    _spinSpeed -= _breakSpeed * Time.deltaTime;
                }
                else
                {
                    _isSpin = false;
                    _spinSpeed = 0;
                    _winArrow.OnWin();
                }
            }
        }
    }
}