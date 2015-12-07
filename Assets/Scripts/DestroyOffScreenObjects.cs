using UnityEngine;
using System.Collections;

public class DestroyOffScreenObjects : MonoBehaviour
{



    // Destroys Projectiles when they pass through the Barrier off-screen
    void OnTriggerExit(Collider other)
    {
        Destroy(other.gameObject);
    }
}
