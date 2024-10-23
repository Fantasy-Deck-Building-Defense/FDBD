using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField]
    public float rotatSpeed;

    [SerializeField]
    public float moveSpeed;

    Vector3 destPos;
    Vector3 dir;
    Quaternion lookTarget;

    bool move = false;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // ���� ���콺 ��ư�� ������ ��
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            // ���� ī�޶� ���� ���콺 Ŭ���� ���� ray ������ ������
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            // ray�� ���� ��ü�� �ִ��� �˻�
            if (Physics.Raycast(ray, out hit, 100f))
            {
                // print(hit.transform.name);

                // hit.point �� ���콺 Ŭ���� ���� ���� ��ǥ.
                // �� �������� ĳ������ y ��(����) �� ������ �ʱ� ������ �״�� ����
                destPos = new Vector3(hit.point.x, transform.position.y, hit.point.z);

                // ���� ��ġ�� ��ǥ ��ġ�� ���� ����
                dir = destPos - transform.position;

                // �ٶ� ���ƾ� �� ���� Quaternion
                lookTarget = Quaternion.LookRotation(dir);
                move = true;
            }
        }

        Move();
    }

    void Move()
    {
        if (move)
        {
            // �̵��� �������� Time.deltaTime * moveSpeed �� �ӵ��� ������.
            transform.position += dir.normalized * Time.deltaTime * moveSpeed;

            // ���� ���⿡�� ���������� �������� �ε巴�� ȸ��
            transform.rotation = Quaternion.Lerp(transform.rotation, lookTarget, rotatSpeed);

            // ĳ������ ��ġ�� ��ǥ ��ġ�� �Ÿ��� 0.05f ���� ū ���ȸ� �̵�
            move = (transform.position - destPos).magnitude > 0.05f;
        }
    }
}
