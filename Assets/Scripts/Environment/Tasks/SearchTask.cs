using UnityEngine;
using System;
namespace Environment.Tasks {
    [CreateAssetMenu(menuName = "Tasks/Search Employees")]
    public class SearchTask : Task {

        public override object ExecuteTask(object input) {
            if(input is not Employee[] employees) {
                Debug.LogError("Received no employee array!");
                return null;
            }
            //Console.Clear();

            DateTime firstDate = DateTime.Parse("1970-01-01T00:00:00");
            DateTime secondDate = DateTime.Parse("2234-08-07T15:37:17");

            int startArrayLength = employees.Length;
            int startIndex = 0;
            int endIndex = startArrayLength - 1;
            //DateTime firstInterval = DateTime.Parse(BinarySearch(firstDate, employees, startIndex, endIndex));
            //DateTime secondInterval = DateTime.Parse(BinarySearch(secondDate, employees, startIndex, endIndex));

            int entryIndex = LowerBound(firstDate, employees);
            int exitIndex = UpperBound(secondDate, employees) - 1;

            if(entryIndex == -1 || exitIndex == -1) {
                Debug.LogError("One or both dates were not found!");
                return null;
            }

            if(entryIndex > exitIndex) {
                Debug.LogError("The starting date is after the ending date!");
                return null;
            }


            PrintList(employees,entryIndex,exitIndex);

            return null;
        }

        public void PrintList(Employee[] employees, int entryIndex, int exitIndex) {

            while(entryIndex <= exitIndex) {

                Debug.Log(employees[entryIndex].name);
                Debug.Log(employees[entryIndex].lastEntranceInEngineRoom);
                entryIndex++;
            }

            
        }

        //public int findIndex(Employee[] employees, DateTime indexDateToFind) {

        //    int index = 0;
        //    while(employees[index].lastEntranceInEngineRoom != indexDateToFind) {  index++; }

        //    return index;

        //}


        public int LowerBound(DateTime targetDate, Employee[] employees) {

            int left = 0;
            int right = employees.Length;

            while(left < right) {

                int middle = (left + right) / 2;

                if(employees[middle].lastEntranceInEngineRoom < targetDate) {
                    left = middle + 1;
                }
                else {
                    right = middle;
                }
            }

            return left;
        }

        public int UpperBound(DateTime targetDate, Employee[] employees) {

            int left = 0;
            int right = employees.Length;

            while(left < right) {

                int middle = (left + right) / 2;

                if(employees[middle].lastEntranceInEngineRoom <= targetDate) {
                    left = middle + 1;
                }
                else {
                    right = middle;
                }
            }

            return left;
        }



    }

}
