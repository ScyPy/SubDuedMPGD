using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LobbyManager : MonoBehaviour
{
    public static LobbyManager Instance;

    [Header("UI Items")]
    public GameObject MainMenuPanel;
    [SerializeField] private Button _playBtn;
    [SerializeField] private Button _settingsBtn;
    [SerializeField] private TextMeshProUGUI _highScoreText;
    [SerializeField] private Slider _difficultySlider;
    [SerializeField] private TextMeshProUGUI _chosenDifficulty;

    [Header("Loading Scene properties")]
    public Slider LoadingBar;
    public TextMeshProUGUI LoadingProgressText;
    public float LoadingProgress;
    public AudioSource AudioSource;
    public AudioClip MainMenuMusic;


    public static E_Difficulty PlayerChosenDifficulty;

    [Header("Settings Panel")]
    public GameObject SettingsPanel;
    [SerializeField] private Dropdown _qualityOptions;
    [SerializeField] private Toggle _vSyncToggle;



    void Start()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(Instance);
        LoadingBar.gameObject.SetActive(false);
        LoadingProgressText.gameObject.SetActive(false);
        var quality = QualitySettings.GetQualityLevel();
        _qualityOptions.value = quality;
        AudioSource = GetComponent<AudioSource>();
        AudioSource.clip = MainMenuMusic;
        AudioSource.Play();
        _highScoreText.text = $"Highest Round: {PlayerPrefs.GetInt("HighestRound")}";
        SetDifficulty(1);
    }

    public void LoadScene()
    {
        TransitionUI();
        StartCoroutine(LoadingScreen());
    }


    private IEnumerator LoadingScreen()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(1, LoadSceneMode.Single);
        while (!operation.isDone)
        {
            float loadingProgress = Mathf.Clamp01(operation.progress / 0.9f);
            LoadingProgress = loadingProgress;
            LoadingBar.value = loadingProgress;
            LoadingProgressText.text = (loadingProgress * 100f).ToString() + "%";

            yield return null;

        }

    }
    private void TransitionUI()
    {
        //MainMenuPanel.SetActive(false);
        _playBtn.gameObject.SetActive(false);
        _settingsBtn.gameObject.SetActive(false);
        _highScoreText.gameObject.SetActive(false);
        _difficultySlider.gameObject.SetActive(false);
        _chosenDifficulty.gameObject.SetActive(false);
        SettingsPanel.SetActive(false);

        LoadingBar.gameObject.SetActive(true);
        LoadingProgressText.gameObject.SetActive(true);
        
    }

    public void SetDifficulty(float diff)
    {
        switch (diff)
        {
            case 0:
                _chosenDifficulty.text = $"Difficulty: Easy";
                break;
            case 1:
                _chosenDifficulty.text = $"Difficulty: Medium";
                break;
            case 2:
                _chosenDifficulty.text = $"Difficulty: Hard";
                break;
            case 3:
                _chosenDifficulty.text = $"Difficulty: Insane";
                break;
            default:
                _chosenDifficulty.text = $"Difficulty: Medium";
                break;
        }
        PlayerPrefs.SetInt("Difficulty", (int)diff);
    }

    public void ApplyQuality()
    {
        Debug.LogError(_qualityOptions.value);
        QualitySettings.SetQualityLevel(_qualityOptions.value);
        if (_vSyncToggle.isOn)
            QualitySettings.vSyncCount = 1;
        else
            QualitySettings.vSyncCount = 0;
    }

    public void OnSettingsClick()
    {
        MainMenuPanel.SetActive(false);
        SettingsPanel.SetActive(true);
    }

    public void OnMainMenuClick()
    {
        SettingsPanel.SetActive(false);
        MainMenuPanel.SetActive(true);
    }

}
