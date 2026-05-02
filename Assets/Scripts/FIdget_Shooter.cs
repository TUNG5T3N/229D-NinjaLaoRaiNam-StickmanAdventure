using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class FIdget_Shooter : MonoBehaviour
{
    [SerializeField] GameObject FidgetPrefab;
    [SerializeField] float Speed = 10;
    [SerializeField] float Torque = 180;
    [SerializeField] float MagnusStrength = 0.001f;
    [SerializeField] float BeforeMagnusDuration = 1f;
    [SerializeField] float MagnusDuration = 1f;

    Boolean isShootable = true;
    GameObject CurrentProjectile;

    // Update is called once per frame
    int phase = 0;
    void SetPhase(int newphase) { phase = newphase; }
    void Phase1() { SetPhase(1); }
    void Phase2() { 
        SetPhase(2);
        Rigidbody2D rigidbody2D = CurrentProjectile.GetComponent<Rigidbody2D>();
        rigidbody2D.linearVelocity *= 0.25f;
    }
    void Phase3() { SetPhase(3); }
    void Update()
    {
        if (Keyboard.current.fKey.isPressed && isShootable)
        {
            isShootable = false;
            phase = 0;
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 Dir = (mousePos - transform.position);
            CurrentProjectile = Instantiate(FidgetPrefab, transform.position, Quaternion.identity);
            Rigidbody2D rigidbody2D = CurrentProjectile.GetComponent<Rigidbody2D>();
            rigidbody2D.linearVelocity = Dir.normalized * rigidbody2D.mass * Speed;
            rigidbody2D.angularVelocity = Torque;
            Invoke(nameof(Phase1), BeforeMagnusDuration);
            Invoke(nameof(Phase2), MagnusDuration);
            Invoke(nameof(Phase3), 2);
        }
    }

    void FixedUpdate()
    {
        if (CurrentProjectile != null)
        {
            Rigidbody2D rigidbody2D = CurrentProjectile.GetComponent<Rigidbody2D>();
            Vector2 velo = rigidbody2D.linearVelocity;
            float angu = rigidbody2D.angularVelocity;
            if (phase == 1)
            {
                // Cross Product
                Vector3 magnusForce = Vector3.Cross(velo, new Vector3(0, 0, angu));
                Vector2 magnus = (Vector2)magnusForce * MagnusStrength;
                rigidbody2D.AddForce(magnus);
            }
            else if (phase == 2)
            {
                Vector2 playerPos = transform.position;
                Vector2 projectilePos = CurrentProjectile.transform.position;
                Vector2 DIr = playerPos - projectilePos;
                rigidbody2D.AddForce(DIr.normalized * rigidbody2D.mass * Speed * 2);
            }
            else if (phase == 3)
            {
                Vector2 playerPos = transform.position;
                Vector2 projectilePos = CurrentProjectile.transform.position;
                Vector2 DIr = playerPos - projectilePos;
                rigidbody2D.linearVelocity = DIr.normalized * rigidbody2D.mass * Speed * 2;
                if (DIr.magnitude <= 0.5)
                {
                    Destroy(CurrentProjectile);
                    CurrentProjectile = null;
                    phase = 0;
                    isShootable = true;
                }
            }
            

        }
    }
}
