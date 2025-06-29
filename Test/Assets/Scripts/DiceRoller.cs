using UnityEngine;
using UnityEngine.UI; 
using System.Collections.Generic;
using TMPro;

public class DiceRollerUI : MonoBehaviour
{
    public TMP_Dropdown diceDropdown;
    public Button rollButton;
    public TMP_Text resultText;

    private Dictionary<string, int> diceMaxValues = new Dictionary<string, int>()
    {
        { "d3", 3 }, { "d4", 4 }, { "d6", 6 },
        { "d10", 10 }, { "d12", 12 }, { "d20", 20 }
    };

    private void Start()
    {
        diceDropdown.ClearOptions();
        diceDropdown.AddOptions(new List<string>(diceMaxValues.Keys));

        rollButton.onClick.AddListener(OnRollClicked); 
    }

    private void OnRollClicked()
    {
        string selected = diceDropdown.options[diceDropdown.value].text;
        int max = diceMaxValues[selected];
        int result = Random.Range(1, max + 1);
        resultText.text = $"{selected} rolled: {result}";
    }
}
