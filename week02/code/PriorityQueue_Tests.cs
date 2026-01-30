using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{

    [TestMethod]
    public void TestPriorityQueue_RemovesHighestPriority()
    {
        // Scenario: Enqueue multiple items with different priorities.
        // Expected Result: Dequeue returns the highest priority item.
        // Defect(s) Found:

        var pq = new PriorityQueue();
        pq.Enqueue("A", 1);
        pq.Enqueue("B", 5);
        pq.Enqueue("C", 3);

        Assert.AreEqual("B", pq.Dequeue());
    }

    [TestMethod]
    public void TestPriorityQueue_TieUsesFIFO()
    {
        // Scenario: Two items have the same highest priority.
        // Expected Result: Dequeue removes the one that was enqueued first (FIFO).
        // Defect(s) Found:

        var pq = new PriorityQueue();
        pq.Enqueue("A", 5);
        pq.Enqueue("B", 1);
        pq.Enqueue("C", 5);

        Assert.AreEqual("A", pq.Dequeue());
    }


    // Add more test cases as needed below.
}