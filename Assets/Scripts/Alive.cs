using UnityEngine;
using System.Collections;
abstract public class Alive : MonoBehaviour
{
    [SerializeField] float Health = 100;
    [SerializeField] float IFrameTime = 1;
    bool IFrame = false;

    IEnumerator TakeDamageEffect()
    {
        SpriteRenderer Sprite = GetComponent<SpriteRenderer>();
        Sprite.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        Sprite.color = Color.white;
        yield return null;
    }

    IEnumerator IFrameTask()
    {
        IFrame = true;
        yield return new WaitForSeconds(0.1f);
        IFrame = false;
        yield return null;
    }

    public virtual void TakeDamage(float Damage)
    {
        if (IFrame) { return; }
        StartCoroutine(TakeDamageEffect());
        StartCoroutine(IFrameTask());
        TakeDamageEffect();
        Health -= Damage;
        if (Health <= 0) { OnDied(); }
    }

    public abstract void OnDied();
}
