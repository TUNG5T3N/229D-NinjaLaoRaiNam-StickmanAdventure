using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class FIdget_Shooter : MonoBehaviour
{
    [SerializeField] GameObject FidgetPrefab;
    [SerializeField] float Speed = 10;
    [SerializeField] float Torque = 180;

    Boolean isShootable = true;
    GameObject CurrentProjectile;

    // Update is called once per frame
    void DelayCD() { isShootable = true; }
    void Update()
    {
        if (Keyboard.current.fKey.isPressed && isShootable)
        {
            isShootable = false;
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 Dir = (mousePos - transform.position).normalized;
            CurrentProjectile = Instantiate(FidgetPrefab, transform.position, Quaternion.identity);
            Rigidbody2D rigidbody2D = CurrentProjectile.GetComponent<Rigidbody2D>();
            rigidbody2D.linearVelocity = Dir * rigidbody2D.mass * Speed;
            rigidbody2D.angularVelocity = Torque;
            //Invoke(nameof(DelayCD), 1f);
        }
    }

    void FixedUpdate()
    {
        if (CurrentProjectile != null)
        {

        }
    }
}
