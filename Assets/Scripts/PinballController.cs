using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinballController : MonoBehaviour
{
    public Rigidbody pinBallrb;
    public LineRenderer line;
    public ParticleSystem mine;
    
    public GameObject RockPS;
    public GameObject touchToStartPanel;
    
    
    public float speed = 5.0f;
    
    Vector3 startPoint, targetPoint;
    Vector3 lastVelocity;

    int chance = 2;
    [SerializeField]
    public static long score = 0;
    [SerializeField]
    long combo = 0;

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(touchToStartPanel.activeSelf == true)
        {
            if(Input.GetMouseButtonDown(0))
            {
                touchToStartPanel.SetActive(false);
            }
        }
        else if (chance > 0 && combo == 0 && touchToStartPanel.activeSelf == false)
        {
            if (Input.GetMouseButton(0))
            {
                line.gameObject.SetActive(true); //��Ŭ������ ���� ���� //��ҿ� ���� ��������
                if (Physics.Raycast(ray, out hit))
                {
                    startPoint = new Vector3(transform.position.x, 0, transform.position.z);
                    targetPoint = new Vector3(hit.point.x, 0, hit.point.z);

                    //lineRenderer.SetPosition: ���η�����(lineRenderer)?������ġ��?�������ִ� �Լ���
                    //ù��° �Ű������� 1�̳� 0 ���� //�ι��� �Ű������� Vector3 �� ���µ� "��ġ"��
                    line.SetPosition(1, startPoint); //1 ������: ������ġ
                    line.SetPosition(0, targetPoint); //0 ������: ��ǥ��ġ
                }
            }
            else if (Input.GetMouseButtonUp(0))
            {
                pinBallrb.AddForce((startPoint - targetPoint) * 30f, ForceMode.Impulse);
                line.gameObject.SetActive(false);
                chance -= 1;
            }
        }
        else if(chance <= 0)
        {
            //gamestop
        }

        if((pinBallrb.velocity.x < 1f && pinBallrb.velocity.x > -1f)||(pinBallrb.velocity.z < 1f && pinBallrb.velocity.z > -1f))
        {
            pinBallrb.velocity = Vector3.zero;
            mine.Stop();
            combo = 0;
        }
        else
        {
            mine.Play();
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
                pinBallrb.velocity = pinBallrb.velocity * 1.2f + new Vector3(20f, 0, 20f);
            }
            else if (pinBallrb.velocity.x < 0 && pinBallrb.velocity.z >= 0)
            {
                pinBallrb.velocity = pinBallrb.velocity * 1.2f + new Vector3(-20f, 0, 20f);
            }
            else if (pinBallrb.velocity.x >= 0 && pinBallrb.velocity.z < 0)
            {
                pinBallrb.velocity = pinBallrb.velocity * 1.2f + new Vector3(20f, 0, -20f);
            }
            else if (pinBallrb.velocity.x < 0 && pinBallrb.velocity.z < 0)
            {
                pinBallrb.velocity = pinBallrb.velocity * 1.2f + new Vector3(-20f, 0, -20f);
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
    }
}