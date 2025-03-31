using UnityEngine;

public class Rotation : MonoBehaviour
{
    [SerializeField] private GameObject[] mainRotor;    // Main propeller on top
    [SerializeField] private float mainRotorSpeed = 800f;  // Speed for main rotor
    [SerializeField] private Vector3 rotationAxis = Vector3.forward;

    // Update is called once per frame
    void Update()
    {
        RotationProcess();
    }

    void RotationProcess()
    {
        // Rotate main rotor
        foreach (GameObject rotor in mainRotor)
        {
            rotor.transform.Rotate(rotationAxis * mainRotorSpeed * Time.deltaTime, Space.Self);
            // Space.Self means the rotation will happen relative to the object's own local coordinate system rather than the world coordinate system. This is useful when you want the object to rotate around its own axis regardless of its current orientation in the world
        }
    }
}
