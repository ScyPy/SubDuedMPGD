using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    private Image _crossHair;
    private Camera _mainCamera;

    private const float _maxShootingDistance = 20f;

    public static UIManager Instance;

    void Awake()
    {
        if (Instance != null)
            Destroy(gameObject);
        else
            Instance = this;
        DontDestroyOnLoad(this);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void CombatCrosshair()
    {
        Ray ray = _mainCamera.ViewportPointToRay(_crossHair.transform.position);
        if (Physics.Raycast(ray, out RaycastHit hit, _maxShootingDistance))
        {
            if (hit.collider.tag == "Enemy")
            {
                _crossHair.color = Color.red;
            }
            else
                _crossHair.color = Color.white;

        }

    }
}
