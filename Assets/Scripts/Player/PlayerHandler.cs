using System.Collections.Generic;
using UnityEngine;

public class PlayerHandler : MonoBehaviour
{
    private int _health;
    public int Health { get => _health; set => _health = value; }

    [SerializeField] private GameObject _primaryWeaponObject;

    [SerializeField] private Weapon _primaryWepScript;

    //empty parent g.o
    [SerializeField] private GameObject _weaponHolder;

    [SerializeField] private GameObject _rayCastFirePoint;

    [SerializeField] private GameObject _fireEffect;

    public GameObject PrimaryWeapon { get => _primaryWeaponObject; set => _primaryWeaponObject = value; }

    public int Gold { get; set; }

    private InputManager _inputManager;

    private bool _attackInput;

    private Camera _mainCamera;

    private readonly float _shootingDistance = 20f;

    private float _fireRate;

    private float _lastFireTime;

    [SerializeField] private List<InventoryItem> Inventory = new List<InventoryItem>();

    public bool IsInteracting = false;

    private bool _isFiring = false;

    private float _vfxParameter = 0;

    private AudioSource _audioSource;

    public bool IsDead = false;



    void Start()
    {
        //Handling input
        _inputManager = GetComponent<InputManager>();
        _inputManager.HasAttacked += HandleFireInput;
        _inputManager.HasInteracted += Interact;
        _inputManager.HotKeyPressed += HotKeyPressed;
        _inputManager.CheatKeyPressed += CheatKeyPressed;
        _inputManager.CheatInputRegistered += SendCheat;
        _audioSource = GetComponent<AudioSource>();
        _primaryWeaponObject = _weaponHolder.transform.GetChild(0).gameObject;
        _primaryWepScript = _weaponHolder.transform.GetChild(0).GetComponent<Weapon>();
        _mainCamera = Camera.main;
        Gold = 500;
        _health = 100;
        _fireRate = 0.75f;
        GameMaster.Instance.CurrentPlayerWeapon = _primaryWepScript;
    }


    // Update is called once per frame
    void Update()
    {
        Cursor.lockState = CursorLockMode.Locked;
        if (IsDead) return;
        CombatCrosshair();
        if (_attackInput)
        {
            Attack();
        }

        if (_isFiring)
        {
            Recoil();
            EnableGunVFX();
        }
        else
        {
            StopRecoil();
        }

        UIManager.Instance.UpdateGold(Gold);
        UIManager.Instance.UpdateHealth(Health);
    }

    private void Attack()
    {
        if (_primaryWeaponObject == null || _primaryWepScript == null) return;
        RaycastHit hit;
        if (Time.time - _lastFireTime >= _fireRate)
        {
            _isFiring = true;
            _audioSource.clip = _primaryWepScript.GunSFX;
            _audioSource.Play();
            if (Physics.Raycast(_mainCamera.transform.position, _rayCastFirePoint.transform.forward, out hit, _shootingDistance))
            {
                var collider = hit.collider;
                if (collider.CompareTag("Enemy"))
                {
                    hit.collider.GetComponent<EnemyBehaviour>().TakeDamage(_primaryWepScript.Damage);
                }
            }

            _lastFireTime = Time.time;
        }
        else
        {
            _isFiring = false;
        }
    }

    public void Recoil()
    {
        _weaponHolder.transform.localEulerAngles += _primaryWepScript.RecoilRotation;
    }
    public void StopRecoil()
    {
        _weaponHolder.transform.localRotation = Quaternion.Slerp(Quaternion.Euler(_weaponHolder.transform.localEulerAngles), Quaternion.Euler(_primaryWepScript.OriginalRotation), 6f * Time.deltaTime);
    }


