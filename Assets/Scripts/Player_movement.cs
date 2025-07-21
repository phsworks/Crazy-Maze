using Unity.VisualScripting;
using UnityEditor.Callbacks;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class Player_movement : MonoBehaviour
{
    public float MoveSpeed = 10f;
    public float RotationSpeed = 75f;

    private float HorizontalInput;
    private float VerticalInput;

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

        this.transform.Translate(Vector3.forward * VerticalInput * Time.deltaTime);
        this.transform.Rotate(Vector3.up * HorizontalInput * Time.deltaTime);



        _isShooting |= Input.GetKeyDown(KeyCode.Space);

    }

    void FixedUpdate()
    {
        if (_isShooting)
        {
            GameObject newBullet = Instantiate(Bullet, this.transform.position + new Vector3(0, 0, 1.5f), this.transform.rotation);

            Rigidbody BulletRB = newBullet.GetComponent<Rigidbody>();

            BulletRB.linearVelocity = this.transform.forward * BulletSpeed;
        }

        _isShooting = false;

    }


   










}
