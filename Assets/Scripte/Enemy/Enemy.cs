using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float movementSpeed = 5;
    public float attackdamage = 10;
    
    public void Movement()
    {
        Debug.Log("Movimiento base");
    }

    public virtual void Attack() //Nos permite modificar esta funcion, modificar su movimiento.
    {
        Debug.Log("Ataque base");
    }
}