    public void CombatCrosshair()
    {
        Ray ray = _mainCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0.5f));
        if (Physics.Raycast(ray, out RaycastHit hit, _shootingDistance))
        {
            if (hit.collider.CompareTag("Enemy"))
            {
                UIManager.Instance.Crosshair.color = Color.red;
            }
            else
                UIManager.Instance.Crosshair.color = Color.white;

            if (hit.collider.CompareTag("Interactable") && DistanceCheck(transform.position, hit.collider.transform.position))
            {
                var item = hit.collider.GetComponent<BuyingStation>();
                UIManager.Instance.EnablePlayerPrompt("Press E to Interact");
                UseBuyingStation(item);
            }
            else
                UIManager.Instance.DisablePlayerPrompt();
        }

    }
    //Cheat
    public void SetFireRate() => _fireRate = 0.05f;

    public void UseBuyingStation(BuyingStation station)
    {
        if (station.StationType == E_BuyingStation.Weapon)
        {
            if (IsInteracting)
            {
                PurchaseWeapon(station.Weapon);
                IsInteracting = false;
            }
        }
        else if (station.StationType == E_BuyingStation.Barrier)
        {
            if (IsInteracting)
            {
                if (!station.HasBarrier)
                {
                    PurchaseBarrier(station,station.Barrier, station.BarrierSpawn);
                    station.HasBarrier = true;
                }
                IsInteracting = false;
            }
        }
        else if (station.StationType == E_BuyingStation.InventoryItem)
        {
            if (IsInteracting)
            {
                PurchaseInventoryItem(station.InventoryItem);
                IsInteracting = false;
            }
        }
        else if (station.StationType == E_BuyingStation.Door)
        {
            if (IsInteracting)
            {
                PurchaseDoor(station.Door);
                IsInteracting = false;
            }
        }
    }

    private bool DistanceCheck(Vector3 position1, Vector3 position2) => Vector3.Distance(position1, position2) <= 2f;

    private void EnableGunVFX()
    {
        GameObject gunEffect = Instantiate(_fireEffect, _weaponHolder.transform);
        gunEffect.transform.position = _primaryWepScript.VFXPoint.position;
        Destroy(gunEffect, 0.05f);
    }

    private void Interact(bool val)
    {
        IsInteracting = val;
    }

    
    private void CheatKeyPressed()
    {
        UIManager.Instance.CheatMenuActivated();
    }

    private void SendCheat()
    {
        UIManager.Instance.RegisterCheat();
    }
    public void TakeDamage(int damage)
    {
        _health -= damage;
        if (_health <= 0)
        {
            Die();
        }
        GameMaster.Instance.PlayerDamageTaken += damage;
    }

    public void HandleFireInput(bool fire)
    {
        if (_primaryWeaponObject == null) return;

        _attackInput = fire;

    }
    public void UseItem(InventoryItem item)
    {
        Health += item.HealthAdded;
    }
    public void Die()
    {
        UIManager.Instance.GameOver();
        IsDead = true;
    }

    public void PurchaseWeapon(Weapon wep)
    {
        if (wep.Price > Gold)
        {
            UIManager.Instance.EnablePlayerPrompt("Insufficient Gold");
            return;
        }
        else if (wep.WeaponID == _primaryWepScript.WeaponID) return;

        Destroy(_primaryWeaponObject.gameObject);
        _primaryWeaponObject = null;
        _primaryWepScript = null;

        var newWep = Instantiate(wep.Prefab, _weaponHolder.transform);
        _primaryWeaponObject = newWep;
        _primaryWepScript = newWep.GetComponent<Weapon>();
        GameMaster.Instance.CurrentPlayerWeapon = _primaryWepScript;
        //MuzzlePoint = newWep.transform.GetChild(0);


        //_primaryWeaponObject = null;
        //wep = null;



        _fireRate = wep.FireRate;
        Gold -= wep.Price;
    }

    public void PurchaseBarrier(BuyingStation stat, Barrier barrier, Transform spawningLoc)
    {
        if (barrier.Price > Gold)
        {
            UIManager.Instance.EnablePlayerPrompt("Insufficient Gold");
            return;
        }
        else
        {
            var bar = Instantiate(barrier.Prefab, spawningLoc.position, spawningLoc.rotation);
            bar.GetComponent<Barrier>().BuyStation = stat;
            Gold -= barrier.Price;
        }
    }

    public void PurchaseInventoryItem(InventoryItem invItem)
    {
        if (invItem.Price > Gold) return;
        if (UIManager.Instance.InventoryFull())
        {
            UIManager.Instance.EnablePlayerPrompt("Inventory Full");
            return;
        }
        UIManager.Instance.AddToInventory(invItem);

        
        Gold -= invItem.Price;
    }

    public void PurchaseDoor(Door door)
    {
        if (door.IsOpened) return;
        door.OpenDoor();
        Gold -= door.Price;
    }

    public void HotKeyPressed(int index)
    {
        var slot = UIManager.Instance.InventorySlots[index];
        if (slot.Item == null) return;
        UIManager.Instance.InventorySlots[index].UsedItem();
        UseItem(UIManager.Instance.InventorySlots[index].Item);
        slot.RemoveItem();
    }

    //public void EquipWeapon(GameObject weapon)
    //{
    //    Destroy(_primaryWeaponObject);
    //    _primaryWeaponObject = null;

    //    Instantiate(weapon, _weaponHolder.transform);
    //}
    //public void EquipWeapon(int Id)
    //{

    //}
}
