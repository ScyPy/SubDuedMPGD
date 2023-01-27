using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int WeaponID;
    public string WeaponName;
    public int Price;
    public int Damage;
    public GameObject Prefab;
    public float FireRate;
    public GameObject FireEffect;
    public Animator Animator;
    public Vector3 OriginalRotation;
    public Vector3 RecoilRotation;
    public Transform VFXPoint;
    public AudioClip GunSFX;
}