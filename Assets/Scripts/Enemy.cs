using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject enemyDestroyedVFX;
    [SerializeField] int hitPoints = 2;
    [SerializeField] int scoreValue = 10;
    Scoreboard scoreboard;

    void Start()
    {
        scoreboard = FindFirstObjectByType<Scoreboard>();
    }


    void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    private void ProcessHit()
    {
        hitPoints--;//hitPoints = hitPoints - 1
        if (hitPoints <= 0)
        {
            scoreboard.IncreaseScore(scoreValue);
            Debug.Log($"Added  {scoreValue} to the score");
            Instantiate(enemyDestroyedVFX, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}

