using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] int speed;
    [SerializeField] int forceJump;
    int monedas = 0;
    int ammo = 10;
    float tiempo = 0;

    bool canJump;

    [SerializeField] GameObject bullet2;
    [SerializeField] GameObject disparo;

    [SerializeField] TextMeshProUGUI textoMonedas;

    [SerializeField] TextMeshProUGUI textoBalas;

    Rigidbody rigid;

    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        textoBalas.text = ammo.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontales = Input.GetAxisRaw("Horizontal");

        tiempo += Time.deltaTime;

        textoBalas.text = tiempo.ToString("F0");

        if (tiempo > 10)
        {
            SceneManager.LoadScene("Win");
        }

        float vertical = Input.GetAxisRaw("Vertical");

        transform.Rotate(0, horizontales, 0);

        transform.Translate(transform.forward * vertical * Time.deltaTime * speed, Space.World); 

        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (canJump)
            {
                canJump = false;
                rigid.AddForce(Vector3.up * forceJump, ForceMode.Impulse);
            }
            
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            ammo = 10;
            textoBalas.text = ammo.ToString();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (ammo > 0)
            {
                Instantiate(bullet2, disparo.transform.position, disparo.transform.rotation);
                ammo = ammo - 1;
                textoBalas.text = ammo.ToString();
            }
            
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Floor"))
        {
            canJump = true;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("PowerUp"))
        {
            speed = 15;
            Invoke("ResetSpeed", 10);
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Coin"))
        {
            monedas++;
            textoMonedas.text = monedas.ToString();

            Destroy(other.gameObject);
            if (monedas == 3)
            {
                SceneManager.LoadScene("Win");
            }
        }

        if (other.gameObject.CompareTag("RecargaBalas"))
        {
            ammo = ammo + 10;
            textoBalas.text = ammo.ToString();

            Destroy(other.gameObject);
        }
    }


    private void ResetSpeed()
    {
        speed = 5;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                //acciones
            }
        }
    }

}
