using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : MonoBehaviour {

    public static float PlayerFireRate = .40f;
    public static int PlayerDamage = 100;
    public static bool PlayerGunAutomatic;

    
    //serialize, makes this editable when I test the level-Scene in unity.
    [SerializeField]
    //this is a point I created on the character where bullet logic and raycasts begin.
    private Transform firePoint;
    //when audio is serialized, I drag the particles and audio files to the gui and it remembers the reference.
    [SerializeField] private ParticleSystem gunFlash;
    [SerializeField] private AudioSource gunSound;
    [SerializeField] private Animation crosshairShoot;
    [SerializeField] private float BulletVelocity = 3f;
//    [SerializeField] private float BulletLifetime = 5f;
    [SerializeField] private float BulletInitialize = 5f;
    [SerializeField] private GameObject bulletHole;


    private Camera playerCamera;
    private float timer;


    private void Awake() {
        playerCamera = Camera.main;
        crosshairShoot = GetComponentInChildren<Animation>();
    }

    // Update is called once per frame
    void Update () {
        timer += Time.deltaTime;
        //this checks if enough time has passed since our last shot.
        if (CanShoot()) {
            //if enough time has passed, see if user is trying to shoot again.
            if (PlayerGunAutomatic && Input.GetButton("Fire1"))
            {
                timer = 0f;
                FireGun();
            }
            else if (Input.GetButtonDown("Fire1"))
            {
                timer = 0f;
                FireGun();
            }
        }
	}

    private bool CanShoot() {
        return (timer >= PlayerFireRate &&
            PlayerAmmo.CurrentAmmo > 0);
    }

    private void FireGun() {

        gunSound.Play();
        gunFlash.Play();
        crosshairShoot.Play("CrosshairShoot");
//        GetComponent.<Animation>().Play("");
        //this defines a ray or line in a forward direction from the firePoint.
        Ray ray = new Ray(firePoint.position + firePoint.transform.forward, firePoint.forward);
        //if the ray hits something, hitInfo will contain data about the collision.
        RaycastHit hitInfo;

        //always make sure to use the correct overload. there are 16 and some parameter combinations can accept identical input like constructor 5 & 6 if float isn't explicit.
        if (Physics.Raycast(ray, out hitInfo, 100.0f)) {
            Debug.Log("BulletHoleCoordinates are: " + hitInfo.point);
            Debug.Log(hitInfo.collider.name + "," + hitInfo.collider.transform);
            //make bullethole animation.
//            Instantiate(bulletHole, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
            //get healthbar of what you hit
            var health = hitInfo.collider.GetComponent<Health>();
            //make sure it has a health so you don't try damage logic on a wall.
            if (health != null) {
                health.TakeDamage(PlayerDamage);
                if (health.currentHealth < 1) {
                    var death = hitInfo.collider.GetComponent<EnemyDeath>();
                    death.Die();
                }
            }
        }
        //get a physical bullet from the pool that is not in use
        GameObject currentBullet = PoolingManager.Instance.GetBullet();
        //put bullet in front of firepoint.
        currentBullet.transform.position = ((firePoint.transform.position + playerCamera.transform.position)/2) + (firePoint.transform.forward * BulletInitialize);
        //tell bullet to move forward
        Debug.Log("cameraforward is: " + playerCamera.transform.forward);
        currentBullet.transform.forward = (firePoint.transform.forward + playerCamera.transform.forward) * BulletVelocity;
//        currentBullet.GetComponent<Rigidbody>().velocity = playerCamera.transform.forward * BulletVelocity;
//        currentBullet.transform.forward = firePoint.transform.forward;
//        //destroy bullet after 'lifetime';
//        Disable(currentBullet, BulletLifetime);
        PlayerAmmo.CurrentAmmo -= 1;
    }
}
