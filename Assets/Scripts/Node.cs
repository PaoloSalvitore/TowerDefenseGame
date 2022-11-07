using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    private float _directDistanceToEnd = 0;
    public float DirectDistanceToEnd
    {
        get => _directDistanceToEnd;
    }

    public void SetDirectDistanceToEnd(Vector3 endPosition)
    {
        _directDistanceToEnd = Vector3.Distance(transform.position, endPosition);
    }

    /// <summary>
    /// total cost of shortest path to this node
    /// </summary>
    private float _pathWeight = 1;

    public float PathWeightHeuristic
    {
        get => _pathWeight + towerWeight;
        set => _pathWeight = value;
    }
    public float PathWeight { get => _pathWeight + _directDistanceToEnd; set => _pathWeight = value; }
    /// <summary>
    /// following the shortest path, previousNode is the previous step on that path
    /// </summary>
    private Node _previousNode = null;
    public Node PreviousNode { get => _previousNode; set => _previousNode = value; }
    /// <summary>
    /// Nodes this node is connected to
    /// </summary>
    /// 

    public float towerWeight = 0;
    [SerializeField] private List<Node> _neighbourNodes;
    public List<Node> NeighbourNodes { get => _neighbourNodes; }

    private void Start()
    {
        ResetNode();
        ValidateNeighbours();
    }

    public void ResetNode()
    {
        PathWeight = int.MaxValue;
        PreviousNode = null;
        _directDistanceToEnd = 0;
    }

    public void AddNeighbourNode(Node node)
    {
        NeighbourNodes.Add(node);
    }

    private void OnDrawGizmos()
    {
        foreach (Node node in _neighbourNodes)
        {
            if (node == null) continue;
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, node.transform.position);

        }
    }

    private void OnValidate()
    {
        ValidateNeighbours();
    }

    private void ValidateNeighbours()
    {
        foreach (Node node in _neighbourNodes)
        {
            if (node == null) continue;

            if (!node._neighbourNodes.Contains(this))
            {
                node.AddNeighbourNode(this);
            }
        }
    }

   
}
