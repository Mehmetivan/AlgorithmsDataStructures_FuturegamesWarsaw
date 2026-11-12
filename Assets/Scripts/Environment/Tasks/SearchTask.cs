using System;
using System.Diagnostics;
using UnityEngine;
namespace Environment.Tasks {
    [CreateAssetMenu(menuName = "Tasks/Search Employees")]
    public class SearchTask : Task<Employee[]> {

        public override object ExecuteTask(object input) {
            if(input is not Employee[] employees) {
                UnityEngine.Debug.LogError("Received no employee array!");
                return null;
            }
            //Console.Clear();

            DateTime firstDate = DateTime.Parse("1970-01-01T00:00:00");
            DateTime secondDate = DateTime.Parse("1970-01-01T00:00:00");

            int startArrayLength = employees.Length;
            int startIndex = 0;
            int endIndex = startArrayLength - 1;
            //DateTime firstInterval = DateTime.Parse(BinarySearch(firstDate, employees, startIndex, endIndex));
            //DateTime secondInterval = DateTime.Parse(BinarySearch(secondDate, employees, startIndex, endIndex));

            Stopwatch stopwatch = Stopwatch.StartNew();

            int entryIndex = LowerBound(firstDate, employees);
            int exitIndex = UpperBound(secondDate, employees) ;

            stopwatch.Stop();

            UnityEngine.Debug.Log($"Binary Search Time: {stopwatch.ElapsedTicks} ticks");
            UnityEngine.Debug.Log($"Matching employees: {exitIndex - entryIndex}");

            if(entryIndex == -1 || exitIndex == -1) {
                UnityEngine.Debug.LogError("One or both dates were not found!");
                return null;
            }

            if(entryIndex > exitIndex) {
                UnityEngine.Debug.LogError("The starting date is after the ending date!");
                return null;
            }


            PrintList(employees,entryIndex,exitIndex);

            return employees;
        }

        public override Employee[] Execute() {
            return null;
        }

        public void PrintList(Employee[] employees, int entryIndex, int exitIndex) {

            while(entryIndex <= exitIndex) {

                UnityEngine.Debug.Log(employees[entryIndex].name);
                UnityEngine.Debug.Log(employees[entryIndex].lastEntranceInEngineRoom);
                entryIndex++;
            }

            
        }

        //public int findIndex(Employee[] employees, DateTime indexDateToFind) {

        //    int index = 0;
        //    while(employees[index].lastEntranceInEngineRoom != indexDateToFind) {  index++; }

        //    return index;

        //}

        //public int BinarySearch(string dateToFind, Employee[] employees, int startIndex, int endIndex) {

        //    if(startIndex > endIndex) {
        //        return -1;
        //    }

        //    DateTime targetDate = DateTime.Parse(dateToFind);

        //    int middleIndex = (startIndex + endIndex) / 2;

        //    DateTime middleDate = employees[middleIndex].lastEntranceInEngineRoom;

        //    if(middleDate == targetDate) {
        //        return middleIndex;
        //    }
        //    else if(targetDate < middleDate) {
        //        return BinarySearch(dateToFind, employees, startIndex, middleIndex - 1);
        //    }
        //    else {
        //        return BinarySearch(dateToFind, employees, middleIndex + 1, endIndex);
        //    }
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
