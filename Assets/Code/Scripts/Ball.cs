using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Ball : MonoBehaviour
{
    public Rigidbody rigidBody { get; private set; }
    public float speed = 100f;
    public float maxBounceAngle = 35f;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        ResetBall();
    }

    public void ResetBall()
    {
        transform.position = new Vector3(1,-18,0);

        Invoke(nameof(SetRandomTrajectory), 1f);
    }

    private void SetRandomTrajectory()
    {
        Vector2 force = new Vector2();
        force.x = Random.Range(-30f, 30f);
        force.y = -30f;

        rigidBody.AddForce(force.normalized * speed);
    }

    private void FixedUpdate()
    {
        rigidBody.velocity = rigidBody.velocity.normalized * speed;
    }

    private void onCollisionEnter(Collision2D collision)
    {
        Ball ball = collision.gameObject.GetComponent<Ball>();
        if (ball != null)
        {
            Vector3 paddlePosition = this.transform.position;
            Vector3 contactPoint = collision.GetContact(0).point;

            float offset = paddlePosition.x - contactPoint.x;
            float witdh = collision.otherCollider.bounds.size.x / 2;
            float currentAngle = Vector2.Angle(Vector2.up, ball.rigidBody.velocity);
            float bounceAngle = (offset / witdh) * this.maxBounceAngle;
            float newAngle = Mathf.Clamp(
                currentAngle + bounceAngle,
                -this.maxBounceAngle,
                this.maxBounceAngle
            );

            Quaternion rotation = Quaternion.AngleAxis(newAngle, Vector3.forward);
            ball.rigidBody.velocity = rotation * Vector2.up * ball.rigidBody.velocity.magnitude;
        }
    }
}
