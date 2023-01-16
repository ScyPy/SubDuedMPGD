using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandler : MonoBehaviour
{
    private int _health;
    public int Health { get => _health; set => _health = value; }

    private GameObject _primaryWeapon;

    public GameObject PrimaryWeapon { get => _primaryWeapon; set => _primaryWeapon = value; }

    public ushort Gold { get; set; }

    private InputManager _inputManager;

    void Start()
    {
        _inputManager = GetComponent<InputManager>();
        _inputManager.HasAttacked += Fire;
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;
        if (_health <= 0)
        {
            Die();
        }
    }
    
    public void Fire()
    {
        Debug.LogError("fired");
        if (_primaryWeapon == null) return;

        //gun Recoil
        var wepTransform = _primaryWeapon.transform.rotation;
        wepTransform.x = -30f;
        _primaryWeapon.transform.rotation = wepTransform;
        RaycastHit hit;
        //raycast to crosshair

    }
    private void Die()
    {
        //UIManager.GameOverScreen();
        //UIManager.ShowHighScore(); etc
        throw new NotImplementedException();
    }
}
