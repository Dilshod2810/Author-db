
using FluentMigrator.Builders;

namespace Infrastructure.Migration;

public class CreateTableBookMig:FluentMigrator.Migration
{
    public override void Up()
    {
        Create.Table("books")
            .WithColumn("Id").AsInt32().PrimaryKey().Identity()
            .WithColumn("Title").AsString(30).NotNullable()
            .WithColumn("AuthorId").AsInt32()
            .WithColumn("PublishedYear").AsInt32()
            .WithColumn("Genre").AsString(50).NotNullable()
            .WithColumn("IsAvailable").AsBoolean().NotNullable();
    }

    public override void Down()
    {
        Delete.Table("books");
    }
}