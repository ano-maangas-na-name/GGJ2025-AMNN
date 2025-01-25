using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Home")]
    [SerializeField] private RectTransform homeMenu;

    [Header("Settings")]
    [SerializeField] private RectTransform settingsMenu;
    [SerializeField] private Slider SFX;
    [SerializeField] private Slider BGM;

    public float uiTransitionSpeed;

    public void ShowSettingsMenu()
    {
        settingsMenu.DOAnchorPos(Vector2.zero, uiTransitionSpeed, true).SetEase(Ease.InOutElastic);
        homeMenu.DOAnchorPos(new Vector2(1100, 0), uiTransitionSpeed, true).SetEase(Ease.Linear);
    }

    public void ShowHomeMenu()
    {
        homeMenu.DOAnchorPos(Vector2.zero, uiTransitionSpeed, true).SetEase(Ease.InOutElastic);
        settingsMenu.DOAnchorPos(new Vector2(1100, 0), uiTransitionSpeed, true).SetEase(Ease.Linear);
    }
    
}
