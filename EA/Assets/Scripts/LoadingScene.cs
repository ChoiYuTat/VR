using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoadingScene : MonoBehaviour
{
    [Header("LOADING SCREEN")]
    [Tooltip("If this is true, the loaded scene won't load until receiving user input")]
    public bool waitForInput = true;
    public GameObject loadingMenu;
    [Tooltip("The loading bar Slider UI element in the Loading Screen")]
    public Slider loadingBar;
    public TMP_Text loadPromptText;
    public KeyCode userPromptKey;
}
