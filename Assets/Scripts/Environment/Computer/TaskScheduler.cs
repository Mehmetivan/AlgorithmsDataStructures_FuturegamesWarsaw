using Environment.Tasks;
using UnityEngine;

public class TaskScheduler : MonoBehaviour {
    private MinHeap queue;

    [SerializeField] private Task testTask1;
    [SerializeField] private Task testTask2;
    [SerializeField] private Task testTask3;
    [SerializeField] private Task testTask4;

    private void Awake() {
        queue = new MinHeap(100);

        if(testTask1 == null)
            Debug.LogError("Test Task 1 is not assigned!");

        if(testTask2 == null)
            Debug.LogError("Test Task 2 is not assigned!");

        if(testTask3 == null)
            Debug.LogError("Test Task 3 is not assigned!");

        if(testTask4 == null)
            Debug.LogError("Test Task 4 is not assigned!");

        if(testTask1 != null)
            queue.Insert(testTask1, 1);

        if(testTask2 != null)
            queue.Insert(testTask2, 2);

        if(testTask3 != null)
            queue.Insert(testTask3, 3);

        if(testTask4 != null)
            queue.Insert(testTask4, 4);
    }

    public bool AddTask(Task task, int priority) {
        return queue.Insert(task, priority);
    }


    private object previousTaskResult = null;

    public void ExecuteNextTask() {
        if(queue.current_heap_size == 0) {
            Debug.Log("No tasks in queue.");
            return;
        }

        Task task = queue.ExtractMin();

        previousTaskResult = task.ExecuteTask(previousTaskResult);
    }
}
