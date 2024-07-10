using System.Security.Cryptography.X509Certificates;

namespace Algorithms.DataStructures;

public class Vertex(string Name)
{
	public string Name = Name;

	public List<Vertex>? neighbors = [];

	public void AddNeighbor(Vertex vertex)
	{
		if (neighbors.Contains(vertex))
			return;
		
		neighbors.Add(vertex);
		neighbors = neighbors.OrderBy(element => element.Name).ToList();
	}
}

public class Graph
{
	public List<Vertex> vertices = [];

	public void AddVertex(string Name)
	{
		Vertex vertex = new(Name);
		AddVertex(vertex);
	}

	public void AddVertex(Vertex vertex)
	{
		// Not adding duplicate vertices
		if (vertices.Contains(vertex))
			return;
			
		vertices.Add(vertex);
		vertices = vertices.OrderBy(element => element.Name).ToList();
	}

	public void AddEdge(string firstName, string secondName)
	{
        Vertex? firstVertex = vertices.FirstOrDefault(element => element.Name == firstName);
        Vertex? secondVertex = vertices.FirstOrDefault(element => element.Name == secondName);
	
		if (firstVertex is null & secondVertex is null)
			return;
		
		AddEdge(firstVertex, secondVertex);
	}

	public void AddEdge(Vertex firstVertex, Vertex secondVertex)
	{
		if (vertices.Contains(firstVertex) & vertices.Contains(secondVertex))
		{
			for (int i = 0; i < vertices.Count; i++)
			{
				Vertex currentVertex = vertices[i];

				if (currentVertex.Name == firstVertex.Name)
					currentVertex.AddNeighbor(secondVertex);
				
				if (currentVertex.Name == secondVertex.Name)
					currentVertex.AddNeighbor(firstVertex);
			}
		}
	}

	public void Print()
	{
		for (int i = 0; i < vertices.Count; i++)
		{
			Vertex currentVertex = vertices[i];
			Console.Write($"{currentVertex.Name} - ");

			foreach (Vertex vertex in currentVertex.neighbors)
			{
				Console.Write($"{vertex.Name} ");
			}
			
			Console.WriteLine();
		}
	}

	


}
