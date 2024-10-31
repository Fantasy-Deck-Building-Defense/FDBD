using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityRange : MonoBehaviour
{
    [SerializeField]
    public float rotatSpeed;

    private List<Collider> Enemys = new List<Collider>();

    private Transform pTransform;   // �θ� ��ġ

    // Start is called before the first frame update
    void Start()
    {
        pTransform = transform.parent;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Enemys.Add(other);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Enemys.Remove(other);
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Collider closestObject = null;
            float closestDistance = Mathf.Infinity;

            // ���� ������Ʈ�� ��ġ
            Vector3 currentPosition = pTransform.position;

            foreach (Collider obj in Enemys)
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
                pTransform.rotation = Quaternion.Slerp(pTransform.rotation, targetRotation, Time.deltaTime * 5f);

                other.GetComponent<Enemy>().Attack(eAttackType.NORMAL, 2);
                if (!other.gameObject.activeSelf) Enemys.Remove(other);
            }
        }
    }
}
