using System;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

namespace Environment.Tasks {
    [CreateAssetMenu(menuName = "Tasks/BTS")]
    public class BTSTask : Task {

        [SerializeField]
   
        private string startDate = "2024-05-10T10:00:00";

        [SerializeField]
        private string endDate = "2024-05-12T10:00:00";
        private class Node {
            public Employee employee;
            public Node left;
            public Node right;
            public Node(Employee employee) {
                this.employee = employee;
                left = null;
                right = null;
            }
        }
        private Node root;


        public override object ExecuteTask(object input = null) {

            if(input is not Employee[] employees) {
                UnityEngine.Debug.LogError("Received no employee array!");
                return null;
            }

            // Start with an empty tree.
            root = null;

            // Insert every employee into the BST.
            foreach(Employee employee in employees) {
                Insert(employee);
            }

            UnityEngine.Debug.Log($"Inserted {employees.Length} employees into the BST.");
            Stopwatch stopwatch = Stopwatch.StartNew();

            List<Employee> results = new List<Employee>();

            SearchRange(
                root,
                DateTime.Parse(startDate),
                DateTime.Parse(endDate),
                results
            );

            stopwatch.Stop();

            UnityEngine.Debug.Log($"Found {results.Count} employees.");

            foreach(Employee employee in results) {
                UnityEngine.Debug.Log(
                    $"Name: {employee.name}, ID: {employee.employeeId}, " +
                    $"Entry: {employee.lastEntranceInEngineRoom}"
                );
            }

            UnityEngine.Debug.Log($"BST Range Search Time: {stopwatch.ElapsedTicks} ticks");




            return employees;
        }

        private void Insert(Employee employee) {
            if(root == null) {
                root = new Node(employee);
                return;
            }
            Node current = root;
            while(true) {

                int comparison = DateTime.Compare(employee.lastEntranceInEngineRoom, current.employee.lastEntranceInEngineRoom);
                if(comparison < 0) {
                    if(current.left == null) {
                        current.left = new Node(employee);
                        return;
                    }
                    current = current.left;
                }
                else {
                    if(current.right == null) {
                        current.right = new Node(employee);
                        return;
                    }
                    current = current.right;
                }
            }

        }

        private void SearchRange(
            Node current,
            DateTime startDate,
            DateTime endDate,
            List<Employee> results
        ) {
                    if(current == null) {
                        return;
                    }

                    DateTime currentDate = current.employee.lastEntranceInEngineRoom;

                    if(currentDate >= startDate) {
                        SearchRange(current.left, startDate, endDate, results);
                    }

                    if(currentDate >= startDate && currentDate <= endDate) {
                        results.Add(current.employee);
                    }

                    if(currentDate <= endDate) {
                        SearchRange(current.right, startDate, endDate, results);
                    }
                }


        public Employee Search(DateTime targetDate) {

            Node current = root;

            while(current != null) {

                int comparison = DateTime.Compare(
                    targetDate,
                    current.employee.lastEntranceInEngineRoom
                );

                if(comparison == 0) {
                    return current.employee;
                }

                if(comparison < 0) {
                    current = current.left;
                }
                else {
                    current = current.right;
                }
            }

            return null;
        }



    }
}


