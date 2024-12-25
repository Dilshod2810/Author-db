namespace Infrastructure.Migration;

public class CreateTableAuthorMig:FluentMigrator.Migration
{
    public override void Up()
    {
        Create.Table("Authors")
            .WithColumn("Id").AsInt32().PrimaryKey().Identity()
            .WithColumn("Name").AsString(255).NotNullable()
            .WithColumn("Country").AsString().Nullable();
    }

    public override void Down()
    {
        Delete.Table("Authors");
    }
}