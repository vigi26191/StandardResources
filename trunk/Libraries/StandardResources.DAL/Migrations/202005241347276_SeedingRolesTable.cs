namespace StandardResources.DAL.Migrations
{
    using StandardResources.Entities.Constants;
    using System.Data.Entity.Migrations;

    public partial class SeedingRolesTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO tblRoles(Name) VALUES ('" + Constants.RoleNames.SALES + "')");
            Sql("INSERT INTO tblRoles(Name) VALUES ('" + Constants.RoleNames.SALESSUPPORT + "')");
            Sql("INSERT INTO tblRoles(Name) VALUES ('" + Constants.RoleNames.OPERATIONS + "')");
            Sql("INSERT INTO tblRoles(Name) VALUES ('" + Constants.RoleNames.SUPER_ADMIN + "')");
            Sql("INSERT INTO tblRoles(Name) VALUES ('" + Constants.RoleNames.ACCOUNT + "')");
            Sql("INSERT INTO tblRoles(Name) VALUES ('" + Constants.RoleNames.SUPPORT + "')");
        }

        public override void Down()
        {
            Sql("DELETE FROM tblRoles");
        }
    }
}
