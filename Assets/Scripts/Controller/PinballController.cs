using System.Collections;
using System.Collections.Generic;
using System.Xml;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PinballController : MonoBehaviour
{
    public TextMeshProUGUI Coin;
    public TextMeshProUGUI Score;
    public TextMeshProUGUI Combo;
    public TextMeshProUGUI Chance;

    public Rigidbody pinBallrb;
    public LineRenderer line;
    public ParticleSystem mine;
    
    public GameObject RockPS;
    public GameObject Panel;

    public float MaxSpeed = 700.0f;
    
    public Vector3 startPoint, targetPoint;
    Vector3 lastVelocity;

    public static int chance = 2;

    public static long score = 0;
    public static long coin = 0;
    public static long combo = 0;
    public static long coinGain = 0;

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        Coin.text = coin.ToString();
        Score.text = score.ToString();
        Combo.text = "Combo " + combo.ToString();
        Chance.text = "Chance " + chance.ToString();

        Combo.color = new Color(255/255f, (255 - (int)combo * 5)/255f, (255 - (int)combo * 5)/255f);

        Combo.fontSize = 150 + combo;
        if(Combo.fontSize < 210)
        {
            Combo.GetComponent<RectTransform>().sizeDelta = new Vector2(620 + combo * 2, 200);
        }
        else
        {
            Combo.GetComponent<RectTransform>().sizeDelta = new Vector2(620 + combo * 3, 200);
        }

        //�ִ�ӵ�
        if (pinBallrb.velocity.x > MaxSpeed)
        {
            pinBallrb.velocity = new Vector3(MaxSpeed, 0, pinBallrb.velocity.z);
        }
        else if(pinBallrb.velocity.x < -MaxSpeed)
        {
            pinBallrb.velocity = new Vector3(-MaxSpeed, 0, pinBallrb.velocity.z);
        }

        if (pinBallrb.velocity.z > MaxSpeed)
        {
            pinBallrb.velocity = new Vector3(pinBallrb.velocity.x, 0, MaxSpeed);
        }
        else if (pinBallrb.velocity.z < -MaxSpeed)
        {
            pinBallrb.velocity = new Vector3(pinBallrb.velocity.x, 0, -MaxSpeed);
        }

        //Ŭ��
        if (Physics.Raycast(ray, out hit))
        {
            if (chance > 0 && combo == 0 && hit.collider.name != "setArea" && Time.timeScale != 0.0f)
            {
                if (Input.GetMouseButton(0))
                {
                    line.gameObject.SetActive(true); //��Ŭ������ ���� ���� //��ҿ� ���� ��������

                    startPoint = new Vector3(transform.position.x, 0, transform.position.z);
                    targetPoint = new Vector3(hit.point.x, 0, hit.point.z);

                    //lineRenderer.SetPosition: ���η�����(lineRenderer)?������ġ��?�������ִ� �Լ���
                    //ù��° �Ű������� 1�̳� 0 ���� //�ι��� �Ű������� Vector3 �� ���µ� "��ġ"��
                    line.SetPosition(1, startPoint); //1 ������: ������ġ
                    line.SetPosition(0, targetPoint); //0 ������: ��ǥ��ġ

                }
                else if (Input.GetMouseButtonUp(0))
                {
                    pinBallrb.AddForce((startPoint - targetPoint) * 30f, ForceMode.Impulse);
                    line.gameObject.SetActive(false);
                    chance -= 1;
                    combo = 1;
                }
            }
            else if (chance <= 0 && combo == 0)
            {
                coinGain = score / 2500;
                coin += coinGain;
                Panel.GetComponent<ChangeScene>().GoEndScene();
            }
            else
            {
                if ((Mathf.Abs(pinBallrb.velocity.x) + Mathf.Abs(pinBallrb.velocity.z) < 2f))
                {
                    combo = 0;
                }
            }
        }

        if ((Mathf.Abs(pinBallrb.velocity.x) + Mathf.Abs(pinBallrb.velocity.z) < 2f))
        {
            pinBallrb.velocity = Vector3.zero;
            mine.Stop();
        }
        else
        {
            mine.Play();

            if(combo == 0)
            {
                combo = 1;
            }
        }
    }

    void FixedUpdate()
    {
        lastVelocity = pinBallrb.velocity;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Barrel")
        {
            collision.gameObject.GetComponent<itemRotate>().PS.Play();
            Destroy(collision.gameObject);

            //pinBallrb.velocity = new Vector3(-1*(pinBallrb.velocity.x * 3f), pinBallrb.velocity.y, -1*(pinBallrb.velocity.z * 3f));
            pinBallrb.velocity = Vector3.Reflect(lastVelocity, collision.contacts[0].normal);

            if (pinBallrb.velocity.x >= 0 && pinBallrb.velocity.z >= 0)
            {
                pinBallrb.velocity = pinBallrb.velocity * 1.2f + new Vector3(30f, 0, 30f);
            }
            else if (pinBallrb.velocity.x < 0 && pinBallrb.velocity.z >= 0)
            {
                pinBallrb.velocity = pinBallrb.velocity * 1.2f + new Vector3(-30f, 0, 30f);
            }
            else if (pinBallrb.velocity.x >= 0 && pinBallrb.velocity.z < 0)
            {
                pinBallrb.velocity = pinBallrb.velocity * 1.2f + new Vector3(30f, 0, -30f);
            }
            else if (pinBallrb.velocity.x < 0 && pinBallrb.velocity.z < 0)
            {
                pinBallrb.velocity = pinBallrb.velocity * 1.2f + new Vector3(-30f, 0, -30f);
            }
        }

        if (collision.collider.CompareTag("Rock"))
        {
            Instantiate(RockPS, transform.position + new Vector3(0,4,0), transform.rotation);

            pinBallrb.velocity = Vector3.Reflect(lastVelocity, collision.contacts[0].normal);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "BasicGem")
        {
            other.GetComponent<itemRotate>().PS.Play();
            Destroy(other.gameObject);

            score += 100 * combo;
            combo += 1;
        }

        if (other.gameObject.name == "Star")
        {
            other.GetComponent<itemRotate>().PS.Play();
            Destroy(other.gameObject);

            score += 1000 * combo;
            combo += 1;
        }

        if (other.gameObject.name == "Power")
        {
            other.GetComponent<itemRotate>().PS.Play();
            Destroy(other.gameObject);

            chance += 1;
            combo += 1;
        }

        if (other.gameObject.name == "Dollar")
        {
            other.GetComponent<itemRotate>().PS.Play();
            Destroy(other.gameObject);

            coin += Random.Range(5, 10);
            combo += 1;
        }
    }
}