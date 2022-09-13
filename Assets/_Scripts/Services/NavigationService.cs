using System;
using System.Collections.Generic;
using System.Linq;
using Client.Extensions;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace _Scripts.Services
{
    public class Cell
    {
        public Vector2Int CellCoords;
        public int GCost, HCost;
        public bool Available = true;
        public Cell[] Neighbours;
        public Cell Parent;
        public Vector2 Position;

        public int FCost => GCost + HCost;

        public override string ToString()
        {
            return CellCoords.ToString();
        }
    }

    public interface INavigationService
    {
        Cell[] FindPath(Vector2 startPos, Vector2 targetPos);
        void OccupyCell(Vector2Int cellCoords);
        void FreeCell(Vector2Int cellCoords);
    }

    public class NavigationService : MonoBehaviour, INavigationService
    {
        [SerializeField] private Tilemap tilemap;
        [SerializeField] private Vector2Int scanStart, scanEnd;
        private Dictionary<Vector2Int, Cell> _cells;


        private void Start()
        {
            TilemapToCells();
        }

        private void OnDrawGizmos()
        {
            if (_cells == null) return;

            DrawOccupiedCells();
        }

        private void DrawOccupiedCells()
        {
            var occupiedCells = _cells.Where(x => !x.Value.Available).ToArray();
            foreach (var cell in occupiedCells)
            {
                Gizmos.DrawWireSphere(cell.Value.Position, 1f);
            }
        }

        private void TilemapToCells()
        {
            _cells = new Dictionary<Vector2Int, Cell>();

            for (int x = scanStart.x; x < scanEnd.x; x++)
            for (int y = scanStart.y; y < scanEnd.y; y++)
            {
                if (!tilemap.HasTile(new Vector3Int(x, y, 0))) continue;

                var cell = new Cell()
                {
                    CellCoords = new Vector2Int(x, y),
                    Position = tilemap.GetCellCenterWorld(new Vector3Int(x, y, 0))
                };
                _cells.Add(new Vector2Int(x, y), cell);
            }

            foreach (var cell in _cells)
            {
                cell.Value.Neighbours = GetNeighbours(cell.Key);
            }
        }

        private Cell[] GetNeighbours(Vector2Int coords)
        {
            var result = new List<Cell>();
            for (int x = -1; x < 2; x++)
            for (int y = -1; y < 2; y++)
            {
                if (x == 0 && y == 0) continue;
               // if (Mathf.Abs(x) + Mathf.Abs(y) == 2) continue;
                var key = new Vector2Int(coords.x + x, coords.y + y);
                if (!_cells.ContainsKey(key)) continue;
                result.Add(_cells[key]);
            }

            return result.ToArray();
        }

        public Cell[] FindPath(Vector2 startPos, Vector2 targetPos)
        {
            var startCoords = tilemap.WorldToCell(startPos).Vector2Int();
            var targetCoords = tilemap.WorldToCell(targetPos).Vector2Int();
            return FindPath(startCoords, targetCoords);
        }

        public void OccupyCell(Vector2Int cellCoords)
        {
            _cells[cellCoords].Available = false;
        }

        public void FreeCell(Vector2Int cellCoords)
        {
            _cells[cellCoords].Available = true;
        }

        private Cell[] FindPath(Vector2Int startCoords, Vector2Int targetCoords)
        {
            if (!_cells.ContainsKey(startCoords) || !_cells.ContainsKey(targetCoords)) return Array.Empty<Cell>();
            //get player and target position in grid coords
            var seekerNode = _cells[startCoords];
            var targetNode = _cells[targetCoords];

            var openSet = new List<Cell>();
            var closedSet = new HashSet<Cell>();
            openSet.Add(seekerNode);

            //calculates path for pathfinding
            while (openSet.Count > 0)
            {
                //iterates through openSet and finds lowest FCost
                var node = openSet[0];
                for (var i = 1; i < openSet.Count; i++)
                {
                    if (openSet[i].FCost > node.FCost) continue;

                    if (openSet[i].HCost < node.HCost)
                        node = openSet[i];
                }

                openSet.Remove(node);
                closedSet.Add(node);

                //If target found, retrace path
                if (node.CellCoords == targetNode.CellCoords)
                {
                    return RetracePath(seekerNode, targetNode);
                }

                //adds neighbor nodes to openSet
                foreach (var neighbour in node.Neighbours)
                {
                    if (closedSet.Contains(neighbour) || !neighbour.Available)
                    {
                        continue;
                    }

                    var newCostToNeighbour = node.GCost + GetDistance(node, neighbour);
                    if (newCostToNeighbour >= neighbour.GCost && openSet.Contains(neighbour)) continue;

                    neighbour.GCost = newCostToNeighbour;
                    neighbour.HCost = GetDistance(neighbour, targetNode);
                    neighbour.Parent = node;

                    if (!openSet.Contains(neighbour))
                        openSet.Add(neighbour);
                }
            }

            return Array.Empty<Cell>();
        }

        //reverses calculated path so first node is closest to seeker
        private Cell[] RetracePath(Cell startNode, Cell endNode)
        {
            var path = new List<Cell>();
            var currentNode = endNode;

            while (currentNode != startNode)
            {
                path.Add(currentNode);
                currentNode = currentNode.Parent;
            }

            path.Reverse();

            return path.ToArray();
        }

        //gets distance between 2 nodes for calculating cost
        private int GetDistance(Cell nodeA, Cell nodeB)
        {
            var dstX = Mathf.Abs(nodeA.CellCoords.x - nodeB.CellCoords.x);
            var dstY = Mathf.Abs(nodeA.CellCoords.y - nodeB.CellCoords.y);

            if (dstX > dstY)
                return 14 * dstY + 10 * (dstX - dstY);
            return 14 * dstX + 10 * (dstY - dstX);
        }
    }
}