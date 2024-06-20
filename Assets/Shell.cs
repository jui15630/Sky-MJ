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

    public int Numberbullet = 10;
    // Start is called before the first frame update
    void Start()
    {
        shellLabel.text = "ñCíeÅF" + Numberbullet;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Rug == false && Numberbullet > 0)
        {
            GameObject Bullet = (GameObject)Instantiate(bullet, transform.position, Quaternion.Euler(transform.parent.eulerAngles.x, transform.parent.eulerAngles.y, 0));
            Rigidbody bulletRb = Bullet.GetComponent<Rigidbody>();
            bulletRb.AddForce(transform.forward * bulletSpeed);
            Destroy(Bullet, 1.5f);

            Rug = true;
            Invoke("ROG", 0.5f);
            Numberbullet -= 1;
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            Numberbullet = 10;
        }
        shellLabel.text = "ñCíeÅF" + Numberbullet;

    }
    void ROG()
    {
        Rug = false;
    }
}
