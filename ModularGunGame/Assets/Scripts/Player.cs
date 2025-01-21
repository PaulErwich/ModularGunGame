using UnityEngine;
using UnityEngine.InputSystem;
using static InputSystem_Actions;

public class Player : MonoBehaviour, IPlayerActions
{
    private gun currentGun;
    private gun nextGun;

    InputSystem_Actions controls;
    public float speed = 10f;
    private Rigidbody rbody;
    private Vector2 moveInput;
    private Vector3 movement;

    [Header("Camera rotation")]
    private Vector2 mouseMovement;
    private float xRotation;
    private float yRotation;
    private float mouseSens = 15.0f;

    public Transform orientation;
    public GameObject cam;
    public GameObject bullet;

    public float groundDrag;

    [Header("Shooting")]
    public float shotCooldown = 0.2f;
    bool readyToShoot = true;

    [Header("Jumping")]
    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    bool readyToJump = true;

    [Header("Ground check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    public bool grounded = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        if (controls == null)
        {
            controls = new InputSystem_Actions();
            controls.Player.SetCallbacks(this);
        }
        controls.Player.Enable();

        rbody = GetComponent<Rigidbody>();
        rbody.freezeRotation = true;
    }

    void Start()
    {
        currentGun = GunRandomiser.instance.RequestGun();
        nextGun = GunRandomiser.instance.RequestGun();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //rbody.linearVelocity = moveInput;

        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.1f, whatIsGround);
        Debug.DrawLine(transform.position, new Vector3(transform.position.x, transform.position.y - (playerHeight * 0.5f + 0.1f), transform.position.z));

        if (grounded)
            rbody.linearDamping = groundDrag;
        else
            rbody.linearDamping = 0f;

        MovePlayer();
        SpeedControl();
    }

    private void MovePlayer()
    {
        movement = orientation.forward * moveInput.y + orientation.right * moveInput.x;

        if (grounded)
            rbody.AddForce(movement.normalized * speed, ForceMode.Force);
        else
            rbody.AddForce(movement.normalized * speed * airMultiplier, ForceMode.Force);
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rbody.linearVelocity.x, 0f, rbody.linearVelocity.z);

        // limit velocity if necessary
        if (flatVel.magnitude > speed)
        {
            Vector3 limitedVel = flatVel.normalized * speed;
            rbody.linearVelocity = new Vector3(limitedVel.x, rbody.linearVelocity.y, limitedVel.z);
        }
    }

    public void ResetJump()
    {
        readyToJump = true;
    }

    public void ResetShot()
    {
        readyToShoot = true;
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
        if (readyToShoot)
        {
            readyToShoot = false;

            GameObject newBullet = Instantiate(bullet, transform.position + orientation.forward * 0.3f, cam.transform.rotation);
            newBullet.GetComponent<Bullet>().SetupBullet(cam.transform.forward);

            Invoke(nameof(ResetShot), shotCooldown);
        }

    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (readyToJump && grounded)
        {
            Debug.Log("JUMP!");
            readyToJump = false;

            rbody.linearVelocity = new Vector3(rbody.linearVelocity.x, 0f, rbody.linearVelocity.z);
            rbody.AddForce(transform.up * jumpForce, ForceMode.Impulse);

            Invoke(nameof(ResetJump), jumpCooldown);
        }
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        mouseMovement = context.ReadValue<Vector2>();

        yRotation += mouseMovement.x * Time.deltaTime * mouseSens;
        xRotation -= mouseMovement.y * Time.deltaTime * mouseSens;

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        cam.transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
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
    public void OnCrouch(InputAction.CallbackContext context)
    {
        //throw new System.NotImplementedException();
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        //throw new System.NotImplementedException();
    }
    private void NewGun()
    {
        currentGun = nextGun;
        nextGun = GunRandomiser.instance.RequestGun();
    }
}
