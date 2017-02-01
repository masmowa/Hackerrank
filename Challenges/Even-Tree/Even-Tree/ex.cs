/*
    I've used a simple version to count the child edges instead of vertices. 
    Here's the C# code which passed the test cases.
 */
public static int CountChildEdges(Dictionary edges, KeyValuePair edge)
{
    var count = 0;
    foreach (var nextEdge in edges.Where(e =&gt; e.Value.Equals(edge.Key)))
    {
        count++;
        count += CountChildEdges(edges, nextEdge);
    }
    return count;
}