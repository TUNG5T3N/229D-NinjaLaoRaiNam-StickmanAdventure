using UnityEngine;


public class SpikeScript : MonoBehaviour
{
    [SerializeField] float Damage = 10;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Player2DController player = collision.gameObject.GetComponent<Player2DController>();
        if (player != null)
        {
            player.TakeDamage(Damage);
        }
    }
}
