using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LakshmiMovieApp.Migrations
{
    /// <inheritdoc />
    public partial class SPGetcategorybyID : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string procedure = @"create procedure SP_GetCategorybyid
                 @id int 
                 as begin
                 select * from Categories where id =@id 
                 end ";
            migrationBuilder.Sql(procedure);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

            string procedure = @"Drop procedure SP_GetCategorybyid";
            migrationBuilder.Sql(procedure);




        }
    }
}
