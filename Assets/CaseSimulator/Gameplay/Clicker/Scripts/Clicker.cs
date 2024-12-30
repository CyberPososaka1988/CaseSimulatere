using CaseSimulator.Gameplay.MoneySystem;
using UnityEngine;

namespace CaseSimulator.Gameplay.ClickerSystem
{
    public class Clicker : Sounds
    {
        [SerializeField] private string _animatorBoolName = "OnClick";
        [SerializeField] private int _multiplier;

        private Animator _animator;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void Click()
        {
            _animator.SetBool(_animatorBoolName, true);
            Bank.AddMoney(_multiplier);
            PlaySound(sounds[0]);
        }

        public void StopClickAnim()
        {
            _animator.SetBool(_animatorBoolName, false);
        }
    }
}