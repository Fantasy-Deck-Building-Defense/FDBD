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

        //// ���� ���콺 ��ư�� ������ ��
        //if (Input.GetMouseButtonDown(0))
        //{
        //    RaycastHit hit;
        //    // ���� ī�޶� ���� ���콺 Ŭ���� ���� ray ������ ������
        //    var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        //    // ray�� ���� ��ü�� �ִ��� �˻�
        //    if (Physics.Raycast(ray, out hit, 100f))
        //    {
        //        // print(hit.transform.name);

        //        // hit.point �� ���콺 Ŭ���� ���� ���� ��ǥ.
        //        // �� �������� ĳ������ y ��(����) �� ������ �ʱ� ������ �״�� ����
        //        destPos = new Vector3(hit.point.x, transform.position.y, hit.point.z);

        //        // ���� ��ġ�� ��ǥ ��ġ�� ���� ����
        //        dir = destPos - transform.position;

        //        // �ٶ� ���ƾ� �� ���� Quaternion
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

            //// �� ������Ʈ ���� ���� ���� ���
            //Vector3 direction = other.transform.position - transform.position;
            //direction.y = 0;

            //// ���� ���͸� ������� ȸ�� �� ���� (Y���� �����ϰ� ������ direction.y = 0; �߰�)
            //Quaternion rotation = Quaternion.LookRotation(direction);

            //// ���� ������Ʈ�� �ش� �������� ȸ��
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

            //// �� ������Ʈ ���� ���� ���� ���
            //Vector3 direction = other.transform.position - transform.position;
            //direction.y = 0;

            //// ���� ���͸� ������� ȸ�� �� ���� (Y���� �����ϰ� ������ direction.y = 0; �߰�)
            //Quaternion rotation = Quaternion.LookRotation(direction);

            //// ���� ������Ʈ�� �ش� �������� ȸ��
            //transform.rotation = rotation;

            Collider closestObject = null;
            float closestDistance = Mathf.Infinity;

            // ���� ������Ʈ�� ��ġ
            Vector3 currentPosition = transform.position;

            foreach (Collider obj in objectsInTrigger)
            {
                // �� ������Ʈ���� �Ÿ� ���
                float distance = Vector3.Distance(currentPosition, obj.transform.position);

                // ���� ����� ������Ʈ�� ������Ʈ
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestObject = obj;
                }
            }

            // ���� ����� ������Ʈ�� �ִٸ� �ش� �������� ȸ��
            if (closestObject != null)
            {
                Vector3 direction = closestObject.transform.position - currentPosition;
                direction.y = 0; // Y���� �����ϰ� ���� ȸ���� ����

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
        //    // �̵��� �������� Time.deltaTime * moveSpeed �� �ӵ��� ������.
        //    transform.position += dir.normalized * Time.deltaTime * moveSpeed;

        //    // ���� ���⿡�� ���������� �������� �ε巴�� ȸ��
        //    //transform.rotation = Quaternion.Lerp(transform.rotation, lookTarget, rotatSpeed);

        //    // ĳ������ ��ġ�� ��ǥ ��ġ�� �Ÿ��� 0.05f ���� ū ���ȸ� �̵�
        //    move = (transform.position - destPos).magnitude > 0.05f;
        //}
    }
}
