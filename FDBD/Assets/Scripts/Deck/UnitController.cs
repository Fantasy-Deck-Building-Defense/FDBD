using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UnitController : MonoBehaviour
{
    [SerializeField] private GameObject selectedUnit;

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
                }
            }
            else
            {
                if (Physics.Raycast(ray, out hit, Mathf.Infinity) && hit.transform.CompareTag("Unit"))
                {
                    selectedUnit.GetComponent<Renderer>().material.color = Color.blue;
                    selectedUnit = hit.collider.gameObject;
                    selectedUnit.GetComponent<Renderer>().material.color = Color.red;
                }
                else if (Physics.Raycast(ray, out hit, Mathf.Infinity))
                {
                    selectedUnit.GetComponent<NavMeshAgent>().SetDestination(hit.point);
                }
            }
        }
    }
}
