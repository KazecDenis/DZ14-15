using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float _rotateSpeed;
    private float _horizontalInput;
    private float _verticalInput;
    public Vector3 Direction {get; private set;} 
    
    private float _deadZone = 0.1f;
    private CharacterController _characterController;
    private Character _character;
    private const string _horizontalAxisKey = "Horizontal";
    private const string _verticalAxisKey = "Vertical";

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        _character = GetComponent<Character>();
    }

    private void Update()
    {
        _horizontalInput = Input.GetAxis(_horizontalAxisKey);
        _verticalInput = Input.GetAxis(_verticalAxisKey);

        Direction = new Vector3(_horizontalInput, 0, _verticalInput);
        if (Direction.magnitude < _deadZone)
            return;

        RotationTo(Direction);
        MoveTo(Direction);
    }

    

    private void MoveTo(Vector3 direction)
    {
        _characterController.Move(direction * _character.MoveSpeed * Time.deltaTime);
    }
        

    private void RotationTo(Vector3 direction)
    {
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        float step = _rotateSpeed * Time.deltaTime;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, step);
    }
}
