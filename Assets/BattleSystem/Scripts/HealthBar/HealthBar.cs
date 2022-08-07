using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider slider = null;

    [SerializeField] private Damagable _damagable = null;

    private void Awake() {
        SetMaxValue(_damagable.Health);
    }

    private void Start() {
        _damagable.OnTookDamage += OnTookDamage;
    }

    private void OnDestroy() {
        _damagable.OnTookDamage -= OnTookDamage;
    }

    private void OnTookDamage(Damagable damagable)
    {
       SetHealth(_damagable.Health);
    }

    public void SetMaxValue(float health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void SetHealth(float health)
    {
        slider.value = health;
    }
}
