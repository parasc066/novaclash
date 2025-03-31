using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] GameObject[] Lasers;
    [SerializeField] RectTransform crosshair;
    [SerializeField] Transform targetPoint;
    [SerializeField] float targetDistance = 100f;

    bool isFiring = false;

    private void Start()
    {
        Cursor.visible = false;
    }

    private void Update()
    {
        ProcessFiring();
        MoveCrosshair();
        MoveTargetPoint();
        AimLasers();
    }

    public void OnFire(InputValue value)
    {
        isFiring = value.isPressed;
    }

    void ProcessFiring()
    {
        foreach (GameObject Laser in Lasers)
        {
            var emissionModule = Laser.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = isFiring;
        }
    }

    void MoveCrosshair()
    {
        crosshair.position = Input.mousePosition;
        //moving crosshair to the cursor position
    }

    void MoveTargetPoint()
    {
        Vector3 targetPointPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, targetDistance);
        targetPoint.position = Camera.main.ScreenToWorldPoint(targetPointPosition);
        //this method updates the position of the targetPoint(red ball) to the world position corresponding to the mouse cursor's screen position.
    }

    void AimLasers()
    {
        foreach (GameObject Laser in Lasers)
        {
            Vector3 fireDirection = targetPoint.position - this.transform.position;// crosshair position - ship position
            Quaternion lookRotation = Quaternion.LookRotation(fireDirection);
            Laser.transform.rotation = lookRotation;//apply rotation of laser to look at the cursor
        }
        //method rotates each laser to point towards the targetPoint position, aligning them with the cursor's position in the game world.
    }
}
