using System.Collections.Generic;
using UnityEngine;

public class BulletPoolManager : MonoBehaviour
{
    public GameObject bulletPrefab;
    public int poolSize = 10;

    private List<GameObject> bulletPool;

    void Start()
    {
        InitializePool();
    }

    void InitializePool()
    {
        bulletPool = new List<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab, transform);
            bullet.SetActive(false);
            bulletPool.Add(bullet);
        }
    }

    public GameObject GetBulletFromPool(Vector3 position, Quaternion rotation)
    {
        foreach (GameObject bullet in bulletPool)
        {
            if (!bullet.activeInHierarchy)
            {
                bullet.transform.position = position;
                bullet.transform.rotation = rotation;
                bullet.SetActive(true);
                return bullet;
            }
        }

        // If all bullets are active, create a new one (expand the pool if needed)
        GameObject newBullet = Instantiate(bulletPrefab, position, rotation, transform);
        newBullet.SetActive(true);
        bulletPool.Add(newBullet);

        return newBullet;
    }

    // You can add a method to return a bullet to the pool if needed
    public void ReturnBulletToPool(GameObject bullet)
    {
        bullet.SetActive(false);
    }
}
