using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolCourseRegistration.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseNumber = table.Column<int>(nullable: false),
                    CourseName = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Credits = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Instructor",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Registration",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegistrationType = table.Column<string>(nullable: false),
                    StudentId = table.Column<int>(nullable: false),
                    CourseId = table.Column<int>(nullable: false),
                    InstructorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registration", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentNumber = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StudentCourse",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(nullable: false),
                    CourseId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentCourse", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CourseViewModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseID = table.Column<int>(nullable: true),
                    PageTitle = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseViewModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseViewModel_Course_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InstructorViewModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InstructorID = table.Column<int>(nullable: true),
                    PageTitle = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstructorViewModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InstructorViewModel_Instructor_InstructorID",
                        column: x => x.InstructorID,
                        principalTable: "Instructor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentViewModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentID = table.Column<int>(nullable: true),
                    PageTitle = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentViewModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentViewModel_Student_StudentID",
                        column: x => x.StudentID,
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Course",
                columns: new[] { "Id", "CourseName", "CourseNumber", "Credits", "Description" },
                values: new object[,]
                {
                    { 1, "Cryo 101", 1101, 3, "Ice Basics" },
                    { 2, "Pyro 101", 2101, 5, "Fire Basics" },
                    { 3, "Dendro 101", 3101, 3, "Tree Basics" }
                });

            migrationBuilder.InsertData(
                table: "Instructor",
                columns: new[] { "Id", "Email", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "arya@stark.ca", "Arya", "Stark" },
                    { 2, "dany@drogo.ca", "Danaerys", "Targaryen" },
                    { 3, "margaery@tyrell.ca", "Margaery", "Tyrell" }
                });

            migrationBuilder.InsertData(
                table: "Registration",
                columns: new[] { "Id", "CourseId", "InstructorId", "RegistrationType", "StudentId" },
                values: new object[,]
                {
                    { 1, 1101, 1, "Part Time", 1 },
                    { 2, 2101, 2, "Full Time", 2 },
                    { 3, 3101, 3, "Part Time", 3 },
                    { 4, 2101, 2, "Full Time", 4 }
                });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "StudentNumber" },
                values: new object[,]
                {
                    { 1, "ted@mosby.ca", "Ted", "Mosby", 2101 },
                    { 2, "marshall@lawyered.ca", "Marshall", "Eriksen", 2102 },
                    { 3, "barney@pleas.ca", "Barney", "Stinson", 2103 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseViewModel_CourseID",
                table: "CourseViewModel",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_InstructorViewModel_InstructorID",
                table: "InstructorViewModel",
                column: "InstructorID");

            migrationBuilder.CreateIndex(
                name: "IX_StudentViewModel_StudentID",
                table: "StudentViewModel",
                column: "StudentID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseViewModel");

            migrationBuilder.DropTable(
                name: "InstructorViewModel");

            migrationBuilder.DropTable(
                name: "Registration");

            migrationBuilder.DropTable(
                name: "StudentCourse");

            migrationBuilder.DropTable(
                name: "StudentViewModel");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "Instructor");

            migrationBuilder.DropTable(
                name: "Student");
        }
    }
}
