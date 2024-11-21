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

    public int Numberbullet = 10; // ‰Šú’e”‚Í10
    public int maxBullets = 10; // Å‘åŠŽ’e”
    public int magazineCapacity = 10; // ƒ}ƒKƒWƒ“1‚Â‚Å•â[‚³‚ê‚é’e”
    public int maxMagazines = 3; // ŠŽ‚Å‚«‚éƒ}ƒKƒWƒ“‚ÌÅ‘å”
    private int magazineCount = 0; // Œ»Ý‚Ìƒ}ƒKƒWƒ“”

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
                Destroy(hit.collider.gameObject); // ƒ}ƒKƒWƒ“ƒIƒuƒWƒFƒNƒg‚ð”j‰ó
                UpdateUI();
            }
        }
    }

    void ROG()
    {
        Rug = false;
    }

    // UIXVƒƒ\ƒbƒh
    private void UpdateUI()
    {
        shellLabel.text = "Žc’e”: " + Numberbullet;
        magazineLabel.text = "ƒ}ƒKƒWƒ“: " + magazineCount + " / " + maxMagazines;
    }
}
