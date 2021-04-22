using UnityEngine;
using Systems.Health;

public class PlayerHealthComponent : HealthComponent
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        PlayerEvent.Invoke_OnHealthIntialized(this);
    }

   
}
