using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Routine_Generator
{
    public class Processor
    {
        public static string GetCourseName(string CourseCode)
        {
            if (CourseCode.Contains("SWE112"))
                return "Computer Fundamentals With Lab";
            else if (CourseCode.Contains("SWE111"))
                return "Introduction to Software Engineering";
            else if (CourseCode.Contains("PHY114"))
                return "Physics With Lab";
            else if (CourseCode.Contains("ENG123"))
                return "English Language";
            else if (CourseCode.Contains("MAT113"))
                return "Mathemetics-I";
            else if (CourseCode.Contains("SWE121"))
                return "Software Requirements Analysis and Design";
            else if (CourseCode.Contains("SWE122"))
                return "Programming Language with Lab-C";
            else if (CourseCode.Contains("MAT221"))
                return "Mathemetics-II";
            else if (CourseCode.Contains("SWE231"))
                return "Software Engineering Project-I (C)";
            else if (CourseCode.Contains("SWE133"))
                return "Data Structure with Lab";
            else if (CourseCode.Contains("STA134"))
                return "Statistics and Probabilities";
            else if (CourseCode.Contains("SWE132"))
                return "Java Programming with Lab";
            else if (CourseCode.Contains("SWE213"))
                return "Computer Algorithms with Lab";
            else if (CourseCode.Contains("SWE211"))
                return "Introduction to Database with Lab";
            else if (CourseCode.Contains("SWE233"))
                return "Object Oriented Design with Lab";
            else if (CourseCode.Contains("SWE222"))
                return "Software Engineering QA and Testing";
            else if (CourseCode.Contains("SWE223"))
                return "Digital Electronics with Lab";
            else if (CourseCode.Contains("SWE224"))
                return "Discrete Mathemetics with Lab";
            else if (CourseCode.Contains("SWE131"))
                return "Documentation of Software Engineering";
            else if (CourseCode.Contains("SWE232"))
                return "Operating System With Lab";
            else if (CourseCode.Contains("SWE212"))
                return "Software Project Management";
            else if (CourseCode.Contains("ACC124"))
                return "Principle of Accounting";
            else if (CourseCode.Contains("SWE323"))
                return "System Analysis and Design";
            else if (CourseCode.Contains("SWE312"))
                return "Theory of Computing";
            else if (CourseCode.Contains("SWE322"))
                return "Software Security";
            else if (CourseCode.Contains("SWE313"))
                return ".NET Programming with Lab";
            else if (CourseCode.Contains("SWE321"))
                return "Data Communication with Lab";
            else if (CourseCode.Contains("SWE333"))
                return "Desktop and Web Programming";
            else if (CourseCode.Contains("SWE311"))
                return "Computer Architechture and Organizations";
            else if (CourseCode.Contains("SWE413"))
                return "Software Engineering and Cyber Laws";
            else if (CourseCode.Contains("SWE412"))
                return "Management Information System";
            else if (CourseCode.Contains("SWE331"))
                return "Object Oriented Software Development";
            else if (CourseCode.Contains("SWE422"))
                return "Numerical Analysis with Lab";
            else if (CourseCode.Contains("SWE424"))
                return "Artificial Intelligence with Lab";
            else if (CourseCode.Contains("SWE423"))
                return "Advance Database with Lab";
            else if (CourseCode.Contains("SWE425"))
                return "Telecommunication Engineering with Lab";
            else if (CourseCode.Contains("SWE426"))
                return "Distributive Computing and Network Security with Lab";
            else if (CourseCode.Contains("SWE332"))
                return "Software Engineering Project-II (Web Programming)";
            else if (CourseCode.Contains("SWE435"))
                return "Business Communication";
            else if (CourseCode.Contains("SWE438"))
                return "Internet Marketing with Lab";
            else if (CourseCode.Contains("SWE439"))
                return "Project/Thesis";

            else
                return "";
        }
    }
}