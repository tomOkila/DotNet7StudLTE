using DotNet7StudLTE.BusLogic;
using DotNet7StudLTE.Helpers;
using DotNet7StudLTE.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DotNet7StudLTE.Controllers
{
    public class StudentController : Controller
    {
        //get student list
        public IActionResult Index()
        {
            //get student data
            List<Student> studentDetails = new List<Student>();
            try
            {
                // get student information
                var getStudents = StudLogic.GetStudentData();
                studentDetails = HtmlHelpers.ConvertDataTable<Student>(getStudents);


            }
            catch (Exception ex)
            {

            }
            return View(studentDetails.ToList());
        }


        //create student view
        public IActionResult Create()
        {
            //pull the the department details to be displayed on the dropdown.
            Student stud = new Student();
            var getDepartment = StudLogic.GetStudentDepartmentData();
            var deptDetails = HtmlHelpers.ConvertDataTable<Department>(getDepartment);

            ViewData["DepartmentID"] = new SelectList(deptDetails, "DeptID", "DepartmentName");
            return View(stud);
        }

        //create student request
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("FirstName,Surname,DepartmentID,Birthday")] Student student)
        {
            if (string.IsNullOrEmpty(student.FirstName) ||
                string.IsNullOrEmpty(student.Surname))
            {
                TempData["TransError"] = "Please fill all the details correctly before submitting the form";
                return RedirectToAction(nameof(Create));
            }

            if (ModelState.IsValid)
            {
                //save student to database
                var saveStudent = StudLogic.SaveNewStudentData(student.StudentID, student.FirstName, student.Surname, student.DepartmentID, student.Birthday);
                //if the user already exists
                if (saveStudent == -1)
                {
                    TempData["TransError"] = "User " + student.FirstName + " " + student.Surname + " already exists in the system";
                    return RedirectToAction(nameof(Create));
                }
                //new user created successfully
                else if (saveStudent > 0)
                {
                    TempData["TransMessage"] = "User " + student.FirstName + "." + student.Surname + " created successfully";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["TransError"] = "Error occurred while creating user:" + student.FirstName + "." + student.Surname + "";
                    return RedirectToAction(nameof(Create));
                }
            }
            //any other error
            else
            {
                TempData["TransError"] = "Error occurred while creating user:" + student.FirstName + "." + student.Surname + "";
            }

            return RedirectToAction(nameof(Create));
        }

        //edit view
        public IActionResult Edit(int id)
        {
            //pull the the department details to be displayed on the dropdown.
            Student stud = new Student();

            //get student details by ID passed
            var saveStudent = StudLogic.GetStudentDepartmentDataById(id);
            if (saveStudent.Rows.Count > 0)
            {
                stud.StudentID = Convert.ToInt32(saveStudent.Rows[0]["StudentID"]);
                stud.FirstName = saveStudent.Rows[0]["FirstName"].ToString();
                stud.Surname = saveStudent.Rows[0]["Surname"].ToString();
                stud.Birthday = Convert.ToDateTime((saveStudent.Rows[0]["BirthDay"]));
                stud.DepartmentID = Convert.ToInt32(saveStudent.Rows[0]["DeptID"]);
            }


            var getDepartment = StudLogic.GetStudentDepartmentData();
            var deptDetails = HtmlHelpers.ConvertDataTable<Department>(getDepartment);

            ViewData["DepartmentID"] = new SelectList(deptDetails, "DeptID", "DepartmentName", stud.DepartmentID);
            return View(stud);
        }

        //post edit request
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([Bind("StudentID,FirstName,Surname,DepartmentID,Birthday")] Student student)
        {
            if (ModelState.IsValid)
            {
                //save student to database
                var saveStudent = StudLogic.SaveNewStudentData(student.StudentID, student.FirstName, student.Surname, student.DepartmentID, student.Birthday);
                //if the user already exists
                if (saveStudent == -1)
                {
                    TempData["TransError"] = "User " + student.FirstName + " " + student.Surname + " already exists in the system";
                }
                //new user created successfully
                else if (saveStudent > 0)
                {
                    TempData["TransMessage"] = "User " + student.FirstName + "." + student.Surname + " updated successfully";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["TransError"] = "Error occurred while updating user:" + student.FirstName + "." + student.Surname + "";
                }
            }
            //any other error
            else
            {
                TempData["TransError"] = "Error occurred while creating user:" + student.FirstName + "." + student.Surname + "";
            }

            return RedirectToAction(nameof(Edit));
        }


        public IActionResult Details(int id)
        {
            //pull the the department details to be displayed on the dropdown.
            ViewData["StatusMessage"] = TempData["StatusMessage"];
            Student stud = new Student();

            //get student details by ID passed
            var saveStudent = StudLogic.GetStudentDepartmentDataById(id);
            if (saveStudent.Rows.Count > 0)
            {
                stud.StudentID = Convert.ToInt32(saveStudent.Rows[0]["StudentID"]);
                stud.FirstName = saveStudent.Rows[0]["FirstName"].ToString();
                stud.Surname = saveStudent.Rows[0]["Surname"].ToString();
                stud.Birthday = Convert.ToDateTime((saveStudent.Rows[0]["BirthDay"]));
                stud.DepartmentID = Convert.ToInt32(saveStudent.Rows[0]["DeptID"]);
                stud.DepartmentName = saveStudent.Rows[0]["DepartmentName"].ToString();
            }

            return View(stud);
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            if (id==null)
            {
                //an error was encountered.
                TempData["TransError"] = "Error occurred while fetching branch data";
            }

            //post account data
            System.Data.DataTable dataTableStudent = new System.Data.DataTable();
            dataTableStudent = StudLogic.GetStudentDepartmentDataById(id);
            Student stud = new Student();
            if (dataTableStudent.Rows.Count > 0)
            {
                stud.StudentID = Convert.ToInt32(dataTableStudent.Rows[0]["StudentID"]);
                stud.FirstName = dataTableStudent.Rows[0]["FirstName"].ToString();
                stud.Surname = dataTableStudent.Rows[0]["Surname"].ToString();
                stud.Birthday = Convert.ToDateTime((dataTableStudent.Rows[0]["BirthDay"]));
                stud.DepartmentID = Convert.ToInt32(dataTableStudent.Rows[0]["DeptID"]);
                stud.DepartmentName = dataTableStudent.Rows[0]["DepartmentName"].ToString();
            }


            var getDepartment = StudLogic.GetStudentDepartmentData();
            var deptDetails = HtmlHelpers.ConvertDataTable<Department>(getDepartment);

            ViewData["DepartmentID"] = new SelectList(deptDetails, "DeptID", "DepartmentName", stud.DepartmentID);
            return View(stud);
        }

        [HttpPost, ActionName("DeleteStudent")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteStudent(int StudentID)
        {

            //change user status to inactive
            int activeStatus = StudLogic.DeleteStudentData(StudentID);
            if (activeStatus == 1)
            {
                TempData["TransMessage"] = "Student deactivated successfully";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                TempData["TransError"] = "Error occurred while deleting the  branch data. Please try again later";
                return RedirectToAction(nameof(Delete));
            }
        }


        public IActionResult DetailsInactive()
        {
            //pull the the department details to be displayed on the dropdown.
            //get student data
            List<Student> studentDetails = new List<Student>();
            try
            {
                // get student information
                var getStudents = StudLogic.GetInactiveStudentData();
                studentDetails = HtmlHelpers.ConvertDataTable<Student>(getStudents);


            }
            catch (Exception ex)
            {

            }
            return View(studentDetails.ToList());
        }

        public IActionResult SingleDetails(int id)
        {
            //pull the the department details to be displayed on the dropdown.
            Student stud = new Student();

            //get student details by ID passed
            var saveStudent = StudLogic.GetStudentDepartmentDataById(id);
            if (saveStudent.Rows.Count > 0)
            {
                stud.StudentID = Convert.ToInt32(saveStudent.Rows[0]["StudentID"]);
                stud.FirstName = saveStudent.Rows[0]["FirstName"].ToString();
                stud.Surname = saveStudent.Rows[0]["Surname"].ToString();
                stud.Birthday = Convert.ToDateTime((saveStudent.Rows[0]["BirthDay"]));
                stud.DepartmentID = Convert.ToInt32(saveStudent.Rows[0]["DeptID"]);
                stud.DepartmentName = saveStudent.Rows[0]["DepartmentName"].ToString();
            }

            return View(stud);
        }


        [HttpPost, ActionName("ActivateStudent")]
        [ValidateAntiForgeryToken]
        public IActionResult ActivateStudent(int StudentID)
        {

            //change user status to inactive
            int activeStatus = StudLogic.ActivateStudent(StudentID);
            if (activeStatus == 1)
            {
                TempData["TransMessage"] = "Student activated successfully";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                TempData["TransError"] = "Error occurred while deleting the  branch data. Please try again later";
                return RedirectToAction(nameof(Delete));
            }
        }
    }
}
