using UnityEngine;
using UnityEngine.InputSystem;
// Si aparece un SystemNumerics lo borramos.

// RayCast y Character Controller.

    //RayCast: Al hacer click en unos objetos que pase una cosa u otra. Que dispare un rayo. 
    // Necesitamos el ataque y la posicion.

public class RayCastRepaso : MonoBehaviour
{
    InputAction _clickAction;
    InputAction _positionAction;
    Vector2 _mousePosition;

    void Awake()
    {
        _clickAction = InputSystem.actions["Attack"];
        _positionAction = InputSystem.actions["Look"];
    }

    void Update()
    {
        _mousePosition = _positionAction.ReadValue<Vector2>(); //Actualizamos la variante del raton, asi sabemos donde esta el raton.

        if(_clickAction.WasPerformedThisFrame())
        {
            ShootRaycast();
        }
    }

    private void ShootRaycast() //Pilla la camera principal y coger donde esta el raton.
    {
        Ray ray = Camera.main.ScreenPointToRay(_mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            if(hit.transform.gameObject.layer == 3) //Crear en los tres ejemplos hacer un if para cada layer/tag/name.
            {

            }

            if(hit.transform.tag == "Nombre del tag")
            {

            }

            if(hit.transform.name == "sfis")
            {

            }
        }

    }
}