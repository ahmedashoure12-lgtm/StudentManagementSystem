#nullable disable
using System.Reflection.Metadata.Ecma335;
using System;
namespace StudentManagementSystem
{

    class Instructor
    {

        public int InstructorID { get; set; }
        public string Name { get; set; }
        public string Specialization { get; set; }
        public Instructor(int instructorID, string name, string specialization)
        {
            InstructorID = instructorID;
            Name = name;
            Specialization = specialization;
        }
        public string PrintDetails()
        {

            return $"ID:{InstructorID}| Name:{Name}|Sepcialization:{Specialization}";
        }
    }

    class Course
    {
        public int CourseID { get; set; }
        public string Title { get; set; }
        public Instructor Instructor { get; set; }

        public Course(int courseID, string title, Instructor instructor)
        {
            CourseID = courseID;
            Title = title;
            Instructor = instructor;
        }
        public string PrintDetails()
        {
            return $" Course ID: {CourseID}| Titel:{Title}| Instructor: {Instructor.Name}";
        }
    }



    class Student
    {
        public int StudentID { get; set; }
        public string Name { get; set; }
        public int age { get; set; }
        public List<Course> Courses { get; set; }

        public Student(int studentID, string name, int agr)
        {
            StudentID = studentID;
            Name = name;
            age = age;
            Courses = new List<Course>();
        }

        public bool Enroll(Course course)
        {
            if (course != null)
            {
                Courses.Add(course);
                return true;
            }
            else
            {
                return false;
            }
        }
        public string PrintDetails()
        {
            return $"student ID:{StudentID} | Name:{Name}| Age:{age} | Enrolled Courses: {Courses.Count}";

        }
    }


    
    
        class StudentManager
        {
            public List<Student> Students { get; set; }
            public List<Course> Courses { get; set; }
            public List<Instructor> Instructors { get; set; }

            public StudentManager()
            {
                Students = new List<Student>();
                Courses = new List<Course>();
                Instructors = new List<Instructor>();
            }

     
            public bool AddStudent(Student student)
            {
                if (student != null)
                {
                    Students.Add(student);
                    return true;
                }
                return false;
            }

            
            public bool AddCourse(Course course)
            {
                if (course != null)
                {
                    Courses.Add(course);
                    return true;
                }
                return false;
            }

            public bool AddInstructor(Instructor instructor)
            {
                if (instructor != null)
                {
                    Instructors.Add(instructor);
                    return true;
                }
                return false;
            }

            public Student FindStudent(int studentId)
            {
                return Students.Find(s => s.StudentID== studentId);
            }

            public Course FindCourse(int courseId)
            {
                return Courses.Find(c => c.CourseID == courseId);
            }

            public Instructor FindInstructor(int instructorId)
            {
                return Instructors.Find(i => i.InstructorID == instructorId);
            }
            public bool EnrollStudentInCourse(int studentId, int courseId)
            {
                Student student = FindStudent(studentId);
                Course course = FindCourse(courseId);

                if (student != null && course != null)
                {
                    return student.Enroll(course);
                }
                return false;
            }


        public bool RemoveStudent(int studentId)
        {
            Student student = FindStudent(studentId);
            if (student != null)
            {
                Students.Remove(student);
                return true;
            }
            return false;
        }

        public bool RemoveCourse(int courseId)
        {
            Course course = FindCourse(courseId);
            if (course != null)
            {
                Courses.Remove(course);
                return true;
            }
            return false;
        }
    }


        internal class Program
        {

            static void Main(string[] args)
            {
                    StudentManager manager = new StudentManager();
                    bool running = true;

                    while (running)
                    {
                        Console.WriteLine("\n====================================");
                        Console.WriteLine("    Student Management System       ");
                        Console.WriteLine("====================================");
                        Console.WriteLine("1. Add Instructor");
                        Console.WriteLine("2. Add Course");
                        Console.WriteLine("3. Add Student");
                        Console.WriteLine("4. Enroll Student in Course");
                        Console.WriteLine("5. Display All Students");
                        Console.WriteLine("6. Exit");
                        Console.Write("Select an option (1-6): ");

                        string choice = Console.ReadLine();

                        switch (choice)
                        {
                            case "1":
                                Console.Write("Enter Instructor ID: ");
                                int instId = int.Parse(Console.ReadLine());
                                Console.Write("Enter Name: ");
                                string instName = Console.ReadLine();
                                Console.Write("Enter Specialization: ");
                                string spec = Console.ReadLine();

                                manager.AddInstructor(new Instructor(instId, instName, spec));
                                Console.WriteLine("--> Instructor added successfully!");
                                break;

                            case "2":
                                Console.Write("Enter Course ID: ");
                                int cId = int.Parse(Console.ReadLine());
                                Console.Write("Enter Title: ");
                                string title = Console.ReadLine();
                                Console.Write("Enter Instructor ID for this course: ");
                                int cInstId = int.Parse(Console.ReadLine());

                                Instructor inst = manager.FindInstructor(cInstId);
                                if (inst != null)
                                {
                                    manager.AddCourse(new Course(cId, title, inst));
                                    Console.WriteLine("--> Course added successfully!");
                                }
                                else
                                {
                                    Console.WriteLine("--> Error: Instructor not found!");
                                }
                                break;

                            case "3":
                                Console.Write("Enter Student ID: ");
                                int sId = int.Parse(Console.ReadLine());
                                Console.Write("Enter Name: ");
                                string sName = Console.ReadLine();
                                Console.Write("Enter Age: ");
                                int age = int.Parse(Console.ReadLine());

                                manager.AddStudent(new Student(sId, sName, age));
                                Console.WriteLine("--> Student added successfully!");
                                break;

                            case "4":
                                Console.Write("Enter Student ID: ");
                                int enrollStudentId = int.Parse(Console.ReadLine());
                                Console.Write("Enter Course ID: ");
                                int enrollCourseId = int.Parse(Console.ReadLine());

                                if (manager.EnrollStudentInCourse(enrollStudentId, enrollCourseId))
                                {
                                    Console.WriteLine("--> Student enrolled successfully!");
                                }
                                else
                                {
                                    Console.WriteLine("--> Error: Student or Course not found!");
                                }
                                break;

                            case "5":
                                Console.WriteLine("\n--- Registered Students ---");
                                foreach (var student in manager.Students)
                                {
                                    Console.WriteLine(student.PrintDetails());
                                }
                                break;

                            case "6":
                                running = false;
                                Console.WriteLine("Exiting program... Goodbye!");
                                break;


                    case "7":
                        Console.Write("Enter Student ID to Search: ");
                        int searchId = int.Parse(Console.ReadLine());
                        Student foundStudent = manager.FindStudent(searchId);
                        if (foundStudent != null)
                        {
                            Console.WriteLine($"--> Found: {foundStudent.PrintDetails()}");
                        }
                        else
                        {
                            Console.WriteLine("--> Student not found!");
                        }
                        break;

                    case "8":
                        Console.Write("Enter Student ID to Remove: ");
                        int removeId = int.Parse(Console.ReadLine());
                        if (manager.RemoveStudent(removeId))
                        {
                            Console.WriteLine("--> Student removed successfully!");
                        }
                        else
                        {
                            Console.WriteLine("--> Student not found!");
                        }
                        break;




                    default:
                                Console.WriteLine("Invalid option! Please try again.");
                                break;
                        }
                    }
                


            }

        }
    
}

     

    

