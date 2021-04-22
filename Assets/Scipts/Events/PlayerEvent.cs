using UnityEngine;
using Weapons;

public class PlayerEvent : MonoBehaviour
{

    // weapon component
    public delegate void OnWeaponEquippedEvent(WeaponComponent weaponComponent);

    public static event OnWeaponEquippedEvent OnWeaponEquipped;

    public static void Invoke_OnWeaponEquipped(WeaponComponent weaponComponent)
    {
        OnWeaponEquipped?.Invoke(weaponComponent);
    }




    // health component
    public delegate void OnHealthIntializedEvent(HealthComponent healthComponent);

    public static event OnHealthIntializedEvent OnHealthIntialized;

    public static void Invoke_OnHealthIntialized(HealthComponent healthComponent)
    {
        OnHealthIntialized?.Invoke(healthComponent);
    }
}
