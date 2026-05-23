using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Add three items with different priorities and remove one.
    // Expected Result: The item with the highest priority (5) should be removed first.
    // Defect(s) Found: Dequeue did not correctly identify the highest priority item.
    public void TestPriorityQueue_1()
    {
        var pq = new PriorityQueue();

        pq.Enqueue("A", 1);
        pq.Enqueue("B", 5);
        pq.Enqueue("C", 3);

        var result = pq.Dequeue();

        Assert.AreEqual("B", result);
    }

    [TestMethod]
    // Scenario: Add three items with the same priority and remove one.
    // Expected Result: When priorities match, the queue should behave FIFO and return the first item added.
    // Defect(s) Found: Dequeue did not respect FIFO order for equal priorities.
    public void TestPriorityQueue_2()
    {
        var pq = new PriorityQueue();

        pq.Enqueue("A", 5);
        pq.Enqueue("B", 5);
        pq.Enqueue("C", 5);

        var result = pq.Dequeue();

        Assert.AreEqual("A", result);
    }

    [TestMethod]
    // Scenario: Remove from an empty queue.
    // Expected Result: Should throw InvalidOperationException with message "The queue is empty."
    // Defect(s) Found: Exception type or message incorrect.
    public void TestPriorityQueue_Empty()
    {
        var pq = new PriorityQueue();

        try
        {
            pq.Dequeue();
            Assert.Fail("Expected exception was not thrown.");
        }
        catch (InvalidOperationException ex)
        {
            Assert.AreEqual("The queue is empty.", ex.Message);
        }
    }
}
