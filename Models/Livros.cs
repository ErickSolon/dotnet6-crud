namespace backend.Models
{
    public class Livros
    {
        public Livros() {
            IsDeleted = false;
        }

        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }

        public void Update(string title, string author, string description) {
            Title = title;
            Author = author;
            Description = description;
        }

        public void Delete() {
            IsDeleted = true;
        }
    }
}