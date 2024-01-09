using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGenerator : MonoBehaviour
{
    public MazeNode nodePrefab;

    public int xmaz;
    public int ymaz;

    // Start is called before the first frame update
    void Start()
    {
        Load();
        GenerateMazeInstant();
    }

    void GenerateMazeInstant()
    {
        List<MazeNode> nodes = new List<MazeNode>();

        for (int x = 0; x < xmaz; x++)
        {
            for (int y = 0; y < ymaz; y++)
            {
                Vector3 nodePose = new Vector3(x - (xmaz / 2f), 0, y - (ymaz / 2f));
                MazeNode newNode = Instantiate(nodePrefab, nodePose, Quaternion.identity, transform);
                nodes.Add(newNode);
            }
        }

        List<MazeNode> currentPath = new List<MazeNode>();
        List<MazeNode> completedNode = new List<MazeNode>();

        currentPath.Add(nodes[Random.Range(0, nodes.Count)]);
        currentPath[0].SetState(NodeState.Current);

        while (completedNode.Count < nodes.Count)
        {
            List<int> posibleNextNode = new List<int>();
            List<int> posibleDirection = new List<int>();

            int currentNodeIndex = nodes.IndexOf(currentPath[currentPath.Count - 1]);
            int currentNodeX = (int)(currentNodeIndex / ymaz);
            int currentNodeY = (int)(currentNodeIndex % ymaz);

            if (currentNodeX < xmaz - 1)
            {
                if (!completedNode.Contains(nodes[(int)(currentNodeIndex + ymaz)]) &&
                    !currentPath.Contains(nodes[(int)(currentNodeIndex + ymaz)]))
                {
                    posibleDirection.Add(1);
                    posibleNextNode.Add((int)(currentNodeIndex + ymaz));
                }
            }

            if (currentNodeX > 0)
            {
                if (!completedNode.Contains(nodes[(int)(currentNodeIndex - ymaz)]) &&
                    !currentPath.Contains(nodes[(int)(currentNodeIndex - ymaz)]))
                {
                    posibleDirection.Add(2);
                    posibleNextNode.Add((int)(currentNodeIndex - ymaz));
                }
            }

            if (currentNodeY < ymaz - 1)
            {
                if (!completedNode.Contains(nodes[(int)(currentNodeIndex + 1)]) &&
                    !currentPath.Contains(nodes[(int)(currentNodeIndex + 1)]))
                {
                    posibleDirection.Add(3);
                    posibleNextNode.Add((int)(currentNodeIndex + 1));
                }
            }

            if (currentNodeY > 0)
            {
                if (!completedNode.Contains(nodes[(int)(currentNodeIndex - 1)]) &&
                    !currentPath.Contains(nodes[(int)(currentNodeIndex - 1)]))
                {
                    posibleDirection.Add(4);
                    posibleNextNode.Add((int)(currentNodeIndex - 1));
                }
            }

            if (posibleDirection.Count > 0)
            {
                int choiceDirection = Random.Range(0, posibleDirection.Count);
                MazeNode choiceNode = nodes[posibleNextNode[choiceDirection]];

                switch (posibleDirection[choiceDirection])
                {
                    case 1:
                        choiceNode.RemoveWall(1);
                        currentPath[currentPath.Count - 1].RemoveWall(0);
                        break;
                    case 2:
                        choiceNode.RemoveWall(0);
                        currentPath[currentPath.Count - 1].RemoveWall(1);

                        break;
                    case 3:
                        choiceNode.RemoveWall(3);
                        currentPath[currentPath.Count - 1].RemoveWall(2);
                        break;
                    case 4:
                        choiceNode.RemoveWall(2);
                        currentPath[currentPath.Count - 1].RemoveWall(3);
                        break;
                }

                currentPath.Add(choiceNode);
                choiceNode.SetState(NodeState.Current);
            }

            else
            {
                completedNode.Add(currentPath[currentPath.Count - 1]);

                currentPath[currentPath.Count - 1].SetState(NodeState.Completed);
                currentPath.RemoveAt(currentPath.Count - 1);
            }
        }
    }

    public void Load()
    {
        if (PlayerPrefs.HasKey("XMaze"))
        {
            xmaz = PlayerPrefs.GetInt("XMaze");
            ymaz = PlayerPrefs.GetInt("YMaze");
        }
    }
}
