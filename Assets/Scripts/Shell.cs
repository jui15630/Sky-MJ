using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shell : MonoBehaviour
{
    public GameObject bullet;
    public float bulletSpeed;
    bool Rug = false;
    public Text shellLabel;
    public Text magazineLabel;

    public int Numberbullet = 10; // 初期弾数は10
    public int maxBullets = 10; // 最大所持弾数
    public int magazineCapacity = 10; // マガジン1つで補充される弾数
    public int maxMagazines = 3; // 所持できるマガジンの最大数
    private int magazineCount = 0; // 現在のマガジン数

    // Start is called before the first frame update
    void Start()
    {
        UpdateUI();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Rug == false && Numberbullet > 0)
        {
            Shoot();
        }
        if (Input.GetKeyDown(KeyCode.R) && magazineCount > 0 && Numberbullet < maxBullets)
        {
            Reload();
        }
        if (Input.GetKeyDown(KeyCode.E) && magazineCount < maxMagazines)
        {
            PickupMagazine();
        }
    }

    void Shoot()
    {
        GameObject Bullet = Instantiate(bullet, transform.position, Quaternion.Euler(transform.parent.eulerAngles.x, transform.parent.eulerAngles.y, 0));
        Rigidbody bulletRb = Bullet.GetComponent<Rigidbody>();
        bulletRb.AddForce(transform.forward * bulletSpeed);
        Destroy(Bullet, 0.5f);

        Rug = true;
        Invoke("ROG", 0.5f);
        Numberbullet--;
        UpdateUI();
    }

    void Reload()
    {
        int bulletsToReload = Mathf.Min(magazineCapacity, maxBullets - Numberbullet);
        Numberbullet += bulletsToReload;
        magazineCount--;
        UpdateUI();
    }

    void PickupMagazine()
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 2f))
        {
            if (hit.collider.CompareTag("Magazine") && magazineCount < maxMagazines)
            {
                magazineCount++;
                Destroy(hit.collider.gameObject); // マガジンオブジェクトを破壊
                UpdateUI();
            }
        }
    }

    void ROG()
    {
        Rug = false;
    }

    // UI更新メソッド
    private void UpdateUI()
    {
        shellLabel.text = "残弾数: " + Numberbullet;
        magazineLabel.text = "マガジン: " + magazineCount + " / " + maxMagazines;
    }
}
