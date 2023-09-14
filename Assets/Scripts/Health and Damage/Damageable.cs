using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Damageable : MonoBehaviour
{
    [SerializeField]
    private UnityEvent<float> DamageGot;
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.collider.TryGetComponent<AttackSystem>(out var attacksystem))
        {
            DamageGot?.Invoke(attacksystem.Damage);
        }
    }
}
