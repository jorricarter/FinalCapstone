using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolingManager : MonoBehaviour {

    private static PoolingManager instance;
    public static PoolingManager Instance { get { return instance; } }


    public GameObject bulletPrefab;
    public int bulletAmount = 100;
    private List<GameObject> bullets;


    // 'Awake' method is called before 'Start' method.
    void Awake () {
        instance = this;
        //preload bullets to pool.
        bullets = new List<GameObject>(bulletAmount);
        for (int i = 0; i<bulletAmount; i++) {
            GameObject prefabInstance = Instantiate(bulletPrefab);
            prefabInstance.transform.SetParent(transform);
            prefabInstance.SetActive(false);
            bullets.Add(prefabInstance);
        }
	}
	
	public GameObject GetBullet () {
        //find bullet not being actively used in game.
        foreach (GameObject bullet in bullets) {
            if (!bullet.activeInHierarchy) {
                bullet.SetActive(true);
                return bullet;
            }
        }
        //if all bulltes from pool are being used, create a new one.
        GameObject prefabInstance = Instantiate(bulletPrefab);
        prefabInstance.transform.SetParent(transform);
        bullets.Add(prefabInstance);

        return prefabInstance;
    }
}
