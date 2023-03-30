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
            line.gameObject.SetActive(true); //좌클했을때 라인 보임 //평소엔 라인 꺼놓으셈
            if (Physics.Raycast(ray, out hit))
            {
                startPoint = new Vector3(transform.position.x, 0, transform.position.z);
                targetPoint = new Vector3(hit.point.x, 0, hit.point.z);

                //lineRenderer.SetPosition: 라인랜더러(lineRenderer)?시작위치를?설정해주는 함수임
                //첫번째 매개변수는 1이나 0 들어가고 //두번쨰 매개변수는 Vector3 값 들어가는데 "위치"임
                line.SetPosition(1, startPoint); //1 넣으면: 시작위치
                line.SetPosition(0, targetPoint); //0 넣으면: 목표위치
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