using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class GameMaster : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameMaster Instance;
    public GameObject PredatorPrefab;
    public int PlayerDamageTaken;
    public int PlayerTotalGold;
    public PlayerHandler Player;
    public int PlayerHealth { get => Player.Health; }
    public Weapon CurrentPlayerWeapon;
    public int RoundSpawned = 1;
    public GameObject InstantiatedPredator;
    void Start()
    {
        if (Instance != null)
            Destroy(gameObject);
        else
            Instance = this;
    }

    public void SetWeapon(Weapon wep)
    {
        CurrentPlayerWeapon = wep;
    }


    public void SpawnPredator()
    {
        if (!PlayerConditions()) return;

        RoundSpawned = GameManager.Instance.CurrentRound;
        InstantiatedPredator = Instantiate(PredatorPrefab, GameManager.Instance.SpawnPoint);
        InstantiatedPredator.GetComponent<EnemyBehaviour>().SetDamage(25);
        GameManager.Instance.AddZombie(InstantiatedPredator);
    }
    private bool PlayerConditions()
    {
        //not spawn when easy difficulty
        if (GameManager.Instance.Difficulty == E_Difficulty.Easy) return false;

        if (InstantiatedPredator != null) return false;
        //Player has default revolver. Not suitable for this enemy.
        if (CurrentPlayerWeapon.WeaponID == 0) return false;

        if (Player.Gold < 500) return false;

        if (Player.Health < 75) return false;

        if (GameManager.Instance.CurrentRound == 0) return false;




        return true;
    }
    // Update is called once per frame
    void Update()
    {
        SpawnPredator();
    }
}
