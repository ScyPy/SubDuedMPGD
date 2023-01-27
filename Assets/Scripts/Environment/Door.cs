using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    // Start is called before the first frame update
    public int Price;
    public bool IsOpened = false;
    public GameObject DoorPrefab;
    public Animator Animator;
    public Collider Collider;
    void Start()
    {
        //Animator = GetComponent<Animator>();
    }

    public void OpenDoor()
    {
        Animator.SetTrigger("Opendoor");
        Destroy(Collider);
        IsOpened = true;
    }
}
