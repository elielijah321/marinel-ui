using Microsoft.EntityFrameworkCore;
using Marinel_ui.Data.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Marinel_ui.Data
{
    public class SchoolRepository : ISchoolRepository
    {
        private readonly SchoolContext _ctx;

        public SchoolRepository(SchoolContext ctx)
        {
            _ctx = ctx;
        }

        // Get

        public IEnumerable<Student> GetAllStudents()
        {
            return _ctx.Students
                .OrderBy(s => s.Name)
                .ToList();
        }

        public IEnumerable<Teacher> GetAllTeachers()
        {
            return _ctx.Teachers.ToList();
        }

        public IEnumerable<Class> GetAllClasses()
        {
            return _ctx.Classes
                .Include(c => c.Students)
                .OrderBy(s => s.Name)
                .ToList();
        }

        public IEnumerable<FeedingInfoItem> GetAllFeedingItems() 
        {
            var allFeedingExpenses = _ctx.FeedingExpenses;

            var feedingItems = _ctx.FeedingInfoItems.ToList().Select(f => 
            {
                f.FeedingExpenses = allFeedingExpenses.Where(fe => fe.FeedingInfoItemId == f.Id).ToList();
                return f; 
            });

            return feedingItems
                .OrderByDescending(f => f.Date)
                .ToList();
        }

        public IEnumerable<ClassFeeInfoItem> GetAllClasseFeeInfoItems()
        {
            return _ctx.ClassFeeInfoItems
                .OrderByDescending(cf => cf.Date)
                .ToList();
        }

        public IEnumerable<InventoryType> GetAllInventoryTypes()
        {
            return _ctx.InventoryTypes.ToList();
        }

        public IEnumerable<InventoryItem> GetAllInventoryItems()
        {
            return _ctx.InventoryItems.Include(i => i.InventoryType).ToList();
        }

        public IEnumerable<BookSale> GetAllBookSales()
        {
           return _ctx.BookSales.ToList();
        }

        public IEnumerable<UniformSale> GetAllUniformSales()
        {
            return _ctx.UniformSales.Include(u => u.Student).ToList();
        }

        public IEnumerable<PandCUniformSale> GetAllPandCUniformSales()
        {
            return _ctx.PandCUniformSales.Include(u => u.Student).ToList();
        }

        public IEnumerable<ExpenseType> GetAllExpenseTypes()
        {
            return _ctx.ExpenseTypes.ToList();
        }

        public IEnumerable<Expense> GetAllExpenses()
        {
            return _ctx.Expenses.ToList();
        }

        public IEnumerable<LibraryBook> GetAllLibraryBook()
        {
            return _ctx.LibraryBooks.ToList();
        }

        public IEnumerable<LibraryBookRental> GetAllLibraryBookRentals()
        {
            return _ctx.LibraryBookRentals.ToList();
        }

        public IEnumerable<AccountTransaction> GetAllAccountTransactions()
        {
            return _ctx.AccountTransactions.ToList();
        }

        // Add

        public void AddStudent(Student student)
        {
            _ctx.Students.Add(student);
            SaveAll();
        }

        public void AddTeacher(Teacher teacher)
        {
            _ctx.Teachers.Add(teacher);
            SaveAll();
        }

        public void AddClass(Class newClass)
        {
            _ctx.Classes.Add(newClass);
            SaveAll();
        }

        public void AddFeedingInfoItem(FeedingInfoItem newFeedingInfoItem)
        {
            _ctx.FeedingInfoItems.Add(newFeedingInfoItem);
            SaveAll();
        }

        public void AddClassFeeInfoItem(ClassFeeInfoItem newClassFeeInfoItem)
        {
            _ctx.ClassFeeInfoItems.Add(newClassFeeInfoItem);
            SaveAll();
        }

        public void AddInventoryType(InventoryType newInventoryType)
        {
            _ctx.InventoryTypes.Add(newInventoryType);
            SaveAll();
        }

        public void AddInventoryItem(InventoryItem newInventoryItem)
        {
            _ctx.InventoryItems.Add(newInventoryItem);
            SaveAll();
        }

        public void AddBookSale(BookSale newBookSale)
        {
            var inventoryItem = _ctx.InventoryItems.FirstOrDefault(i => i.Id == newBookSale.InventoryItemId);
            var profitPer = inventoryItem.SellingPrice - inventoryItem.CostPerUnit;
            var revenue = profitPer * newBookSale.NoOfBooksSold;
            newBookSale.Revenue = revenue;

            inventoryItem.Quantity = inventoryItem.Quantity - newBookSale.NoOfBooksSold;

            _ctx.BookSales.Add(newBookSale);
            SaveAll();
        }

        public void AddUniformSale(UniformSale newUniformSale)
        {
            var inventoryItem = _ctx.InventoryItems.FirstOrDefault(i => i.Id == newUniformSale.InventoryItemId);
            var profitPer = inventoryItem.SellingPrice - inventoryItem.CostPerUnit;
            var revenue = profitPer * newUniformSale.Quantity;
            newUniformSale.Revenue = revenue;

            inventoryItem.Quantity = inventoryItem.Quantity - newUniformSale.Quantity;

            _ctx.UniformSales.Add(newUniformSale);
            SaveAll();
        }

        public void AddPandCUniformSale(PandCUniformSale newPandCUniformSale)
        {
            var classId = _ctx.Students.FirstOrDefault(s => s.Id == newPandCUniformSale.StudentId).ClassId;
            var pAndCPrice = _ctx.Classes.FirstOrDefault(c => c.Id == classId).PinkAndCheckUniformPrice;

            newPandCUniformSale.TotalCollected = pAndCPrice;

            _ctx.PandCUniformSales.Add(newPandCUniformSale);
            SaveAll();
        }

        public void AddExpenseType(ExpenseType expenseType)
        {
            _ctx.ExpenseTypes.Add(expenseType);
            SaveAll();
        }

        public void AddExpense(Expense expense)
        {
            _ctx.Expenses.Add(expense);
            SaveAll();
        }

        public void AddLibraryBook(LibraryBook libraryBook)
        {
            _ctx.LibraryBooks.Add(libraryBook);
            SaveAll();
        }

        public void AddLibraryBookRental(LibraryBookRental libraryBookRental)
        {
            _ctx.LibraryBookRentals.Add(libraryBookRental);
            SaveAll();
        }

        public void AddAccountTransaction(AccountTransaction accountTransaction)
        {
            _ctx.AccountTransactions.Add(accountTransaction);
            SaveAll();
        }

        // Update

        public void UpdateStudent(Student student)
        {
            var _student = _ctx.Students.Where(s => s.Id == student.Id).First();

            _student.Name = student.Name;
            _student.ClassId = student.ClassId;
            _student.ScholarshipType = student.ScholarshipType;

            SaveAll();
        }

        public void UpdateFeedingInfoItem(FeedingInfoItem feedingInfoItem)
        {
            var fItem = _ctx.FeedingInfoItems.Where(f => f.Id == feedingInfoItem.Id).First();
            fItem.Date = feedingInfoItem.Date;
            fItem.TotalCollected = feedingInfoItem.TotalCollected;
            fItem.NumberOfStudents = feedingInfoItem.NumberOfStudents;
            fItem.Revenue = feedingInfoItem.Revenue;

            var feedingItemExpenses = _ctx.FeedingExpenses.Where(fe => fe.FeedingInfoItemId == fItem.Id);
            _ctx.RemoveRange(feedingItemExpenses);
            fItem.FeedingExpenses = feedingInfoItem.FeedingExpenses;

            SaveAll();
        }

        public void UpdateClassFeeInfoItem(ClassFeeInfoItem classFeeInfoItem)
        {
            var cfItem = _ctx.ClassFeeInfoItems.Where(c => c.Id == classFeeInfoItem.Id).First();
            cfItem.Date = classFeeInfoItem.Date;
            cfItem.NumberEnrolled = classFeeInfoItem.NumberEnrolled;
            cfItem.NumberPaid = classFeeInfoItem.NumberPaid;
            cfItem.AmountReceived = classFeeInfoItem.AmountReceived;

            SaveAll();
        }

        public void UpdateInventoryItem(InventoryItem inventoryItem)
        {
            var i_Item = _ctx.InventoryItems.FirstOrDefault(i => i.Id == inventoryItem.Id);

            i_Item.Name = inventoryItem.Name;
            i_Item.Quantity = inventoryItem.Quantity;
            i_Item.SellingPrice = inventoryItem.SellingPrice;
            i_Item.CostPerUnit = inventoryItem.CostPerUnit;
            i_Item.InventoryType = inventoryItem.InventoryType;

            SaveAll();
        }

        public void UpdateClassItem(Class classItem)
        {
            var c_Item = _ctx.Classes.FirstOrDefault(c => c.Id == classItem.Id);
            c_Item.Name = classItem.Name;
            c_Item.PinkAndCheckUniformPrice = classItem.PinkAndCheckUniformPrice;

            SaveAll();
        }

        public void UpdateBookSale(BookSale newBookSale)
        {
            var inventoryItem = _ctx.InventoryItems.FirstOrDefault(i => i.Id == newBookSale.InventoryItemId);
            var profitPer = inventoryItem.SellingPrice - inventoryItem.CostPerUnit;
            var revenue = profitPer * newBookSale.NoOfBooksSold;

            var originalBookSale = _ctx.BookSales.FirstOrDefault(b => b.Id == newBookSale.Id);

            // Adjust inventory quantity
            var difference = originalBookSale.NoOfBooksSold - newBookSale.NoOfBooksSold;
            inventoryItem.Quantity = inventoryItem.Quantity + difference;

            originalBookSale.InventoryItemId = newBookSale.InventoryItemId;
            originalBookSale.NoOfBooksSold = newBookSale.NoOfBooksSold;
            originalBookSale.Revenue = revenue;

            SaveAll();
        }

        public void UpdateUniformSale(UniformSale newUniformSale)
        {
            var inventoryItem = _ctx.InventoryItems.FirstOrDefault(i => i.Id == newUniformSale.InventoryItemId);
            var profitPer = inventoryItem.SellingPrice - inventoryItem.CostPerUnit;
            var revenue = profitPer * newUniformSale.Quantity;

            var originalUniformSale = _ctx.UniformSales.FirstOrDefault(b => b.Id == newUniformSale.Id);

            // Adjust inventory quantity
            var difference = originalUniformSale.Quantity - originalUniformSale.Quantity;
            inventoryItem.Quantity = inventoryItem.Quantity + difference;

            originalUniformSale.InventoryItemId = newUniformSale.InventoryItemId;
            originalUniformSale.Date = newUniformSale.Date;
            originalUniformSale.StudentId = newUniformSale.StudentId;
            originalUniformSale.Quantity = newUniformSale.Quantity;
            originalUniformSale.Notes = newUniformSale.Notes;
            originalUniformSale.Received = newUniformSale.Received;
            originalUniformSale.PaidInFull = newUniformSale.PaidInFull;
            originalUniformSale.Revenue = revenue;

            SaveAll();
        }

        public void UpdatePandCUniformSale(PandCUniformSale newPAndCUniformSale)
        {
            var originalUniformSale = _ctx.PandCUniformSales.FirstOrDefault(b => b.Id == newPAndCUniformSale.Id);

            var classId = _ctx.Students.FirstOrDefault(s => s.Id == newPAndCUniformSale.StudentId).ClassId;
            var pAndCPrice = _ctx.Classes.FirstOrDefault(c => c.Id == classId).PinkAndCheckUniformPrice;

            newPAndCUniformSale.TotalCollected = pAndCPrice;

            originalUniformSale.DatePaid = newPAndCUniformSale.DatePaid;
            originalUniformSale.ReceivedDate = newPAndCUniformSale.ReceivedDate;
            originalUniformSale.CheckYardsQuantity = newPAndCUniformSale.CheckYardsQuantity;
            originalUniformSale.PinkYardsQuantity = newPAndCUniformSale.PinkYardsQuantity;
            originalUniformSale.TotalCollected = newPAndCUniformSale.TotalCollected;
            originalUniformSale.PaidInFull = newPAndCUniformSale.PaidInFull;
            originalUniformSale.Received = newPAndCUniformSale.Received;
            originalUniformSale.SeamstressPaid = newPAndCUniformSale.SeamstressPaid;
            originalUniformSale.Notes = newPAndCUniformSale.Notes;
            originalUniformSale.StudentId = newPAndCUniformSale.StudentId;

            SaveAll();
        }

        public void UpdateExpenseType(ExpenseType expenseType)
        {
            var e_type = _ctx.ExpenseTypes.FirstOrDefault(e => e.Id == expenseType.Id);
            e_type.Name = expenseType.Name;
            SaveAll();
        }

        public void UpdateExpense(Expense expense)
        {
            var e_Item = _ctx.Expenses.FirstOrDefault(e => e.Id == expense.Id);

            e_Item.Description = expense.Description;
            e_Item.Date = expense.Date;
            e_Item.Quantity = expense.Quantity;
            e_Item.Amount = expense.Amount;
            e_Item.Type = expense.Type;

            SaveAll();
        }

        public void UpdateTeacher(Teacher teacher)
        {
            var _teacher = _ctx.Teachers.Where(t => t.Id == teacher.Id).First();

            _teacher.Name = teacher.Name;
            _teacher.Notes = teacher.Notes;
            _teacher.ClassId = teacher.ClassId;

            SaveAll();
        }

        public void UpdateLibraryBook(LibraryBook libraryBook)
        {
            var _libraryBook = _ctx.LibraryBooks.FirstOrDefault(l => l.Id == libraryBook.Id);

            _libraryBook.Title = libraryBook.Title;
            _libraryBook.Author = libraryBook.Author;
            _libraryBook.Quantity = libraryBook.Quantity;

            SaveAll(); 
        }

        public void UpdateLibraryBookRental(LibraryBookRental libraryBookRental)
        {
            var _libraryBookRental = _ctx.LibraryBookRentals.FirstOrDefault(lbr => lbr.Id == libraryBookRental.Id);

            _libraryBookRental.StudentId = libraryBookRental.StudentId;
            _libraryBookRental.RentedDate = libraryBookRental.RentedDate;
            _libraryBookRental.ExpextedReturnDate = libraryBookRental.ExpextedReturnDate;
            _libraryBookRental.ActualReturnDate = libraryBookRental.ActualReturnDate;

            SaveAll();
        }

        public void UpdateAccountTransaction(AccountTransaction accountTransaction)
        {
            var _accountTransaction = _ctx.AccountTransactions.FirstOrDefault(a => a.Id == accountTransaction.Id);

            _accountTransaction.AccountName = accountTransaction.AccountName;
            _accountTransaction.Date = accountTransaction.Date;
            _accountTransaction.ReasonForTransaction = accountTransaction.ReasonForTransaction;
            _accountTransaction.Amount = accountTransaction.Amount;

            SaveAll();
        }

        public void RemoveTeacher(int teacherID)
        {
            var teacher = _ctx.Teachers.FirstOrDefault(t => t.Id == teacherID);

            _ctx.Remove(teacher);
            SaveAll();
        }

        // Save
        private bool SaveAll()
        {
            return _ctx.SaveChanges() > 0;
        }

       
    }
}
