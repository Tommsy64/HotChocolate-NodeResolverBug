namespace NodeResolverBugReproduction.Types;

[Node]
public class Author
{
    public int Id { get; init; }
    public required string Name { get; init; }
}

[ObjectType<Author>]
public static partial class AuthorNode
{
    [NodeResolver]
    public static Author? GetAuthorById([ID<Author>] int id/*, QueryContext<Author> queryContext */) // No QueryContext
    {
        return new Author
        {
            Id = id,
            Name = "Test Name"
        };
    }
}