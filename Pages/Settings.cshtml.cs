using Azure.Identity;
using Marinel_ui.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.Graph;
using Marinel_ui.Data;
using Marinel_ui.Data.Entities;
using Marinel_ui.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Marinel_ui.Pages
{
    public class SettingsPageModel : PageModel
    {
        private readonly ILogger<SettingsPageModel> _logger;
        private readonly ISchoolRepository _schoolRepository;
        private readonly IMSGraphService _msGraphService;

        public List<Class> Classes { get; set; }
        public List<Student> Students { get; set; }
        public List<Teacher> Teachers { get; set; }
        public List<InventoryType> InventoryTypes { get; set; }
        public List<InventoryItem> InventoryItems { get; set; }
        public List<ExpenseType> ExpenseTypes { get; set; }
        public List<Expense> ExpenseItems { get; set; }
        public List<User> Users { get; set; }
        public List<RoleType> RoleTypes = Enum.GetValues(typeof(RoleType)).Cast<RoleType>().ToList();

        public SettingsPageModel(ISchoolRepository schoolRepo, IMSGraphService msGraphService, ILogger<SettingsPageModel> logger)
        {
            _schoolRepository = schoolRepo;
            _msGraphService = msGraphService;
            _logger = logger;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            await GetPageData();

            return Page();
        }

        public async Task OnPost()
        {
            var formType = Request.Form["form-type"].ToString();
            await GetPageData();

            switch (formType)
            {
                case "student":
                    AddStudent();
                    break;
                case "edit-student":
                    UpdateStudent();
                    break;
                case "class":
                    AddClass();
                    break;
                case "edit-class":
                    UpdateClassItem();
                    break;
                case "inventory-type":
                    AddInventoryType();
                    break;
                case "inventory-item":
                    AddInventory();
                    break;
                case "inventory-item-update":
                    UpdateInventoryItem();
                    break;
                case "user":
                    await AddUser();
                    break;
                case "edit-user":
                    await UpdateUser();
                    break;
                case "expense-type":
                    AddExpenseType();
                    break;
                case "expense-item":
                    AddExpense();
                    break;
                case "expense-item-update":
                    UpdateExpenseItem();
                    break;
                case "teacher":
                    AddTeacher();
                    break;
                case "edit-teacher":
                    UpdateTeacher();
                    break;
                default:
                    break;
            }

            
            await GetPageData();
        }

        private void AddStudent()
        {
            var s_Name = Request.Form["studentName"].ToString();
            var s_Class = Request.Form["studentClass"].ToString();

            var studentClass = Classes.FirstOrDefault(c => c.Name == s_Class);

            var student = new Student();
            student.Name = s_Name;
            student.Class = studentClass;

            _schoolRepository.AddStudent(student);
        }

        private void UpdateStudent()
        {
            var formIDString = Request.Form[$"form-id"].ToString();

            var t_Name = Request.Form[$"student-name-{formIDString}"].ToString();
            var t_Class = Request.Form[$"student-class-ddl-{formIDString}"].ToString();

            var studentClass = Classes.FirstOrDefault(c => c.Id.ToString() == t_Class);


            var student = new Student();
            student.Id = Int32.Parse(formIDString);
            student.Name = t_Name;
            student.ClassId = studentClass.Id;

            _schoolRepository.UpdateStudent(student);
        }

        private void AddTeacher()
        {
            var t_Name = Request.Form["teacher-name"].ToString();
            var t_Notes = Request.Form["teacher-notes"].ToString();
            var t_Class = Request.Form["teacher-class-ddl"].ToString();

            var teacherClass = Classes.FirstOrDefault(c => c.Id.ToString() == t_Class);

            var teacher = new Teacher();
            teacher.Name = t_Name;
            teacher.Notes = t_Notes;
            teacher.Class = teacherClass;

            _schoolRepository.AddTeacher(teacher);
        }

        private void UpdateTeacher()
        {
            var formIDString = Request.Form[$"form-id"].ToString();

            var t_Name = Request.Form[$"teacher-name-{formIDString}"].ToString();
            var t_Notes = Request.Form[$"teacher-notes-{formIDString}"].ToString();
            var t_Class = Request.Form[$"teacher-class-ddl-{formIDString}"].ToString();

            var teacherClass = Classes.FirstOrDefault(c => c.Id.ToString() == t_Class);

            var teacher = new Teacher();
            teacher.Id = Int32.Parse(formIDString);
            teacher.Name = t_Name;
            teacher.Notes = t_Notes;
            teacher.ClassId = teacherClass.Id;

            _schoolRepository.UpdateTeacher(teacher);
        }

        private void AddClass()
        {
            var c_Name = Request.Form["className"].ToString();
            var pAndCPrice = Request.Form["pAndCPrice"].ToString();

            var parsedPandCPrice = long.Parse(pAndCPrice);

            var _class = new Class();
            _class.Name = c_Name;
            _class.PinkAndCheckUniformPrice = parsedPandCPrice;

            _schoolRepository.AddClass(_class);
        }

        private void AddInventoryType()
        {
            var it_Name = Request.Form["new-inventory-type-input"].ToString();

            var _invType = new InventoryType();
            _invType.Name = it_Name;

            _schoolRepository.AddInventoryType(_invType);
        }

        private void AddInventory()
        {
            var i_Name = Request.Form["item-name-input"].ToString();
            var i_type = Request.Form["item-type-input"].ToString();

            var i_quantity = Request.Form["item-quantity-input"].ToString();
            var i_cost = Request.Form["item-unit-cost-input"].ToString();
            var i_selling_price = Request.Form["item-selling-price-input"].ToString();

            var parsedQuantity = int.Parse(i_quantity);
            var parsedCost = long.Parse(i_cost);
            var parsedSellingPrice = long.Parse(i_selling_price);

            var inventoryType = InventoryTypes.FirstOrDefault(i => i.Name == i_type);

            var inventoryItem = new InventoryItem();
            inventoryItem.Name = i_Name;
            inventoryItem.InventoryType = inventoryType;
            inventoryItem.Quantity = parsedQuantity;
            inventoryItem.CostPerUnit = parsedCost;
            inventoryItem.SellingPrice = parsedSellingPrice;

            _schoolRepository.AddInventoryItem(inventoryItem);
        }

        private void AddExpenseType()
        {
            var e_Name = Request.Form["new-expense-type-input"].ToString();

            var _expenseType = new ExpenseType();
            _expenseType.Name = e_Name;

            _schoolRepository.AddExpenseType(_expenseType);
        }

        private void AddExpense()
        {
            var e_Name = Request.Form["expense-item-name-input"].ToString();
            var e_type = Request.Form["expense-item-type-input"].ToString();

            var i_quantity = Request.Form["expense-item-quantity-input"].ToString();
            var i_cost = Request.Form["expense-item-unit-cost-input"].ToString();

            var parsedQuantity = int.Parse(i_quantity);
            var parsedCost = long.Parse(i_cost);

            var expenseType = ExpenseTypes.FirstOrDefault(e => e.Name == e_type);

            var expenseItem = new Expense();
            expenseItem.Description = e_Name;
            expenseItem.Type = expenseType;
            expenseItem.Quantity = parsedQuantity;
            expenseItem.Amount = parsedCost;

            _schoolRepository.AddExpense(expenseItem);
        }

        private async Task AddUser()
        {
            var u_Name = Request.Form["name"].ToString();
            var u_Username = Request.Form["username"].ToString();
            var u_Password = Request.Form["password"].ToString();
            var u_Role = Request.Form["user-role-ddl"].ToString();

            User newUser = new User();
            newUser.DisplayName = u_Name;
            newUser.UserPrincipalName = u_Username;
            newUser.JobTitle = u_Role;
            newUser.PasswordProfile = new PasswordProfile
            {
                ForceChangePasswordNextSignIn = false,
                Password = u_Password
            };


            var allUsers = await _msGraphService.GetAllUsers();


            if (!allUsers.Any(u => u.UserPrincipalName == newUser.UserPrincipalName))
            {
                await _msGraphService.AddUser(newUser);
            }
            //Should alert the user

        }

        private async Task UpdateUser()
        {
            var formIDString = Request.Form[$"form-id"].ToString();

            var u_Name = Request.Form[$"name-{formIDString}"].ToString();
            var u_Username = Request.Form[$"username-{formIDString}"].ToString();
            var u_Role = Request.Form[$"user-role-ddl-{formIDString}"].ToString();

            var user = new User
            {
                DisplayName = u_Name,
                UserPrincipalName = u_Username,
                JobTitle = u_Role
            };

            await _msGraphService.UpdateUser(formIDString, user);
        }

        private void UpdateInventoryItem()
        {
            var formIDString = Request.Form[$"form-id"].ToString();

            var i_Name = Request.Form[$"item-name-input-{formIDString}"].ToString();
            var i_type = Request.Form[$"item-type-input-{formIDString}"].ToString();

            var i_quantity = Request.Form[$"item-quantity-input-{formIDString}"].ToString();
            var i_cost = Request.Form[$"item-unit-cost-input-{formIDString}"].ToString();
            var i_selling_price = Request.Form[$"item-selling-price-input-{formIDString}"].ToString();

            var parsedItemId = int.Parse(formIDString);
            var parsedQuantity = int.Parse(i_quantity);
            var parsedCost = long.Parse(i_cost);
            var parsedSellingPrice = long.Parse(i_selling_price);

            var inventoryType = InventoryTypes.FirstOrDefault(i => i.Name == i_type);

            var inventoryItem = new InventoryItem();
            inventoryItem.Id = parsedItemId;
            inventoryItem.Name = i_Name;
            inventoryItem.InventoryType = inventoryType;
            inventoryItem.Quantity = parsedQuantity;
            inventoryItem.CostPerUnit = parsedCost;
            inventoryItem.SellingPrice = parsedSellingPrice;

            _schoolRepository.UpdateInventoryItem(inventoryItem);

        }

        private void UpdateExpenseItem()
        {
            var formIDString = Request.Form[$"form-id"].ToString();

            var e_Name = Request.Form[$"expense-item-name-input-{formIDString}"].ToString();
            var e_type = Request.Form[$"expense-item-type-input-{formIDString}"].ToString();

            var e_quantity = Request.Form[$"expense-item-quantity-input-{formIDString}"].ToString();
            var e_cost = Request.Form[$"expense-item-unit-cost-input-{formIDString}"].ToString();

            var parsedItemId = int.Parse(formIDString);
            var parsedQuantity = int.Parse(e_quantity);
            var parsedCost = decimal.Parse(e_cost);

            var expenseType = ExpenseTypes.FirstOrDefault(i => i.Name == e_type);

            var expenseItem = new Expense();
            expenseItem.Id = parsedItemId;
            expenseItem.Description = e_Name;
            expenseItem.Type = expenseType;
            expenseItem.Quantity = parsedQuantity;
            expenseItem.Amount = parsedCost;

            _schoolRepository.UpdateExpense(expenseItem);

        }

        private void UpdateClassItem()
        {
            var formIDString = Request.Form[$"form-id"].ToString();

            var c_Name = Request.Form[$"className-{formIDString}"].ToString();
            var pAndCPrice = Request.Form[$"pAndCPrice-{formIDString}"].ToString();

            int parsedClassId = int.Parse(formIDString);
            var parsedPandCPrice = long.Parse(pAndCPrice);

            var classItem = new Class();
            classItem.Id = parsedClassId;
            classItem.Name = c_Name;
            classItem.PinkAndCheckUniformPrice = parsedPandCPrice;

            _schoolRepository.UpdateClassItem(classItem);
        }

        private async Task GetPageData()
        {
            Classes = _schoolRepository.GetAllClasses().ToList();
            Students = _schoolRepository.GetAllStudents().ToList();
            Teachers = _schoolRepository.GetAllTeachers().ToList();
            InventoryTypes = _schoolRepository.GetAllInventoryTypes().ToList();
            InventoryItems = _schoolRepository.GetAllInventoryItems().ToList();
            ExpenseTypes = _schoolRepository.GetAllExpenseTypes().ToList();
            ExpenseItems = _schoolRepository.GetAllExpenses().ToList();
            Users = await _msGraphService.GetAllUsers();
        }

        public async Task<JsonResult> OnGetDeleteUserById(string userId)
        {
            await _msGraphService.DeleteUser(userId);

            return new JsonResult("Ok");
        }

        public async Task<JsonResult> OnGetDeleteTeacherById(string teacherId)
        {
            _schoolRepository.RemoveTeacher(Int32.Parse(teacherId));

            return new JsonResult("Ok");
        }
    }
}
