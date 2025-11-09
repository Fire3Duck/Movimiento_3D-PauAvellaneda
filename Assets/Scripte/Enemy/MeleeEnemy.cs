using UnityEngine;

public class MeleeEnemy : Enemy, IDamageable
{
    float maxHealth = 10;
    float currenthealth = 10;

    void Start()
    {
        Attack();
    }

    public override void Attack() //sobreescribir la funcion original.
    {
        base.Attack(); //Llama a la funcion original.
        Debug.Log("Ataque Cuerpo a Cuerpo");
    }

    void IDamageable.TakeDamage(float damage)
    {
        Debug.Log("Enemigo recibiendo daño");
    }
}