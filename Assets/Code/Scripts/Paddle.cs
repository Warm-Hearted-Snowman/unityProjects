using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Paddle : MonoBehaviour
{
    public Rigidbody rigidBody{ get; private set; }
    public Vector3 direction { get; private set; }
    public float speed = 30f;
    
    private void Awake()
    {
        this.rigidBody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            this.direction = new Vector3(0,0,-1);
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            this.direction = new Vector3(0,0,1);
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
}
