using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class WeaponController : MonoBehaviour
{
    [SerializeField]
    private Weapon weapon;

    [SerializeField]
    private float firePower;


    void Start()
    {

    }

    void Update()
    {

    }

    public void OnFire(InputAction.CallbackContext context)
    {
        if (weapon.IsReady) weapon.Fire(Time.deltaTime * firePower);
    }
}