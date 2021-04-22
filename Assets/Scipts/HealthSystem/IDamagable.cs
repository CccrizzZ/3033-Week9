namespace Systems.Health
{ 
    public interface IDamagable
    {
        void TakeDamage(float damage);

        void Destroy();
    }
}