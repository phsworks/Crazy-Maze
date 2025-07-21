using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_Behaviour : MonoBehaviour
{

    public Transform PatrolRoute;

    public List<Transform> Locations;


    private int _locationIndex = 0;
    private NavMeshAgent _agent;

    public Transform Player;

    private bool _isChasingPlayer;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InitializePatrolRoute();

        _agent = GetComponent<NavMeshAgent>();

        MoveToNextPatrolLocation();

        Player = GameObject.Find("Player").transform;
    }

    void InitializePatrolRoute()
    {
        foreach (Transform child in PatrolRoute)
        {
            Locations.Add(child);
        }
    }



    // Update is called once per frame
    void Update()
    {

        if (_agent.remainingDistance < 0.2f && !_agent.pathPending && !_isChasingPlayer)
        {
            MoveToNextPatrolLocation();
        }
    }

    void MoveToNextPatrolLocation()
    {
        if (Locations.Count == 0) return;


        _agent.destination = Locations[_locationIndex].position;

        _locationIndex = (_locationIndex + 1) % Locations.Count;
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            _isChasingPlayer = true;
            _agent.destination = Player.position;
            Debug.Log("Enemy Detected");
        }
    }
}
