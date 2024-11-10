using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UnitController : MonoBehaviour
{
    [SerializeField] private GameObject selectedUnit;
    public int all_killCount;
    public int thisRound_killCount;
    public void Awake()
    {
        thisRound_killCount = 0;
    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (selectedUnit == null)
            {
                if (Physics.Raycast(ray, out hit, Mathf.Infinity) && hit.transform.CompareTag("Unit"))
                {
                    selectedUnit = hit.collider.gameObject;
                    selectedUnit.GetComponent<Renderer>().material.color = Color.red;
                    selectedUnit.GetComponent<NavMeshAgent>().avoidancePriority = 80;
                }
            }
            else
            {
                if (Physics.Raycast(ray, out hit, Mathf.Infinity) && hit.transform.CompareTag("Unit"))
                {
                    selectedUnit.GetComponent<Renderer>().material.color = Color.blue;
                    selectedUnit.GetComponent<NavMeshAgent>().avoidancePriority = 50;

                    selectedUnit = hit.collider.gameObject;
                    selectedUnit.GetComponent<NavMeshAgent>().avoidancePriority = 80;
                    selectedUnit.GetComponent<Renderer>().material.color = Color.red;
                }
                else if (Physics.Raycast(ray, out hit, Mathf.Infinity))
                {
                    selectedUnit.GetComponent<NavMeshAgent>().SetDestination(hit.point);
                }
            }
        }
    }

    public void SetNextRound()
    {
        all_killCount = thisRound_killCount;
        thisRound_killCount = 0;
    }
}
