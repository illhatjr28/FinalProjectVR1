using UnityEngine;

public class WalkwayTeleport : MonoBehaviour
{
    [Header("Destination")]
    [Tooltip("Drag an empty GameObject here to mark where the player should land")]
    public Transform landingPad;

    private void OnTriggerEnter(Collider other)
    {
        // Find the root of the VR Rig (the XR Origin)
        if (other.CompareTag("Player"))
        {
            Transform vrRig = other.transform.root;

            // Move the rig to the landing pad's position and rotation
            vrRig.position = landingPad.position;
            vrRig.rotation = landingPad.rotation;

            Debug.Log("Teleported to Stadium!");
        }
    }
}