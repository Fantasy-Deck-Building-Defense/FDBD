using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UnitController : MonoBehaviour
{

    [Header("Initial info")]
    [SerializeField] private Unit _initialUnit;
    [SerializeField] private int _initialCount;

    [Header("Round info")]
    [SerializeField] private GameObject _selectedUnit;

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

            if (_selectedUnit == null)
            {
                if (Physics.Raycast(ray, out hit, Mathf.Infinity) && hit.transform.CompareTag("Unit"))
                {
                    _selectedUnit = hit.collider.gameObject;
                    _selectedUnit.GetComponent<Renderer>().material.color = Color.red;
                    _selectedUnit.GetComponent<NavMeshAgent>().avoidancePriority = 80;
                }
            }
            else
            {
                if (Physics.Raycast(ray, out hit, Mathf.Infinity) && hit.transform.CompareTag("Unit"))
                {
                    _selectedUnit.GetComponent<Renderer>().material.color = Color.blue;
                    _selectedUnit.GetComponent<NavMeshAgent>().avoidancePriority = 50;

                    _selectedUnit = hit.collider.gameObject;
                    _selectedUnit.GetComponent<NavMeshAgent>().avoidancePriority = 80;
                    _selectedUnit.GetComponent<Renderer>().material.color = Color.red;
                }
                else if (Physics.Raycast(ray, out hit, Mathf.Infinity))
                {
                    _selectedUnit.GetComponent<NavMeshAgent>().SetDestination(hit.point);
                }
            }
        }
    }
    
    public void SpawnInitialUnits()
    {
        for(int i = 0; i < _initialCount; ++i)
        {

        }
    }

    public void SpawnUnit()
    {

    }

    public void EndGame()
    {
        if (_selectedUnit)
        {
            _selectedUnit.GetComponent<Renderer>().material.color = Color.blue;
            _selectedUnit.GetComponent<NavMeshAgent>().avoidancePriority = 50;
            _selectedUnit = null;
        }
    }
}
