using System;
using JetBrains.Annotations;

namespace LoppiPoppi.Presentation
{
    public interface ICalculatorView
    {
        [NotNull]
        protected string currentEquation
        {
            get => "";
            set
            {
                if (value == null) throw new ArgumentNullException(nameof(value));
            }
        }

        [NotNull]
        protected string resultText
        {
            get => "";
            set
            {
                if (value == null) throw new ArgumentNullException(nameof(value));
            }
        }

        void Init()
        {
            ApplicationPresenter.SetAndInitCalculatorView(this);
        }

        void SetSavedEquation(string equation)
        {
            currentEquation = equation;
        }

        void SetResult(string result)
        {
            resultText = result;
        }

        string GetCurrentEquation()
        {
            return currentEquation;
        }

        void AddListenerForCalculation(Action reaction)
        {
        }

    }
}