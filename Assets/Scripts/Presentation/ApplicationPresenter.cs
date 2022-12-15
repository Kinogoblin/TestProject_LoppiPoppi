using LoppiPoppi.Data;
using LoppiPoppi.Domain;
using UnityEngine;

namespace LoppiPoppi.Presentation
{
    public static class ApplicationPresenter
    {
        private static DataController dataController;
        private static ValueСalculator valueСalculator;
        private static ICalculatorView calculatorView;

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void Init()
        {
            dataController = new DataController();
            valueСalculator = new ValueСalculator();
            Application.quitting += SaveBeforeQuit;

#if UNITY_EDITOR
            UnityEditor.EditorApplication.quitting += SaveBeforeQuit;
#endif
        }

        public static void SetAndInitCalculatorView(ICalculatorView view)
        {
            calculatorView = view;
            calculatorView.SetSavedEquation(dataController.GetSavedEquation());
            calculatorView.AddListenerForCalculation(GetCalculationResult);
        }

        private static void GetCalculationResult()
        {
            string equation = calculatorView.GetCurrentEquation();
            dataController.SaveEquation(equation);
            string result = valueСalculator.CalculateResult(equation);
            calculatorView.SetResult(result);
        }

        private static void SaveBeforeQuit()
        {
            string equation = calculatorView.GetCurrentEquation();
            dataController.SaveEquation(equation);
        }
    }
}