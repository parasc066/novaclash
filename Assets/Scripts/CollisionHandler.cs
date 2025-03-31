using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] GameObject playerDestroyedVFX;
    GameSceneManager gameSceneManager;

    private void Start()
    {
        gameSceneManager = FindFirstObjectByType<GameSceneManager>();
    }


    void OnTriggerEnter(Collider other)
    {
        // Debug.Log("Player hit " + other.gameObject.name);
        // Debug.Log($"Hit {other.gameObject.name}");
        Instantiate(playerDestroyedVFX, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
        gameSceneManager.ReloadLevel();
    }
}
