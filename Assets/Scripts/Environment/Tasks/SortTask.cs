using UnityEngine;
using UnityEngine.UIElements;

namespace Environment.Tasks {
    [CreateAssetMenu(menuName = "Tasks/Sort Employees")]
    public class SortTask : Task {
        public override object ExecuteTask(object input) {
            if(input is not Employee[] employees) {
                Debug.LogError("Received no employee array!");
                return null;
            }

            QuickSort(employees, 0, employees.Length - 1);
            PrintList(employees);

            return null;
        }


        public void PrintList(Employee[] employees) {
            foreach(Employee employee in employees) {
                Debug.Log(
                    "Name: " + employee.name +
                    ", ID: " + employee.employeeId +
                    ", Clearance: " + employee.hasEngineRoomClearance +
                    ", Last Entrance: " + employee.lastEntranceInEngineRoom +
                    ", Last Exit: " + employee.lastExitFromEngineRoom
                );
            }
        }


        public void Swap(Employee[] employees, int index1, int index2) {
            Employee temp = employees[index1];
            employees[index1] = employees[index2];
            employees[index2] = temp;
        }

        public int QuickSort(Employee[] employees, int start, int end) {

            if(end <= start) {
                return start;
            }

            int pivotIndex = end;
            Employee pivot = employees[pivotIndex];

            int i = start - 1;
            int j = start;


            for(j = start; j < pivotIndex; j++) {


                if(employees[j].lastEntranceInEngineRoom <= pivot.lastEntranceInEngineRoom) {
                    
                }
                else if(employees[j].lastEntranceInEngineRoom > pivot.lastEntranceInEngineRoom) {
                    i++;
                    Swap(employees, i, j);
                   
                }
            }
            i++;
            Swap(employees, i, pivotIndex);

            QuickSort(employees, start, i - 1);
            QuickSort(employees, i + 1, end);

            return i;




        }

    }
}


