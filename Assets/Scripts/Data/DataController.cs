using UnityEngine;

namespace LoppiPoppi.Data
{
    public class DataController
    {
        private string nameKeyForSavedEquation = "SavedEquation";

        public string GetSavedEquation()
        {
            return PlayerPrefs.GetString(nameKeyForSavedEquation, "");
        }

        public void SaveEquation(string equation)
        {
            PlayerPrefs.SetString(nameKeyForSavedEquation, equation);
        }
    }
}