using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitTest : MonoBehaviour
{
    //[SerializeField]
    //public float rotatSpeed;

    //[SerializeField]
    //public float moveSpeed;

    //Vector3 destPos;
    //Vector3 dir;
    //Quaternion lookTarget;

    //bool move = false;

    private List<Collider> objectsInTrigger = new List<Collider>();

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, transform.forward * 16, Color.yellow);

        //// 왼쪽 마우스 버튼을 눌렀을 때
        //if (Input.GetMouseButtonDown(0))
        //{
        //    RaycastHit hit;
        //    // 메인 카메라를 통해 마우스 클릭한 곳의 ray 정보를 가져옴
        //    var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        //    // ray와 닿은 물체가 있는지 검사
        //    if (Physics.Raycast(ray, out hit, 100f))
        //    {
        //        // print(hit.transform.name);

        //        // hit.point 는 마우스 클릭한 곳의 월드 좌표.
        //        // 이 예제에서 캐릭터의 y 값(높이) 은 변하지 않기 때문에 그대로 유지
        //        destPos = new Vector3(hit.point.x, transform.position.y, hit.point.z);

        //        // 현재 위치와 목표 위치의 방향 벡터
        //        dir = destPos - transform.position;

        //        // 바라 보아야 할 곳의 Quaternion
        //        lookTarget = Quaternion.LookRotation(dir);
        //        move = true;
        //    }
        //}

        //Move();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            objectsInTrigger.Add(other);

            //Debug.Log(other.gameObject.name);

            //// 두 오브젝트 간의 방향 벡터 계산
            //Vector3 direction = other.transform.position - transform.position;
            //direction.y = 0;

            //// 방향 벡터를 기반으로 회전 값 생성 (Y축을 제외하고 싶으면 direction.y = 0; 추가)
            //Quaternion rotation = Quaternion.LookRotation(direction);

            //// 현재 오브젝트를 해당 방향으로 회전
            //transform.rotation = rotation;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            objectsInTrigger.Remove(other);
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            //Debug.Log(other.gameObject.name);

            //// 두 오브젝트 간의 방향 벡터 계산
            //Vector3 direction = other.transform.position - transform.position;
            //direction.y = 0;

            //// 방향 벡터를 기반으로 회전 값 생성 (Y축을 제외하고 싶으면 direction.y = 0; 추가)
            //Quaternion rotation = Quaternion.LookRotation(direction);

            //// 현재 오브젝트를 해당 방향으로 회전
            //transform.rotation = rotation;

            Collider closestObject = null;
            float closestDistance = Mathf.Infinity;

            // 현재 오브젝트의 위치
            Vector3 currentPosition = transform.position;

            foreach (Collider obj in objectsInTrigger)
            {
                // 각 오브젝트와의 거리 계산
                float distance = Vector3.Distance(currentPosition, obj.transform.position);

                // 가장 가까운 오브젝트를 업데이트
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestObject = obj;
                }
            }

            // 가장 가까운 오브젝트가 있다면 해당 방향으로 회전
            if (closestObject != null)
            {
                Vector3 direction = closestObject.transform.position - currentPosition;
                direction.y = 0; // Y축은 고정하고 수평 회전만 적용

                Quaternion targetRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 5f);
            }

            Debug.Log(closestObject.gameObject.name);
        }
    }

    void Move()
    {
        //if (move)
        //{
        //    // 이동할 방향으로 Time.deltaTime * moveSpeed 의 속도로 움직임.
        //    transform.position += dir.normalized * Time.deltaTime * moveSpeed;

        //    // 현재 방향에서 움직여야할 방향으로 부드럽게 회전
        //    //transform.rotation = Quaternion.Lerp(transform.rotation, lookTarget, rotatSpeed);

        //    // 캐릭터의 위치와 목표 위치의 거리가 0.05f 보다 큰 동안만 이동
        //    move = (transform.position - destPos).magnitude > 0.05f;
        //}
    }
}
