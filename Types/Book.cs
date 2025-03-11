using GreenDonut.Data;

namespace NodeResolverBugReproduction.Types;

[Node]
public class Book
{
    public int Id { get; init; }
    public required string Title { get; init; }
    public required Author Author { get; init; }
}


[ObjectType<Book>]
public static partial class BookNode
{
    [NodeResolver]
    public static Book? GetBookById([ID<Book>] int id, QueryContext<Book> queryContext)
    {
        return new Book
        {
            Id = id,
            Title = "Test Title",
            Author = new Author
            {
                Id = 1,
                Name = "Test Author"
            }
        };
    }
}