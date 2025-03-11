var builder = WebApplication.CreateBuilder(args);

builder
    .AddGraphQL()
    .AddTypes()
    .AddQueryContext()
    .AddGlobalObjectIdentification()
    .InitializeOnStartup();

var app = builder.Build();

app.MapGraphQL();

app.RunWithGraphQLCommands(args);


/*
# The node query for a book works
query BookNode {
  # Book:1
  node(id: "Qm9vazox") {
    __typename
    id
  }
}

# The nodes query for Author works because there is no QueryContext
query AuthorNode {
  # Author:1, Author:2
  nodes(ids: ["QXV0aG9yOjE=", "QXV0aG9yOjI="]) {
    __typename
    id
  }
}

# Nodes query does not work
query BookNodes {
  # Book:1, Book: 2
  nodes(ids: ["Qm9vazox", "Qm9vazoy"]) {
    __typename
    id
  }
}
*/