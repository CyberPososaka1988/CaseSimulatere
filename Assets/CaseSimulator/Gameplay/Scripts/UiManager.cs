using CaseSimulator.Gameplay.CaseSystem;
using CaseSimulator.Gameplay.SpinSystem;
using UnityEngine;

namespace CaseSimulator.Gameplay
{
    public class UiManager : MonoBehaviour
    {
        [SerializeField] private Canvas _ourGamesUI;
        [SerializeField] private Transform _gameUI;
        [SerializeField] private Canvas _mainCanvas;
        [SerializeField] private Canvas _clickerCanvas;
        [SerializeField] private Canvas _caseCanvas;
        [SerializeField] private Canvas _spinCanvas;
        [SerializeField] private Canvas _inventoryCanvas;
        [SerializeField] private ItemSpawner _itemSpawner;
        [SerializeField] private WinningPanel _winningPanel;

        #region MONO

        private void OnEnable()
        {
            WinningPanel.OnRewardClaimed += ToCases;
            CaseManager.OnCaseSelected += ToOpenCase;
        }

        private void OnDisable()
        {
            WinningPanel.OnRewardClaimed -= ToCases;
            CaseManager.OnCaseSelected -= ToOpenCase;
        }

        #endregion

        public void ToClicker()
        {
            if (Time.timeScale == 1)
            {
                _clickerCanvas.gameObject.SetActive(true);
                _mainCanvas.gameObject.SetActive(true);
                _caseCanvas.gameObject.SetActive(false);
                _inventoryCanvas.gameObject.SetActive(false);
            }
        }

        public void ToCases()
        {
            if (Time.timeScale == 1)
            {
                _mainCanvas.gameObject.SetActive(true);
                _clickerCanvas.gameObject.SetActive(false);
                _caseCanvas.gameObject.SetActive(true);
                _spinCanvas.gameObject.SetActive(false);
                _inventoryCanvas.gameObject.SetActive(false);
            }
        }

        public void ToInventory()
        {
            if (Time.timeScale == 1)
            {
                _mainCanvas.gameObject.SetActive(true);
                _clickerCanvas.gameObject.SetActive(false);
                _caseCanvas.gameObject.SetActive(false);
                _inventoryCanvas.gameObject.SetActive(true);
            }
        }

        public void ToOpenCase(CaseInfo caseInfo)
        {
            if (Time.timeScale == 1)
            {
                _caseCanvas.gameObject.SetActive(false);
                _spinCanvas.gameObject.SetActive(true);
                _mainCanvas.gameObject.SetActive(false);
                _clickerCanvas.gameObject.SetActive(false);
                _itemSpawner.Spawn(caseInfo);
                _winningPanel.Hide();
            }
        }

        public void ToOurGames()
        {
            if (Time.timeScale == 1)
            {
                _ourGamesUI.gameObject.SetActive(true);
                _gameUI.gameObject.SetActive(false);
            }
        }

        public void ToGame()
        {
            if (Time.timeScale == 1)
            {
                _ourGamesUI.gameObject.SetActive(false);
                _gameUI.gameObject.SetActive(true);
            }
        }
    }
}