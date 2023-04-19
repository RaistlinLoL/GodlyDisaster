using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlenetaryMovement : MonoBehaviour
{
     [SerializeField]
    private float _mouseSensitivity = 3.0f;
    private float _keyboardSensitivity = 1.0f;
    private bool mouseOrKeyBoard = true;

    private float _rotationY;
    private float _rotationX;

    [SerializeField]
    private Transform _target;

    [SerializeField]
    private float _distanceFromTarget = 3.0f;

    private Vector3 _currentRotation;
    private Vector3 _smoothVelocity = Vector3.zero;

    [SerializeField]
    private float _smoothTime = 0.2f;

    [SerializeField]
    private Vector2 _rotationXMinMax = new Vector2(-40, 40);

    [SerializeField]int zoomRate;

    void Start()
    {
        //hideCursor();
    }
    void Update()
    {

        if (Input.GetKey(KeyCode.Escape))
        {

            //showCursor();
        }
        if (Input.GetMouseButtonUp(0))
        {
            //hideCursor();
        }
        
        if(!mouseOrKeyBoard)
        {
            MouseMovement();
        }
        else
        {
            KeyBoardMovement();
        }

        zoomInAndOut();


        if (Input.GetKeyDown(KeyCode.P))
        {
            mouseOrKeyBoard = !mouseOrKeyBoard;
        }

    }

    void MouseMovement()
    {
        float mouseX = Input.GetAxis("Mouse X") * _mouseSensitivity;
        float mouseY = -Input.GetAxis("Mouse Y") * _mouseSensitivity;

        _rotationY += mouseX;
        _rotationX += mouseY;

        MoveCamera();

    }

    void KeyBoardMovement()
    {
        float keyboardX = -Input.GetAxis("Horizontal") * _keyboardSensitivity;
        float keyboardY = Input.GetAxis("Vertical") * _keyboardSensitivity;

        _rotationY += keyboardX;
        _rotationX += keyboardY;

        MoveCamera();
    }

    void MoveCamera()
    {
        // Apply clamping for x rotation 
        //_rotationX = Mathf.Clamp(_rotationX, _rotationXMinMax.x, _rotationXMinMax.y);

        Vector3 nextRotation = new Vector3(_rotationX, _rotationY);

        // Apply damping between rotation changes
        _currentRotation = Vector3.SmoothDamp(_currentRotation, nextRotation, ref _smoothVelocity, _smoothTime);
        transform.localEulerAngles = _currentRotation;

        // Substract forward vector of the GameObject to point its forward vector to the target
        transform.position = _target.position - transform.forward * _distanceFromTarget;
    }

    void zoomInAndOut()
    {

        Camera cam = GetComponent<Camera>();
        if (Input.mouseScrollDelta.y > 0)
        {
            float fov = Mathf.Clamp(cam.fieldOfView + zoomRate,9.5f,90);
           cam.fieldOfView = fov;
        }
        else if (Input.mouseScrollDelta.y < 0)
        {
            float fov = Mathf.Clamp(cam.fieldOfView - zoomRate, 9.5f, 90);
            cam.fieldOfView = fov;
        }
       
    }

    void hideCursor()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;

    }
    void showCursor()
    {
        Cursor.visible = true;
    }

}
