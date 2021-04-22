using UnityEngine;
using Systems.Health;

public class HealthComponent : MonoBehaviour, IDamagable
{

    public float Health => CurrentHealth;
    public float MaxHealth => TotalHealth;

    
    
    [SerializeField]
    private float CurrentHealth;
    
    [SerializeField]
    private float TotalHealth;

   
    protected virtual void Start()
    {
        CurrentHealth = TotalHealth;
    }
   
   
    public virtual void Destroy()
    {
        Destroy(gameObject);
    }


    public virtual void TakeDamage(float damage)
    {
        
        if (CurrentHealth - damage <= 0)
        {
            CurrentHealth = 0;
            Destroy();
        }
        else
        {
            CurrentHealth -= damage;


        }
    }
}
