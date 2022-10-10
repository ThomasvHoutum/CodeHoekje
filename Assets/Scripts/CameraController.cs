using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform _playerHead, _playerBody, _clipPoint;

    [SerializeField] private float _rotationSpeed;
    private float _xInput, _yInput;
    private float _distToPlayer = -8;
    private float _minDistToPlayer = -1f;
    private float _maxDistToPlayer = -8;

    private float _minXAngle = -60;
    private float _maxXAngle = 70;

    private RaycastHit hit;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void Start() { _playerHead.localEulerAngles = Vector3.zero; }

    private void Update()
    {
        GetInput();
        CameraMovement();
    }
    private void FixedUpdate()
    {
        PreventClipping();
    }
    private void GetInput()
    {
        _xInput = Input.GetAxis("Mouse X");
        _yInput = Input.GetAxis("Mouse Y");
    }

    private void CameraMovement()
    {
        Vector3 headRot = _playerHead.localEulerAngles;
        float currentRot = headRot.x + _yInput * _rotationSpeed * Time.deltaTime;
        Vector3 rotateHead = new Vector3(currentRot, headRot.y, headRot.z);

        _playerHead.transform.localEulerAngles = rotateHead;

        float relRange = (_maxXAngle - _minXAngle) / 2f;
        float offset = _maxXAngle - relRange;

        Vector3 angles = _playerHead.localEulerAngles;
        float x = ((angles.x + 540) % 360) - 180 - offset;

        if (Mathf.Abs(x) > relRange)
        {
            angles.x = relRange * Mathf.Sign(x) + offset;
            _playerHead.localEulerAngles = angles;
        }

        Vector3 bodyRot = _playerBody.eulerAngles;
        Vector3 rotateBody = new Vector3(bodyRot.x, bodyRot.y + (_xInput * _rotationSpeed) * Time.deltaTime, bodyRot.z);

        _playerBody.transform.eulerAngles = rotateBody;
    }

    private void PreventClipping()
    {
        Vector3 beginPoint = new Vector3(_clipPoint.position.x, _clipPoint.position.y, _clipPoint.position.z);
        Debug.DrawRay(beginPoint, transform.forward, Color.red);
        if (Physics.Raycast(beginPoint, transform.forward, out hit, 8))
        {
            if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Ignore Raycast")) return;
            if (!hit.collider.CompareTag("Player"))
            {
                _distToPlayer = _distToPlayer + hit.distance;
            }
            else
            {
                if (_distToPlayer < _maxDistToPlayer)
                {
                    _distToPlayer = _maxDistToPlayer;
                    return;
                }
                else if (_distToPlayer == _maxDistToPlayer) return;
                else
                {
                    if (Physics.Raycast(beginPoint, -transform.forward, out hit, .5f))
                    {
                        _distToPlayer = _distToPlayer - hit.distance;
                    }
                    else
                    {
                        _distToPlayer = _distToPlayer - 2.5f * Time.fixedDeltaTime;
                    }
                }
            }
        }
        _distToPlayer = Mathf.Clamp(_distToPlayer, _maxDistToPlayer, _minDistToPlayer);
        transform.localPosition = Vector3.Lerp(transform.localPosition, new Vector3(transform.localPosition.x, transform.localPosition.y, _distToPlayer), .5f);
    }
}
