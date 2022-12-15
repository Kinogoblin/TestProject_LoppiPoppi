using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace LoppiPoppi.Presentation
{
    public class CalculatorWindows11View : MonoBehaviour, ICalculatorView
    {
        [SerializeField] private TMP_InputField _tmpInputField;
        [SerializeField] private Button _buttonGetResult;
        [SerializeField] private TMP_Text _resultText;

        event Action onCalculateResult;

        #region InterfaceImplementation

        string ICalculatorView.currentEquation
        {
            get => _tmpInputField.text;
            set => _tmpInputField.text = value;
        }

        string ICalculatorView.resultText
        {
            get => _resultText.text;
            set => _resultText.text = value;
        }

        public void Init()
        {
            _buttonGetResult.onClick.AddListener(OnCalculateResult);
            ApplicationPresenter.SetAndInitCalculatorView(this);
        }

        public void AddListenerForCalculation(Action reaction)
        {
            onCalculateResult = reaction;
        }

        #endregion

        #region Unity Callbacks

        private void OnEnable()
        {
            Init();
        }

        private void OnDisable()
        {
            _buttonGetResult.onClick.RemoveListener(OnCalculateResult);
        }

        #endregion


        private void OnCalculateResult()
        {
            onCalculateResult?.Invoke();
        }
    }
}