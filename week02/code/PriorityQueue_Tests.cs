using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario:
    // Enqueue three items with different priorities and dequeue them all.
    // Expected Result:
    // Items should be removed in order of highest priority first.
    // Defect(s) Found:
    // - The dequeue method did not remove items from the queue.
    // - The last element in the queue was never considered.
    public void TestPriorityQueue_HighestPriorityFirst()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Low", 1);
        priorityQueue.Enqueue("Medium", 5);
        priorityQueue.Enqueue("High", 10);

        Assert.AreEqual("High", priorityQueue.Dequeue());
        Assert.AreEqual("Medium", priorityQueue.Dequeue());
        Assert.AreEqual("Low", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario:
    // Enqueue multiple items with the same highest priority.
    // Expected Result:
    // Items with equal priority should be dequeued in FIFO order.
    // Defect(s) Found:
    // - Items with equal priority were dequeued in LIFO order
    //   due to use of >= instead of >.
    public void TestPriorityQueue_FIFOForSamePriority()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("First", 5);
        priorityQueue.Enqueue("Second", 5);
        priorityQueue.Enqueue("Third", 5);

        Assert.AreEqual("First", priorityQueue.Dequeue());
        Assert.AreEqual("Second", priorityQueue.Dequeue());
        Assert.AreEqual("Third", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario:
    // Attempt to dequeue from an empty queue.
    // Expected Result:
    // An InvalidOperationException with the message "The queue is empty."
    // Defect(s) Found:
    // - No defects found. Exception behavior was correct.
    public void TestPriorityQueue_EmptyQueue()
    {
        var priorityQueue = new PriorityQueue();

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
    }
}
