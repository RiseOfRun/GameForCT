using System.Collections.Generic;

namespace new_Game
{
    class Graph
    {
        List<List<int>> adjacencyList = new List<List<int>>();

        public void BuildTileGraph(int width, int height)
        {
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    adjacencyList.Add(new List<int>());
                    if (j!=width-1) adjacencyList[i*width+j].Add(width*i+j+1);
                    if (j!=0) adjacencyList[i*width+j].Add(width*i+j-1);
                    if (i!=0) adjacencyList[i*width+j].Add(width*(i-1)+j);
                    if (i!=height-1) adjacencyList[i*width+j].Add(width*(i+1)+j);
                    if (j!=width-1&&i!=height) adjacencyList[i*width+j].Add((i+1)*width+j+1);
                    if (j!=width-1&& i!=0) adjacencyList[i*width+j].Add((i-1)*width+j+1);
                    if (j!=0&&i!=0) adjacencyList[i*width+j].Add(j-1+(i-1)*width);
                    if (j!=0&&i!=height-1) adjacencyList[i*width+j].Add(j-1+(i+1)*width);
                }
            }
        }

        public List<int> FindPath(int a, int b)
        {
            List<int> path = new List<int>();
            bool[] visited = new bool[adjacencyList.Count];
            int[] parent = new int[adjacencyList.Count];
            visited[a] = true;
            Queue<int> q = new Queue<int>();
            int current = a;
            parent[current] = a;
            
            while (q.Count!=0 && current!=b)
            {
                current = q.Dequeue();
                foreach (var vertex in adjacencyList[current])
                {
                    if (!visited[vertex])
                    {
                        parent[vertex] = current;
                        q.Enqueue(vertex);
                        visited[vertex] = true;
                    }
                }
            }
            
            int v = b;
            while (v!=a)
            {
                path.Add(v);
                v = parent[v];
            }
            path.Add(v);
            path.Reverse();
            
            return path;
        }
    }
}