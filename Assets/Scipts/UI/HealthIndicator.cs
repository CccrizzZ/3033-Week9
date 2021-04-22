using UnityEngine;
using UnityEngine.UI;
using Systems.Health;

public class HealthIndicator : MonoBehaviour
{

    Text CurrentHealthText;
    HealthComponent P_HealthComponent;


    private void Start()
    {
        CurrentHealthText = GetComponent<Text>();
        
    }

    // add delegate
    private void OnEnable()
    {
        PlayerEvent.OnHealthIntialized += OnHealthIntialized;
    }

    // remove delegate
    private void OnDisable()
    {
        PlayerEvent.OnHealthIntialized -= OnHealthIntialized;
    }

    
    
    private void OnHealthIntialized(HealthComponent healthComponent)
    {
        P_HealthComponent = healthComponent;
    }

    void Update()
    {
        CurrentHealthText.text = P_HealthComponent.Health.ToString();
    }
}
