using UnityEngine;

public class PlayerShooterController : MonoBehaviour
{
    [SerializeField] private float fireCooldown = 0.5f;
    [SerializeField] private float fireRange = 10f;
    [SerializeField] private GameObject bulletPrefab;

    private float fireTimer;

    private void Update()
    {
        fireTimer += Time.deltaTime;

        if (fireTimer >= fireCooldown)
        {
            Shoot();
            fireTimer = 0f;
        }
    }

    private void Shoot()
    {
        GameObject target = FindNearestEnemy();
        if (target == null) return;

        Vector2 direction = (target.transform.position - transform.position).normalized;

        Vector2 spawnPos = (Vector2)transform.position + direction * 0.3f;
        GameObject bullet = Instantiate(bulletPrefab, spawnPos, Quaternion.identity);

        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = direction * bullet.GetComponent<Bullet>().Speed;
    }

    private GameObject FindNearestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        float minDistance = fireRange;
        GameObject nearest = null;

        foreach (GameObject enemy in enemies)
        {
            float distance = Vector2.Distance(transform.position, enemy.transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                nearest = enemy;
            }
        }

        return nearest;
    }
}
