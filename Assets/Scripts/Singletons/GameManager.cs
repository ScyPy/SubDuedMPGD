using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum E_Difficulty : int
{
    Easy = 0,
    Medium =1,
    Hard =2,
    Insane = 3,
}

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameManager Instance;

    //player
    public static PlayerHandler PlayerHandler;

    public int CurrentRound = 0;

    private float _pauseTimePerRound;

    private List<GameObject> ZombieList = new List<GameObject>();
    private int _numberOfZombies { get => ZombieList.Count;}

    private int _zombiesToBeSpawned = 1;

    public E_Difficulty Difficulty;

    public AudioClip NewRoundBeginClip;

    public AudioClip BackgroundMusic;

    public AudioSource AudioSource;

    public GameObject ZombiePrefab;

    public Transform SpawnPoint;


    #region Difficulty modifier
    public float DifficultyModifier {
        get
        {
            switch (Difficulty)
            {
                case E_Difficulty.Easy:
                    return 1.5f;
                case E_Difficulty.Medium:
                    return 1f;
                case E_Difficulty.Hard:
                    return 0.8f;
                case E_Difficulty.Insane:
                    return  0.5f;
                default:
                    return 1f;
            }
        }
    }
    #endregion

    public static List<InventoryItem> ItemManager = new List<InventoryItem>();

    void Awake()
    {
        Difficulty = (E_Difficulty)PlayerPrefs.GetInt("Difficulty");
    }
    void Start()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
        AudioSource = GetComponent<AudioSource>();
        AudioSource.clip = BackgroundMusic;
        AudioSource.Play();
        StartCoroutine(InitNextRound(CurrentRound));

    }

    // Update is called once per frame
    void Update()
    {

    }
    //initialize next round
    private IEnumerator InitNextRound(int roundNr)
    {
        CurrentRound++;
        UIManager.Instance.BeginRound(CurrentRound);
        if (_zombiesToBeSpawned < 20)
            _zombiesToBeSpawned *= 2;
        else
            _zombiesToBeSpawned = 20;

        yield return new WaitForSeconds(7f);
        SpawnZombies();
        yield return null;
    }

    public void StartGame()
    {
        //player sets difficulty
        Difficulty = E_Difficulty.Easy;
        
    }

    public void SetDifficulty(System.Single value)
    {
        Debug.LogError(value);
        switch (value)
        {
            case 0:
                Difficulty = E_Difficulty.Easy;
                break;
            case 1:
                Difficulty = E_Difficulty.Medium;
                break;
            case 2:
                Difficulty = E_Difficulty.Hard;
                break;
            case 3:
                Difficulty = E_Difficulty.Insane;
                break;
            default:
                Difficulty = E_Difficulty.Medium;
                break;
        }
    }
    public void SpawnZombies()
    {
        var offset = 0.01f;
        for (int i = 0; i < _zombiesToBeSpawned; i++)
        {
            var pos = SpawnPoint.position + new Vector3(SpawnPoint.position.x + offset, SpawnPoint.position.y, SpawnPoint.position.z + offset);
            var zomb = Instantiate(ZombiePrefab, pos, Quaternion.identity);
            ZombieList.Add(zomb);
        }
    }

    public void ZombieDied(GameObject obj)
    {
        if (ZombieList.Contains(obj))
        {
            ZombieList.Remove(obj);
            if (ZombieList.Count <= 0)
                StartCoroutine(InitNextRound(CurrentRound));
        }
    }

    public void AddZombie(GameObject obj)
    {
        ZombieList.Add(obj);
    }
}
