using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float movementSpeed = 5;
    public float attackdamage = 10;
    public float health = 50;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Movement()
    {
        Debug.Log("Movimiento base");
    }

    public virtual void Attack() //Nos permite modificar esta funcion, modificar su movimiento.
    {
        Debug.Log("Ataque base");
    }
    
    public void TakeDamage()
    {
        Debug.Log("Daño base");
    }
}
