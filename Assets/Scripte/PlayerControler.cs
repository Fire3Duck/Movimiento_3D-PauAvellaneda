using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private CharacterController _controller;

    private InputAction _moveAction;

    private Vector2 _moveInput;
    private InputAction _jumpAction;

    private InputAction _lookAction;
    private Vector2 _lookInput;

    [SerializeField] private float _movementSpeed = 5;
    [SerializeField] private float _jumpHeight = 2;

    [SerializeField] private float _smoothTime = 0.2f;

    private float _turnSmoothVelcity;   

    //gravedad

    [SerializeField] private float _gravity = -9.81f;
   
    [SerializeField] private Vector3 _playerGravity;

    //groundsensor

    [SerializeField] Transform _sensor;

    [SerializeField] LayerMask _groundLayer;

    [SerializeField] float _sensorRadius;

    private Transform _maincamera;

    void Awake()
    {
        _controller = GetComponent <CharacterController>();
        _moveAction = InputSystem.actions["Move"];
        _jumpAction = InputSystem.actions["Jump"];
        _lookAction = InputSystem.actions["Look"];

        _maincamera = Camera.main.transform;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _moveInput = _moveAction.ReadValue<Vector2>();
        _lookInput = _lookAction.ReadValue<Vector2>();

       // MovimientoCutre();
       //Movimiento2();
       Movement();

        if(_jumpAction.WasPressedThisFrame() && IsGrounded())
        {
            Jump();
        }
        Gravity();
    }

    void Movement()
    {
         Vector3 direction = new Vector3(_moveInput.x, 0, _moveInput.y);

        if(direction != Vector3.zero)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + _maincamera.eulerAngles.y; // para que el personaje gire la cabeza
            float smoothAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _turnSmoothVelcity, _smoothTime);
            transform.rotation = Quaternion.Euler(0, smoothAngle, 0);

            Vector3 moveDirection = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;

            _controller.Move(moveDirection.normalized * _movementSpeed * Time.deltaTime);
        }
    }

    void Movimiento2()
    {
        Vector3 direction = new Vector3(_moveInput.x, 0, _moveInput.y);

        Ray ray = Camera.main.ScreenPointToRay(_lookInput);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            Vector3 playerforward = hit.point - transform.position;
            playerforward.y = 0;
            transform.forward = playerforward;
        }

        if(direction != Vector3.zero)
        {
            _controller.Move(direction.normalized * _movementSpeed * Time.deltaTime);
        }
    }

    void MovimientoCutre()
    {
        

        Vector3 direction = new Vector3(_moveInput.x, 0, _moveInput.y);

        if(direction != Vector3.zero)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg; // para que el personaje gire la cabeza
            float smoothAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _turnSmoothVelcity, _smoothTime);
            transform.rotation = Quaternion.Euler(0, smoothAngle, 0);

            _controller.Move(direction.normalized * _movementSpeed * Time.deltaTime);
        }
    }

        

    
    void Jump()
    {
        _playerGravity.y = Mathf.Sqrt(_jumpHeight * -2 * _gravity);

        _controller.Move(_playerGravity * Time.deltaTime);
    }
    
    void Gravity()
    {
        if(!IsGrounded())
        {
            _playerGravity.y += _gravity * Time.deltaTime;
        }
        else if(IsGrounded() && _playerGravity.y < -2)
        {
            _playerGravity.y = _gravity;
        }

        _controller.Move(_playerGravity * Time.deltaTime);
    }
    

    bool IsGrounded()
    {
        return Physics.CheckSphere(_sensor.position, _sensorRadius, _groundLayer);
    }


    /*void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(_sensor.position, _sensorRadius);
    }*/
    
}