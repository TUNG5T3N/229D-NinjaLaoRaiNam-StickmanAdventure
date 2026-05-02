
using UnityEngine;

public class Monster : Alive
{
    [SerializeField] float WalkTime = 5;
    [SerializeField] float Speed = 5;
    [SerializeField] float Damage = 50;

    Rigidbody2D rigidbody2D;
    float RoamTime = 10;
    bool TakeDamageDB = false;

    void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        RoamTime = Time.time;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Time.time - RoamTime <= WalkTime)
        {
            SpriteRenderer sprite = GetComponent<SpriteRenderer>();
            bool isFlip = sprite.flipX;
            int MoveValue = isFlip ? 1 : -1;
            float Force = Speed * rigidbody2D.mass * MoveValue;
            rigidbody2D.linearVelocity = new Vector2(Force, 0);
        }
        else
        {
            SpriteRenderer sprite = GetComponent<SpriteRenderer>();
            bool isFlip = sprite.flipX;
            sprite.flipX = !isFlip;
            RoamTime = Time.time;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Player2DController PlayerScript = collision.gameObject.GetComponent<Player2DController>();
        if (PlayerScript != null)
        {
            PlayerScript.TakeDamage(Damage);
        }
    }
    public override void OnDied()
    {
        GameObject.FindAnyObjectByType<StarSystem>().EnemyDiedAssign();
        Destroy(this.gameObject);
    }
}
