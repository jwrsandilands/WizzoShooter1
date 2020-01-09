using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SchutBullat : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public GameObject swordPrefab;
    public float fireTime = 0.5f;
    public float swingTime = 0.1f;

    private bool isFiring = false;
    private bool isSwinging = false;

    public bool up;
    public bool left;
    public bool down;
    public bool right;

    Rigidbody2D rb2D;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();

        left = false;
        down = true;
        right = false;
        up = false;
    }

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            left = false;
            down = false;
            right = false;
            up = true;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            left = true;
            down = false;
            right = false;
            up = false;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            left = false;
            down = true;
            right = false;
            up = false;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            left = false;
            down = false;
            right = true;
            up = false;
        }
    }

    private void SetFiring()
    {
        isFiring = false;
        isSwinging = false;
    }

    private void SetSwinging()
    {
        isFiring = false;
        isSwinging = false;
    }

    private void Fire()
    {

        isFiring = true;
        if (up == true)
        {
            Instantiate(bulletPrefab, bulletSpawn.position, Quaternion.AngleAxis(0, Vector3.forward));
        }
        if (left == true)
        {
            Instantiate(bulletPrefab, bulletSpawn.position, Quaternion.AngleAxis(90, Vector3.forward));
        }
        if (right == true)
        {
            Instantiate(bulletPrefab, bulletSpawn.position, Quaternion.AngleAxis(270, Vector3.forward));
        }
        if (down == true)
        {
            Instantiate(bulletPrefab, bulletSpawn.position, Quaternion.AngleAxis(180, Vector3.forward));
        }

        if (GetComponent<AudioSource>() != null)
        {
            GetComponent<AudioSource>().Play();
        }

        Invoke("SetFiring", fireTime);
    }

    private void Swing()
    {
        StopPlayer();

        isFiring = true;
        if (up == true)
        {
            Instantiate(swordPrefab, bulletSpawn.position, Quaternion.AngleAxis(0, Vector3.forward));
        }
        if (left == true)
        {
            Instantiate(swordPrefab, bulletSpawn.position, Quaternion.AngleAxis(90, Vector3.forward));
        }
        if (right == true)
        {
            Instantiate(swordPrefab, bulletSpawn.position, Quaternion.AngleAxis(270, Vector3.forward));
        }
        if (down == true)
        {
            Instantiate(swordPrefab, bulletSpawn.position, Quaternion.AngleAxis(180, Vector3.forward));
        }

        if (GetComponent<AudioSource>() != null)
        {
            GetComponent<AudioSource>().Play();
        }

        Invoke("SetSwinging", swingTime);
    }

    private void StopPlayer()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        rb2D.velocity = new Vector2(x, y) * 0;
    }

    private void Update()
    {
        if(Input.GetKeyDown("space"))
        {
            if(!isFiring)
            {
                Fire();
            }
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            if (!isSwinging)
            {
                Swing();
            }
        }
    }
}
