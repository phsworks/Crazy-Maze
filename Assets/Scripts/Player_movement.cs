using Unity.VisualScripting;
using UnityEditor.Callbacks;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class Player_movement : MonoBehaviour
{
    public float MoveSpeed = 10f;
    public float ExtraSpeed;
    public float RotationSpeed = 75f;

    private float HorizontalInput;
    private float VerticalInput;
    private bool _isRunning;

    public GameObject Bullet;
    public float BulletSpeed = 10f;
    private bool _isShooting;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        HorizontalInput = Input.GetAxisRaw("Horizontal") * RotationSpeed;
        VerticalInput = Input.GetAxisRaw("Vertical") * MoveSpeed;

        this.transform.Translate(Vector3.forward * VerticalInput * Time.deltaTime * ExtraSpeed);
        this.transform.Rotate(Vector3.up * HorizontalInput * Time.deltaTime);

        _isRunning = Input.GetKey(KeyCode.J);


        _isShooting |= Input.GetKeyDown("Space");

    }

    void FixedUpdate()
    {
        ExtraSpeed = _isRunning ? 1.5f : 1;

    }






}
