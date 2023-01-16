using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barriers : MonoBehaviour
{
    // Start is called before the first frame update
    private int _barrierHealth;
    public int BarrierHealth { get => _barrierHealth; set => _barrierHealth = value; }

    void Start()
    {
        //switch (GameManager.DifficultyLevel)
        //{
        //    case E_Difficulty.Easy:
        //        _barrierHealth = Random.Range(80, 140);
        //        break;
        //    case E_Difficulty.Normal:
        //        _barrierHealth = Random.Range(40, 80);
        //        break;
        //    case E_Difficulty.Hard:
        //        _barrierHealth = Random.Range(20,40);
        //        break;
        //    default:
        //        _barrierHealth = Random.Range(40, 100);
        //        break;
        //}

    }

    // Update is called once per frame
    void Update()
    {
        if (_barrierHealth <= 0)
        {
            Destroy(this.gameObject);
            //VfxManager.SpawnVFX(transform.position)
        }
    }
}
