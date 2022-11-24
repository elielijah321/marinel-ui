using Marinel_ui.Data.Entities;
using System.Collections.Generic;

namespace Marinel_ui.Data
{
    public interface ISchoolRepository
    {
        IEnumerable<Student> GetAllStudents();
        IEnumerable<Teacher> GetAllTeachers();
        IEnumerable<Class> GetAllClasses();
        IEnumerable<FeedingInfoItem> GetAllFeedingItems();
        IEnumerable<ClassFeeInfoItem> GetAllClasseFeeInfoItems();
        IEnumerable<InventoryType> GetAllInventoryTypes();
        IEnumerable<InventoryItem> GetAllInventoryItems();
        IEnumerable<BookSale> GetAllBookSales();
        IEnumerable<UniformSale> GetAllUniformSales();
        IEnumerable<PandCUniformSale> GetAllPandCUniformSales();
        IEnumerable<ExpenseType> GetAllExpenseTypes();
        IEnumerable<Expense> GetAllExpenses();
        IEnumerable<LibraryBook> GetAllLibraryBook();

        void AddStudent(Student student);
        void AddTeacher(Teacher teacher);
        void AddClass(Class newClass);
        void AddFeedingInfoItem(FeedingInfoItem newFeedingInfoItem);
        void AddInventoryType(InventoryType newInventoryType);
        void AddInventoryItem(InventoryItem newInventoryItem);
        void AddClassFeeInfoItem(ClassFeeInfoItem newClassFeeInfoItem);
        void AddBookSale(BookSale newBookSale);
        void AddUniformSale(UniformSale newUniformSale);
        void AddPandCUniformSale(PandCUniformSale newPandCUniformSale);
        void AddExpenseType(ExpenseType expenseType);
        void AddExpense(Expense expense);
        void AddLibraryBook(LibraryBook libraryBook);

        void UpdateTeacher(Teacher teacher);
        void UpdateFeedingInfoItem(FeedingInfoItem feedingInfoItem);
        void UpdateClassFeeInfoItem(ClassFeeInfoItem classFeeInfoItem);
        void UpdateInventoryItem(InventoryItem inventoryItem);
        void UpdateClassItem(Class classItem);
        void UpdateBookSale(BookSale bookSale);
        void UpdateUniformSale(UniformSale uniformSale);
        void UpdatePandCUniformSale(PandCUniformSale pAndCUniformSale);
        void UpdateExpenseType(ExpenseType expenseType);
        void UpdateExpense(Expense expense);
        void UpdateLibraryBook(LibraryBook libraryBook);

        void RemoveTeacher(int teacherID);
    }
}