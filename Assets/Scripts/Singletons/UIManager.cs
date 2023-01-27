using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Image Crosshair;
    [SerializeField] private Camera _mainCamera;

    private const float _maxShootingDistance = 20f;

    [SerializeField] private TextMeshProUGUI _playerPrompt;

    public static UIManager Instance;

    private bool _isInteracting;

    [SerializeField] private PlayerHandler _player;

    [SerializeField] private TextMeshProUGUI _goldAmount;

    public InventorySlot[] InventorySlots;

    private int _oldGold;

    [SerializeField] private Slider _healthBar;

    [SerializeField] private TextMeshProUGUI _hpAmount;

    [SerializeField] private TextMeshProUGUI _roundText;

    public GameObject GameOverScreen;
    public TextMeshProUGUI AchievedRoundText;

    public GameObject CheatScreen;
    public TMP_InputField CheatInput;

    private Dictionary<string, Action> _cheatList;

    void Awake()
    {
        if (Instance != null)
            Destroy(gameObject);
        else
            Instance = this;
    }
    void Start()
    {
        GameOverScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void EnablePlayerPrompt(string promptText)
    {
        _playerPrompt.text = promptText;
        _playerPrompt.gameObject.SetActive(true);
    }

    public void DisablePlayerPrompt() => _playerPrompt.gameObject.SetActive(false);


    private void InteractingInput()
    {
        _isInteracting = true;
    }

    public void UpdateGold(int gold)
    {
        _goldAmount.text = gold.ToString();
    }

    public void UpdateHealth(int Health)
    {
        var hp = (float)(Health / 100f);
        _healthBar.value = hp;
        _hpAmount.text = (hp * 100).ToString();
    }

    public void AddToInventory(InventoryItem item)
    {
        foreach (InventorySlot slot in InventorySlots)
        {
            if (slot.Item == null)
            {
                slot.AddItem(item);
                return;
            }
        }
    }

    public void RemoveFromInventory(InventoryItem item)
    {
        foreach (InventorySlot slot in InventorySlots)
        {
            if (slot.Item == item)
            {
                slot.RemoveItem();
            }
        }
    }

    public bool InventoryFull()
    {
        foreach (var slot in InventorySlots)
        {
            if (slot.Item == null) return false;
        }
        return true;
    }
    public void BeginRound(int round)
    {
        StartCoroutine(RoundPause(round));
    }

    private IEnumerator RoundPause(int round)
    {
        _roundText.text = $"Round {round}";
        _roundText.gameObject.SetActive(true);
        yield return new WaitForSeconds(4f);
        _roundText.gameObject.SetActive(false);
        yield return null;
    }
    public void GameOver()
    {
        _mainCamera.transform.position = Vector3.zero;
        GameOverScreen.gameObject.SetActive(true);
        AchievedRoundText.text = $"Round Achieved: {GameManager.Instance.CurrentRound}";
        PlayerPrefs.SetInt("HighestRound", GameManager.Instance.CurrentRound);
        StartCoroutine(LoadMainMenu());
    }

    private IEnumerator LoadMainMenu()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(0, LoadSceneMode.Single);
        yield return null;
    }

    public void CheatMenuActivated()
    {
        CheatScreen.gameObject.SetActive(true);
        CheatInput.ActivateInputField();
    }

    public void RegisterCheat()
    {
        switch (CheatInput.text)
        {
            case "/health":
                _player.Health += 1000;
                break;
            case "/gold":
                _player.Gold += 1000;
                break;
            case "/infinitebullets":
                _player.SetFireRate();
                break;
            default:
                EnablePlayerPrompt("Incorrect Cheat-code");
                break;
        }
        CheatInput.text = "";
        CheatScreen.gameObject.SetActive(false);
    }
}
