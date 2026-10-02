using System;
using System.Collections;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // declare an empty courses array
        string[] courses = new string[0];
        // declare an empty list assignments
        List<string> assignments = new List<string>();
        // declare an empty dictionary assignmentDetails
        Dictionary<string, string> assignmentDetails = new Dictionary<string, string>();

        bool running = true;

        while (running)
        {
            // print main menu
            Console.WriteLine("\nASSIGNMENT TRACKER");
            Console.WriteLine("1. Create Course (Array)");
            Console.WriteLine("2. Update Course (Array)");
            Console.WriteLine("3. Add Assignment (List)");
            Console.WriteLine("4. Update Assignment (List)");
            Console.WriteLine("5. Remove Assignment by Index (List)");
            Console.WriteLine("6. Add or Update Assignment Details (Dictionary)");
            Console.WriteLine("7. Remove Assignment by Name (List and Dictionary)");
            Console.WriteLine("8. Exit");
            Console.WriteLine("Please choose:");
            int choice = Convert.ToInt16(Console.ReadLine());

            if (choice == 1)
            {
                // Ask for the number of courses;
                Console.WriteLine("How many courses you are taking?");
                int numberOfCourses = Convert.ToInt16(Console.ReadLine());
                // create string[numberOfCourses];
                courses = new string[numberOfCourses];
                // use a for loop to capture each course name;
                for (int i = 0; i < courses.Length; i++)
                {
                    Console.Write($"Course {i}: ");
                    courses[i] = Console.ReadLine();
                }
                // display index and value of the array.
                Console.WriteLine("\nCurrent Course Array:");
                for (int i = 0; i < courses.Length; i++)
                {
                    Console.WriteLine($"Course {i}: {courses[i]}");
                }
            }
            else if (choice == 2)
            {
                // If the array is empty, direct the user to Option 1.
                if (courses.Length == 0)
                {
                    Console.WriteLine("The course array has not been created. Please use Option 1 first.");
                }
                else
                {
                    // display courses
                    Console.WriteLine("\nCurrent Course Array:");
                    for (int i = 0; i < courses.Length; i++)
                    {
                        Console.WriteLine($"Course {i}: {courses[i]}");
                    }
                    // request an index
                    Console.WriteLine("Please enter the course index to update:");
                    int courseIndex = Convert.ToInt16(Console.ReadLine());
                    // validate bounds
                    if (courseIndex >= 0 && courseIndex < courses.Length)
                    {
                        // replace the selected course
                        Console.WriteLine("Please enter the new course name:");
                        courses[courseIndex] = Console.ReadLine();
                        // display the updated array
                        Console.WriteLine("\nUpdated Course Array:");
                        for (int i = 0; i < courses.Length; i++)
                        {
                            Console.WriteLine($"Course {i}: {courses[i]}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid course index.");
                    }
                }
            }
            else if (choice == 3)
            {
                // Display current assignments.
                Console.WriteLine("\nCurrent assignment list:");
                if (assignments.Count == 0)
                {
                    Console.WriteLine("No assignment found.");
                }
                else
                {
                    for (int i = 0; i < assignments.Count; i++)
                    {
                        Console.WriteLine($"{i}: {assignments[i]}");
                    }
                }

                string enterMore = "y";
                while (enterMore == "y")
                {
                    // Repeatedly request a name and call Add() while the user enters y.
                    Console.WriteLine("Please enter an assignment name:");
                    string name = Console.ReadLine();
                    assignments.Add(name);
                    Console.WriteLine("Do you want to add another assignment? (y/n):");
                    enterMore = Console.ReadLine().ToLower();
                }

                // Display the final List.
                Console.WriteLine("\nCurrent assignment list:");
                for (int i = 0; i < assignments.Count; i++)
                {
                    Console.WriteLine($"{i}: {assignments[i]}");
                }
            }
            else if (choice == 4)
            {
                // Display current assignments with index
                Console.WriteLine("\nCurrent assignment list:");
                for (int i = 0; i < assignments.Count; i++)
                {
                    Console.WriteLine($"{i}: {assignments[i]}");
                }
                // request a valid index
                Console.WriteLine("Please enter the assignment index to update:");
                int assignmentIndex = Convert.ToInt16(Console.ReadLine());

                if (assignmentIndex >= 0 && assignmentIndex < assignments.Count)
                {
                    string oldName = assignments[assignmentIndex];
                    Console.WriteLine("Please enter the new assignment name:");
                    string newName = Console.ReadLine();
                    // replace the List item
                    assignments[assignmentIndex] = newName;

                    // If the old name exists as a Dictionary key, move its value to the new key.
                    if (assignmentDetails.ContainsKey(oldName))
                    {
                        assignmentDetails[newName] = assignmentDetails[oldName];
                        assignmentDetails.Remove(oldName);
                    }

                    // display the updated List
                    Console.WriteLine("\nUpdated assignment list:");
                    for (int i = 0; i < assignments.Count; i++)
                    {
                        Console.WriteLine($"{i}: {assignments[i]}");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid assignment index.");
                }
            }
            else if (choice == 5)
            {
                // Display the current assignment list
                Console.WriteLine("\nCurrent assignment list:");
                for (int i = 0; i < assignments.Count; i++)
                {
                    Console.WriteLine($"{i}: {assignments[i]}");
                }
                // request an index
                Console.WriteLine("Please enter the assignment index to remove:");
                int removeIndex = Convert.ToInt16(Console.ReadLine());
                // validate bounds
                if (removeIndex >= 0 && removeIndex < assignments.Count)
                {
                    // remove with RemoveAt()
                    assignments.RemoveAt(removeIndex);
                    // display the updated List
                    Console.WriteLine("\nUpdated assignment list:");
                    for (int i = 0; i < assignments.Count; i++)
                    {
                        Console.WriteLine($"{i}: {assignments[i]}");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid assignment index.");
                }
            }
            else if (choice == 6)
            {
                // Display current details;
                Console.WriteLine("Current Dictionary:");
                foreach (KeyValuePair<string, string> item in assignmentDetails)
                {
                    Console.WriteLine($"{item.Key}: {item.Value}");
                }
                // request assignment name, description, and status;
                Console.WriteLine("Please enter assignment name (key):");
                string assignmentName = Console.ReadLine();
                Console.WriteLine("Please enter assignment description:");
                string description = Console.ReadLine();
                Console.WriteLine("Please enter assignment status:");
                string status = Console.ReadLine();
                // store description + " - " + status as value and the assignment name as key;
                string assignmentValue = description + " - " + status;
                assignmentDetails[assignmentName] = assignmentValue;
                // display the updated assignment details.
                Console.WriteLine("The Updated Dictionary:");
                foreach (KeyValuePair<string, string> item in assignmentDetails)
                {
                    Console.WriteLine($"{item.Key}: {item.Value}");
                }
            }
            else if (choice == 7)
            {
                // Display the current assignment list
                Console.WriteLine("\nCurrent assignment list:");
                for (int i = 0; i < assignments.Count; i++)
                {
                    Console.WriteLine($"{i}: {assignments[i]}");
                }
                // request an assignment name and remove it with List.Remove()
                Console.WriteLine("Please enter the assignment name to remove:");
                string removeName = Console.ReadLine();
                bool removed = assignments.Remove(removeName);
                // Display the result and updated List.
                if (removed)
                {
                    Console.WriteLine($"{removeName} was removed from the list.");
                }
                else
                {
                    Console.WriteLine("Assignment not found.");
                }
                Console.WriteLine("\nUpdated assignment list:");
                for (int i = 0; i < assignments.Count; i++)
                {
                    Console.WriteLine($"{i}: {assignments[i]}");
                }

                // Ask whether a Dictionary key should also be removed.
                Console.WriteLine("Do you also want to remove a Dictionary entry? (y/n):");
                string removeDict = Console.ReadLine().ToLower();
                if (removeDict == "y")
                {
                    Console.WriteLine("Please enter the Dictionary key to remove:");
                    string keyToRemove = Console.ReadLine();
                    if (assignmentDetails.Remove(keyToRemove))
                    {
                        Console.WriteLine("The Updated Dictionary:");
                        foreach (KeyValuePair<string, string> item in assignmentDetails)
                        {
                            Console.WriteLine($"{item.Key}: {item.Value}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Dictionary key not found.");
                    }
                }
            }
            else if (choice == 8)
            {
                Console.WriteLine("Good work!");
                running = false;
            }
            else
            {
                // invalid choice message
                Console.WriteLine("Invalid option. Choose 1-8.");
            }
        }
    }
}
