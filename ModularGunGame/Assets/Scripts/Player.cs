using UnityEngine;
using UnityEngine.InputSystem;
using static InputSystem_Actions;

public class Player : MonoBehaviour, IPlayerActions
{
    GunRandomiser gr;
    gun currentGun;
    gun nextGun;

    InputSystem_Actions controls;
    private float speed;
    private Rigidbody rbody;
    private Vector2 moveInput;
    private Vector3 movement;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if (controls == null)
        {
            controls = new InputSystem_Actions();
            controls.Player.SetCallbacks(this);
        }
        controls.Player.Enable();

        rbody = GetComponent<Rigidbody>();
        //rbody.freezeRotation = true;

        currentGun = gr.RequestGun();
        nextGun = gr.RequestGun();
    }

    // Update is called once per frame
    void Update()
    {
        //rbody.linearVelocity = moveInput;

        //charController.Move(movement);
        Debug.Log(moveInput);
        movement = transform.forward * moveInput.y + transform.right * moveInput.x;

        rbody.AddForce(movement.normalized * 1, ForceMode.Force);
    }

    public void OnEnable()
    {
        controls.Player.Enable();
    }
    public void OnDisable()
    {
        controls.Player.Disable();
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        //throw new System.NotImplementedException();
    }

    public void OnCrouch(InputAction.CallbackContext context)
    {
        //throw new System.NotImplementedException();
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        //throw new System.NotImplementedException();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        //throw new System.NotImplementedException();
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        //throw new System.NotImplementedException();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        Debug.Log(context.valueType);
        moveInput = context.ReadValue<Vector2>();
    }

    public void OnNext(InputAction.CallbackContext context)
    {
        //throw new System.NotImplementedException();
    }

    public void OnPrevious(InputAction.CallbackContext context)
    {
        //throw new System.NotImplementedException();
    }

    public void OnSprint(InputAction.CallbackContext context)
    {
        //throw new System.NotImplementedException();
    }

    private void NewGun()
    {
        currentGun = nextGun;
        nextGun = gr.RequestGun();
    }
}
