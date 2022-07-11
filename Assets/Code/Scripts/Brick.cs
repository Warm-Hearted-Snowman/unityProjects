using UnityEngine;

public class Brick : MonoBehaviour
{
    public SpriteRenderer spriteRenderer { get; private set; }
    public Sprite[] states = new Sprite[0];
    public int health { get; private set; }
    public bool unbreakable;

    private void Awake()
    {
        this.spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // private void OnCollisionEnter2D(Collision2D collision)
    // {
    //     if (collision.gameObject.name == "Ball")
    //     {
    //         Hit();
    //     }
    // }

    // private void Hit()
    // {
    //     if (this.unbreakable)
    //     {
    //         return;
    //     }
    //     this.health--;
    //     if (this.health <= 0)
    //     {
    //         Destroy(col.gameObject, 0.1f);
    //     }
    //     else
    //     {
    //         this.spriteRenderer.sprite = this.states[this.health - 1];
    //     }
    //     FindObjectOfType<GameManager>().Hit(this);
    // }

    private void Start()
    {
        ResetBrick();
    }

    public void ResetBrick()
    {
        gameObject.SetActive(true);

        if (!unbreakable)
        {
            health = states.Length;
            spriteRenderer.sprite = states[health - 1];
        }
    }
}
