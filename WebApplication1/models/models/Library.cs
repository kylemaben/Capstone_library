// LibraryItem.cs - This is our abstract base class (Abstraction & Inheritance)
using System;

namespace WebApplication1.Models
{
    // The abstract class ensures all derived classes have an Id, Title, and IsAvailable property.
    public abstract class LibraryItem
    {
        // Encapsulation: Private fields with public accessors
        private int _id;
        private string _title;
        private bool _isAvailable;

        // Constructor to ensure non-nullable fields are initialized
        protected LibraryItem(string title)
        {
            _title = title;
            _isAvailable = true;
        }

        // Public getters and setters for controlled access
        public int Id
        {
            get => _id;
            set => _id = value;
        }

        public string Title
        {
            get => _title;
            set => _title = value;
        }

        public bool IsAvailable
        {
            get => _isAvailable;
            set => _isAvailable = value;
        }

        // Abstract method to be implemented by derived classes
        public abstract void DisplayStatus();
    }
}