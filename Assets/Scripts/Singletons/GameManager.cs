using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum E_Difficulty
{
    Easy = 1,
    Medium =2,
    Hard =3,
    Insane = 4,
}

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameManager Instance;

    private int _currentRound;

    private float _timePerRound;

    private float _numberOfZombies;

    [SerializeField] private GameObject _player;

    public E_Difficulty Difficulty;

    
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
    }

    // Update is called once per frame
    void Update()
    {
        if (_numberOfZombies <= 0)
        {
            StartCoroutine(InitNextRound(_currentRound));
        }
    }
    //initialize next round
    private IEnumerator InitNextRound(int roundNr)
    {
        yield return new WaitForSeconds(0.5f);
        _currentRound++;
        //Call uimanager to do new current round anim
        //Grant player health (depending on difficulty)
        //Spawn new zombs
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
}
