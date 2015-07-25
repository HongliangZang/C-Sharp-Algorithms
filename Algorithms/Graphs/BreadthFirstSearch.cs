﻿using System;
using System.Collections.Generic;

using DataStructures.Graphs;

namespace Algorithms.Graphs
{
	public static class BreadthFirstSearch
	{
		/// <summary>
		/// Iterative BFS implementation.
		/// Traverses all the nodes in a graph starting from a specific node, applying the passed action to every node.
		/// </summary>
		public static void VisitAll<T> (ref IUndirectedGraph<T> Graph, T StartVertex, Action<T> Action) where T : IComparable<T>
		{
			if (Graph.VerticesCount == 0)
				return;

			if (!Graph.HasVertex (StartVertex))
				throw new Exception ("Starting vertex doesn't belong to graph.");

			int level = 0;													// keeps track of levels
			var frontiers = new List<T>();									// keeps track of previous levels, i - 1
			var levels = new Dictionary<T, int>(Graph.VerticesCount);		// keeps track of visited nodes
			var parents = new Dictionary<T, object>(Graph.VerticesCount);	// keeps track of tree-nodes

			frontiers.Add (StartVertex);
			levels.Add (StartVertex, 0);
			parents.Add (StartVertex, null);

			// BFS VISIT CURRENT NODE
			Action(StartVertex);

			// TRAVERSE GRAPH
			while (frontiers.Count > 0) 
			{
				var next = new List<T> ();									// keeps track of the current level, i

				foreach (var node in frontiers) 
				{
					foreach (var adjacent in Graph.Neighbours(node)) 
					{
						if (!levels.ContainsKey (adjacent)) 				// not visited yet
						{
							// BFS VISIT NODE STEP
							Action (adjacent);

							levels.Add (adjacent, level);					// level[node] + 1
							parents.Add (adjacent, node);
							next.Add (adjacent);
						}
					}
				}

				frontiers = next;
				level = level + 1;
			}
		}

		/// <summary>
		/// Iterative BFS Implementation.
		/// Given a predicate function and a starting node, this function searches the nodes of the graph for a first match.
		/// </summary>
		public static T FindFirstMatch<T> (IUndirectedGraph<T> Graph, T StartVertex, Predicate<T> Match) where T : IComparable<T>
		{
			if (Graph.VerticesCount == 0)
				throw new Exception ("Graph is empty!");

			if (!Graph.HasVertex (StartVertex))
				throw new Exception ("Starting vertex doesn't belong to graph.");

			int level = 0;													// keeps track of levels
			var frontiers = new List<T>();									// keeps track of previous levels, i - 1
			var levels = new Dictionary<T, int>(Graph.VerticesCount);		// keeps track of visited nodes
			var parents = new Dictionary<T, object>(Graph.VerticesCount);	// keeps track of tree-nodes

			frontiers.Add (StartVertex);
			levels.Add (StartVertex, 0);
			parents.Add (StartVertex, null);

			// BFS VISIT CURRENT NODE
			if (Match (StartVertex))
				return StartVertex;

			// TRAVERSE GRAPH
			while (frontiers.Count > 0) 
			{
				var next = new List<T> ();									// keeps track of the current level, i

				foreach (var node in frontiers) 
				{
					foreach (var adjacent in Graph.Neighbours(node)) 
					{
						if (!levels.ContainsKey (adjacent)) 				// not visited yet
						{
							// BFS VISIT NODE STEP
							if (Match (adjacent))
								return adjacent;

							levels.Add (adjacent, level);					// level[node] + 1
							parents.Add (adjacent, node);
							next.Add (adjacent);
						}
					}
				}

				frontiers = next;
				level = level + 1;
			}

			throw new Exception ("Item was not found!");
		}

	}

}

