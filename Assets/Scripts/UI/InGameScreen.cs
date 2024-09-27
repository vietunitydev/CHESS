using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InGameScreen : MonoSingleton<InGameScreen>
{
    [SerializeField] private TextMeshProUGUI chooseText;

    public void SetText(string content)
    {
        chooseText.text = content;
    }

}
