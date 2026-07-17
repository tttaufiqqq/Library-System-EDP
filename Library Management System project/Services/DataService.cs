using System;

namespace Library_Management_System_project.Services
{
    // Shared LibraryDataContext lifecycle for every Service - each call site used to
    // repeat its own using(var db = new LibraryDataContext()) { ... } block.
    public abstract class DataService
    {
        protected T WithContext<T>(Func<LibraryDataContext, T> query)
        {
            using (var db = new LibraryDataContext())
            {
                return query(db);
            }
        }

        protected void WithContext(Action<LibraryDataContext> action)
        {
            using (var db = new LibraryDataContext())
            {
                action(db);
            }
        }
    }
}
