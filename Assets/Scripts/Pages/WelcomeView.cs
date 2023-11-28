using System;
using System.Collections;
using System.Collections.Generic;
using AIExhibition.UIManagement.Base;
using UnityEngine;
using UnityEngine.UI;

public class WelcomeView : View
{
    [SerializeField] private Button _button;
    [SerializeField] private View nextView;
    public override void Initialize()
    {
        Show();
        _button.onClick.AddListener(StartButtonPress);
    }

    private void OnDestroy()
    {
        _button.onClick.RemoveAllListeners();
    }

    void StartButtonPress()
    {
        nextView.Initialize();
        Hide();
    }
}
