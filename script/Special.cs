using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Special : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI specialText;

    int special = 0;
    int maxSpecial = 10;

    void Start()
    {
        UpdateText();
    }

    public void AddSpecial(int value)
    {
        special += value;
        special = Mathf.Clamp(special, 0, maxSpecial);
        UpdateText();
    }

    void UpdateText()
    {
        // êîéöÇæÇØçXêV
        specialText.text = special.ToString();
    }

    public void ResetSpecial()
    {
        special = 0;
        UpdateText();
    }
}
