namespace Treeees
{
    class Program
    {
        static void Main(string[] args)
        {
            Tree treeA = new Tree();
            treeA.add_first();
            treeA.add_v(2, 1);
            treeA.add_v(3, 1);
            treeA.add_v(4, 2);
            treeA.add_v(5, 2);
            treeA.Straight(treeA.vertices[0]);
            Console.WriteLine(treeA.newNums);
            Tree treeB = new Tree();
            treeB.add_first();
            treeB.add_v(2,1);
            treeB.add_v(3, 1);
            treeB.add_v(4, 2);
            Back_Oper(treeB, treeA, treeB.vertices[0]);
            treeA.newNums = "";
            treeA.Straight(treeA.vertices[0]);
            Console.WriteLine(treeA.newNums);
        }
        public static void add_v_Oper(Tree tree, Vertex in_vertex)
        {
            foreach (var vertex in tree.vertices)
            {
                if (vertex.children.Count < 2)
                {
                    in_vertex.vertexName = tree.vertices.Count + 1;
                    in_vertex.children.Clear();
                    vertex.children.Add(in_vertex);
                    tree.vertices.Add(in_vertex);
                    break;
                }
            }
        }
        public static void Back_Oper(Tree tree, Tree anotherTree, Vertex vertex)
        {
            if (vertex.children.Count != 0) Back_Oper(tree, anotherTree, vertex.children[0]);
            if (vertex.children.Count == 2) Back_Oper(tree, anotherTree, vertex.children[1]);
            add_v_Oper(anotherTree, vertex);
        }
    }

    public class Vertex
    {
        public int vertexName;
        public List<Vertex> children = new List<Vertex>();

        public Vertex(int vertexName)
        {
            this.vertexName = vertexName;
        }
    }

    public class Tree
    {
        public string newNums = "";
        public List<Vertex> vertices = new List<Vertex>();
        

        public void add_v(int vertex_name, int parent_name)
        {
            foreach (var vertex in vertices)
            {
                if (vertex.vertexName == parent_name && vertex.children.Count < 2)
                {
                    Vertex vertex1 = new Vertex(vertex_name);
                    vertex.children.Add(vertex1);
                    vertices.Add(vertex1);
                    break;
                }
            }
        }

        public void add_first()
        {
            vertices.Add(new Vertex(1));
        }
        

        public void Straight(Vertex vertex)
        {
             newNums+=vertex.vertexName;
             if (vertex.children.Count !=0) Straight(vertex.children[0]);
             if (vertex.children.Count == 2) Straight(vertex.children[1]);
        }
        public void Back(Vertex vertex)
        {
             if (vertex.children.Count != 0) Back(vertex.children[0]);
             if (vertex.children.Count == 2) Back(vertex.children[1]);
             newNums += vertex.vertexName;
        }
        public void Symetry(Vertex vertex)
        {
            if (vertex.children.Count != 0) Symetry(vertex.children[0]); 
            else
            {
                newNums += vertex.vertexName;
            }
            if (vertex.children.Count == 2)
            {
                newNums += vertex.vertexName;
                Symetry(vertex.children[1]);
            }
            if (vertex.children.Count == 0)
            {
                newNums += vertex.vertexName;
            }
            for (int i = 1; i < newNums.Length; i++)
            {
                if (newNums[i] == newNums[i-1])
                {
                    newNums = newNums.Remove(i);
                }
            }
        }  
    }
}