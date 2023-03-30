using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinballController : MonoBehaviour
{
    public Rigidbody pinBallrb;
    public LineRenderer line;
    public float speed = 5.0f;
    Vector3 startPoint, targetPoint;

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

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
            pinBallrb.AddForce((startPoint-targetPoint)*30f, ForceMode.Impulse);
            line.gameObject.SetActive(false);
        }

        if((pinBallrb.velocity.x < 1f && pinBallrb.velocity.x > -1f)||(pinBallrb.velocity.z < 1f && pinBallrb.velocity.z > -1f))
        {
            pinBallrb.velocity = Vector3.zero;
        }
    }
}