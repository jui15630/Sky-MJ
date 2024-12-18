using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static WeaponsManager;

public class Shell : MonoBehaviour
{
    [SerializeField] private WeaponBaseStatus weaponBaseStatus;
    [SerializeField] private WeaponsManager.WeaponID weaponID;

    public GameObject bullet;
    public float bulletSpeed;
    public Text shellLabel;
    public Text magazineLabel;

    private int currentBullets;
    private int magazineCount;
    private bool isReloading = false;

    // Start is called before the first frame update
    void Start()
    {
        currentBullets = weaponBaseStatus.GetNumberBullet(weaponID);
        magazineCount = weaponBaseStatus.GetCurrentMagazine(weaponID);
        UpdateUI();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isReloading && currentBullets > 0)
        {
            Shoot();
        }
        if (Input.GetKeyDown(KeyCode.R) && magazineCount > 0 && currentBullets < weaponBaseStatus.GetMaxBullet(weaponID))
        {
            Reload();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            PickupMagazine();
        }
    }

    void Shoot()
    {
        // 弾丸生成と発射
        GameObject bulletObj = Instantiate(bullet, transform.position, Quaternion.Euler(transform.parent.eulerAngles.x, transform.parent.eulerAngles.y, 0));
        Rigidbody bulletRb = bulletObj.GetComponent<Rigidbody>();
        bulletRb.AddForce(transform.forward * bulletSpeed);
        Destroy(bulletObj, 0.5f);

        currentBullets--;
        UpdateUI();
    }

    void Reload()
    {
        isReloading = true;

        int maxBullets = weaponBaseStatus.GetMaxBullet(weaponID);
        int magazineCapacity = weaponBaseStatus.GetMagazineCapacity(weaponID);

        int bulletsToReload = Mathf.Min(magazineCapacity, maxBullets - currentBullets);

        currentBullets += bulletsToReload;
        magazineCount--;
        isReloading = false;

        UpdateUI();
    }

    void PickupMagazine()
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 2f))
        {
            if (hit.collider.CompareTag("Magazine") && magazineCount < weaponBaseStatus.GetMaxMagazine(weaponID))
            {
                magazineCount++;
                Destroy(hit.collider.gameObject); // マガジンオブジェクトを破壊
                UpdateUI();
            }
        }
    }

    // UI更新メソッド
    private void UpdateUI()
    {
        shellLabel.text = "残弾数: " + currentBullets;
        magazineLabel.text = "マガジン: " + magazineCount + " / " + weaponBaseStatus.GetMaxMagazine(weaponID);
    }
}
