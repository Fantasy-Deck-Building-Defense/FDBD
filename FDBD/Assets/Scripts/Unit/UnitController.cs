using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UnitController : MonoBehaviour
{
    [SerializeField] private GameObject selectedUnit;
    public void Awake()
    {
    }

    public void Update()
    {
        if (!GameManager.Instance.isGameStart)
            return;

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

    public void EndGame()
    {
        if (selectedUnit)
        {
            selectedUnit.GetComponent<Renderer>().material.color = Color.blue;
            selectedUnit.GetComponent<NavMeshAgent>().avoidancePriority = 50;
            selectedUnit = null;
        }
    }
}
