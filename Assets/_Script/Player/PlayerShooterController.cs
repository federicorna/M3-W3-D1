
using UnityEngine;

public class PlayerShooterController : MonoBehaviour
{
    [SerializeField] private float _fireRate;
    [SerializeField] private float _fireRange;

    private GameObject _bulletPrefab;

    public GameObject FindNearestEnemy (GameObject bullet)
    {
        
        return bullet;
    }

}
