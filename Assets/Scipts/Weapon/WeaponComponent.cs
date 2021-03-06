using System;
using Character;
using Character.UI;
using UnityEngine;

namespace Weapons
{
    public enum WeaponType
    {
        None,
        Pistol,
        MachineGun
    }





    [Serializable]
    public struct WeaponStats
    {
        public WeaponType WeaponType;
        public string WeaponName;
        public float Damage;
        public int BulletsInClip;
        public int ClipSize;
        public int BulletsAvailable;
        public float FireStartDelay;
        public float FireRate;
        public float FireDistance;
        public bool Repeating;
        public LayerMask WeaponHitLayers;
    }





    public class WeaponComponent : MonoBehaviour
    {
        // grip Inverse Kinematic location
        public Transform GripLocation => GripIKLocation;
        [SerializeField] private Transform GripIKLocation;
  
        public WeaponStats WeaponInformation => WeaponStats;
  
        [SerializeField] protected WeaponStats WeaponStats;
        
        [Header("Particles")]
        [SerializeField] protected GameObject FiringAnimation;
        [SerializeField] protected Transform ParticleSpawnLocation;
        
        protected Camera MainCamera;
        protected WeaponHolder WeaponHolder;
        protected CrosshairScript CrosshairComponent;
        
        protected ParticleSystem FiringEffect;

        public bool Firing { get; private set; }
        public bool Reloading { get; private set; }




        private void Awake()
        {
            // set camera ref
            MainCamera = Camera.main;
        }

        public void Initialize(WeaponHolder weaponHolder, CrosshairScript crossHair)
        {
            // set weapon holder ref and crosshair ref
            WeaponHolder = weaponHolder;
            CrosshairComponent = crossHair;
        }

        public virtual void StartFiringWeapon()
        {
            Firing = true;
            if (WeaponStats.Repeating)
            {
                // repeat firing according to weapon data
                InvokeRepeating(nameof(FireWeapon), WeaponStats.FireStartDelay, WeaponStats.FireRate);
            
            }
            else
            {
                FireWeapon();
            }
        }
 



        public virtual void StopFiringWeapon()
        {
            Firing = false;
            if (FiringEffect)
            {
                Destroy(FiringEffect.gameObject);
            }
            CancelInvoke(nameof(FireWeapon));
        }

        protected virtual void FireWeapon()
        {
            // Debug.Log(WeaponStats.BulletsInClip + " / " + WeaponStats.BulletsAvailable);
            WeaponStats.BulletsInClip--;
        }

        public virtual void StartReloading()
        {
            Reloading = true;
            ReloadWeapon();
        }

        public virtual void StopReloading()
        {
            Reloading = false;
        }

        protected virtual void ReloadWeapon()
        {
            // determine how many bullet to load
            if (FiringEffect)
            {
                Destroy(FiringEffect.gameObject);
            }
            int bulletsToReload = WeaponStats.ClipSize - WeaponStats.BulletsAvailable;
            
            if (bulletsToReload < 0)
            {
                WeaponStats.BulletsInClip = WeaponStats.ClipSize;
                WeaponStats.BulletsAvailable -= WeaponStats.ClipSize;
            }
            else
            {
                WeaponStats.BulletsInClip = WeaponStats.BulletsAvailable;
                WeaponStats.BulletsAvailable = 0;
            }
        }
    }
}