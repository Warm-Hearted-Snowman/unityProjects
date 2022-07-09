using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Paddle : MonoBehaviour
{
    public Rigidbody rigidBody{ get; private set; }
    public Vector2 direction { get; private set; }
    public float speed = 30f;
    
    private void Awake()
    {
        this.rigidBody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            this.direction = new Vector2(-1, 0);
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            this.direction = new Vector2(1, 0);
        }
        else
        {
            this.direction = Vector2.zero;
        }
    }

    private void FixedUpdate()
    {
        this.rigidBody.AddForce(this.direction * this.speed);
    }

    private void Start()
    {
        this.rigidBody.velocity = new Vector3(-3,-2,-25);
    }
}
