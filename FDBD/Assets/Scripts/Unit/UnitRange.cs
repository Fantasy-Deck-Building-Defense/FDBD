using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UnitRange : MonoBehaviour
{
    [SerializeField] public float rotatSpeed;

    private NavMeshAgent agent;
    [SerializeField] private bool isMove => agent.velocity.sqrMagnitude > 0;

    private List<Collider> Enemys = new List<Collider>();

    private Transform pTransform;   // 부모 위치

    // Start is called before the first frame update
    private void Awake()
    {
        agent = GetComponentInParent<NavMeshAgent>();
    }
    void Start()
    {
        pTransform = transform.parent;
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
        if (isMove) 
            return;

        if (other.CompareTag("Enemy"))
        {
            Collider closestObject = null;
            float closestDistance = Mathf.Infinity;

            // 현재 오브젝트의 위치
            Vector3 currentPosition = pTransform.position;

            foreach (Collider obj in Enemys)
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
                pTransform.rotation = Quaternion.Slerp(pTransform.rotation, targetRotation, Time.deltaTime * 5f);

                other.GetComponent<Enemy>().Attack(eAttackType.NORMAL, 2);
                if (!other.gameObject.activeSelf) Enemys.Remove(other);
            }
        }
    }
}
