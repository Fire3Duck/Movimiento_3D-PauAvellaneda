using UnityEngine;

public class MeleeEnemy : Enemy
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Attack();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void Attack() //sobreescribir la funcion original.
    {
        base.Attack(); //Llama a la funcion original.
        Debug.Log("Ataque Cuerpo a Cuerpo");
    }
}
