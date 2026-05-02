using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    [SerializeField] float Damage = 25;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Monster mon = collision.gameObject.GetComponent<Monster>();
        if (mon != null)
        {
            mon.TakeDamage(Damage);
        }
    }
}
