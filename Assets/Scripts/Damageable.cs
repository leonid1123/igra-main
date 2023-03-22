using UnityEngine;
using UnityEngine.Events;

public class Damageable : MonoBehaviour
{
    [SerializeField]
    private UnityEvent<float> DamageGot;

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.TryGetComponent<Attacker>(out var attacker))
        {
            DamageGot?.Invoke(attacker.Damage);
        }
    }
}
