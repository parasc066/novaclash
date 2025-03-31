using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMovement : MonoBehaviour
{
    //Movement Variables
    [SerializeField] float controlSpeed = 5f;//speed of the ship
    [SerializeField] float xClampRange = 5f;//range of movement in x-axis
    [SerializeField] float yClampRange = 5f;//range of movement in y-axis

    //Rotation Variables
    [SerializeField] float controlPitchFactor = 18f;
    [SerializeField] float controlFactor = 20f;
    [SerializeField] float rotationSpeed = 5f;


    Vector2 movement;

    void Update()
    {
        processTranslation();
        processRotation();
    }

    void processTranslation()
    {
        float xOffSet = movement.x * controlSpeed * Time.deltaTime;
        float yOffSet = movement.y * controlSpeed * Time.deltaTime;

        float rawXPos = transform.localPosition.x + xOffSet;
        float clampedXPos = Mathf.Clamp(rawXPos, -xClampRange, xClampRange);

        float rawYPos = transform.localPosition.y + yOffSet;
        float clampedYPos = Mathf.Clamp(rawYPos, -yClampRange, yClampRange);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, 0f);
    }

    void processRotation()
    {
        float roll = -controlFactor * movement.x;
        float pitch = -controlPitchFactor * movement.y;

        Quaternion targetRotation = Quaternion.Euler(pitch, 0f, roll);
        transform.localRotation = Quaternion.Lerp(transform.localRotation, targetRotation, rotationSpeed * Time.deltaTime);
    }



    public void OnMove(InputValue value)
    {
        movement = value.Get<Vector2>();
    }
}

