using System;
using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace IceJamsDB.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "icejam");

            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:PostgresExtension:postgis", "'postgis', '', ''");

            migrationBuilder.CreateTable(
                name: "Agencies",
                schema: "icejam",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    Abbreviation = table.Column<string>(maxLength: 6, nullable: false),
                    LastModified = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agencies", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DamageTypes",
                schema: "icejam",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    ExampleImageURL = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DamageTypes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "FileTypes",
                schema: "icejam",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileTypes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "IceConditionTypes",
                schema: "icejam",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IceConditionTypes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "JamTypes",
                schema: "icejam",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    ExampleImageURL = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JamTypes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "RiverConditionTypes",
                schema: "icejam",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RiverConditionTypes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                schema: "icejam",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    LastModified = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "RoughnessTypes",
                schema: "icejam",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoughnessTypes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Sites",
                schema: "icejam",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<int>(nullable: false),
                    Location = table.Column<Point>(nullable: false),
                    State = table.Column<string>(nullable: false),
                    County = table.Column<string>(nullable: false),
                    RiverName = table.Column<string>(nullable: false),
                    HUC = table.Column<int>(nullable: false),
                    USGSID = table.Column<string>(nullable: true),
                    AHPSID = table.Column<string>(nullable: true),
                    Comments = table.Column<string>(nullable: true),
                    Landmarks = table.Column<string>(nullable: true),
                    LastModified = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sites", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "StageTypes",
                schema: "icejam",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StageTypes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "WeatherConditionTypes",
                schema: "icejam",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeatherConditionTypes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Observers",
                schema: "icejam",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    Username = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    PrimaryPhone = table.Column<string>(nullable: true),
                    SecondaryPhone = table.Column<string>(nullable: true),
                    AgencyID = table.Column<int>(nullable: false),
                    RoleID = table.Column<int>(nullable: false),
                    OtherInfo = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: false),
                    Salt = table.Column<string>(nullable: false),
                    LastModified = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Observers", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Observers_Agencies_AgencyID",
                        column: x => x.AgencyID,
                        principalSchema: "icejam",
                        principalTable: "Agencies",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Observers_Roles_RoleID",
                        column: x => x.RoleID,
                        principalSchema: "icejam",
                        principalTable: "Roles",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IceJams",
                schema: "icejam",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ObservationDateTime = table.Column<DateTime>(nullable: false),
                    JamTypeID = table.Column<int>(nullable: false),
                    SiteID = table.Column<int>(nullable: false),
                    ObserverID = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    Comments = table.Column<string>(nullable: true),
                    LastModified = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IceJams", x => x.ID);
                    table.ForeignKey(
                        name: "FK_IceJams_JamTypes_JamTypeID",
                        column: x => x.JamTypeID,
                        principalSchema: "icejam",
                        principalTable: "JamTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IceJams_Observers_ObserverID",
                        column: x => x.ObserverID,
                        principalSchema: "icejam",
                        principalTable: "Observers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IceJams_Sites_SiteID",
                        column: x => x.SiteID,
                        principalSchema: "icejam",
                        principalTable: "Sites",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Damages",
                schema: "icejam",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    IceJamID = table.Column<int>(nullable: false),
                    DamageTypeID = table.Column<int>(nullable: false),
                    DateTimeReported = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    LastModified = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Damages", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Damages_DamageTypes_DamageTypeID",
                        column: x => x.DamageTypeID,
                        principalSchema: "icejam",
                        principalTable: "DamageTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Damages_IceJams_IceJamID",
                        column: x => x.IceJamID,
                        principalSchema: "icejam",
                        principalTable: "IceJams",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IceConditions",
                schema: "icejam",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    IceJamID = table.Column<int>(nullable: false),
                    DateTime = table.Column<DateTime>(nullable: false),
                    IceConditionTypeID = table.Column<int>(nullable: false),
                    Measurement = table.Column<double>(nullable: false),
                    IsEstimated = table.Column<bool>(nullable: false),
                    IsChanging = table.Column<bool>(nullable: false),
                    Comments = table.Column<string>(nullable: true),
                    UpstreamEndLocation = table.Column<Point>(nullable: true),
                    DownstreamEndLocation = table.Column<Point>(nullable: true),
                    RoughnessTypeID = table.Column<int>(nullable: false),
                    LastModified = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IceConditions", x => x.ID);
                    table.ForeignKey(
                        name: "FK_IceConditions_IceConditionTypes_IceConditionTypeID",
                        column: x => x.IceConditionTypeID,
                        principalSchema: "icejam",
                        principalTable: "IceConditionTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IceConditions_IceJams_IceJamID",
                        column: x => x.IceJamID,
                        principalSchema: "icejam",
                        principalTable: "IceJams",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IceConditions_RoughnessTypes_RoughnessTypeID",
                        column: x => x.RoughnessTypeID,
                        principalSchema: "icejam",
                        principalTable: "RoughnessTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RiverConditions",
                schema: "icejam",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    IceJamID = table.Column<int>(nullable: false),
                    DateTime = table.Column<DateTime>(nullable: false),
                    RiverConditionTypeID = table.Column<int>(nullable: false),
                    IsFlooding = table.Column<bool>(nullable: true),
                    StageTypeID = table.Column<int>(nullable: true),
                    Measurement = table.Column<double>(nullable: true),
                    IsChanging = table.Column<bool>(nullable: true),
                    Comments = table.Column<string>(nullable: true),
                    LastModified = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RiverConditions", x => x.ID);
                    table.ForeignKey(
                        name: "FK_RiverConditions_IceJams_IceJamID",
                        column: x => x.IceJamID,
                        principalSchema: "icejam",
                        principalTable: "IceJams",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RiverConditions_RiverConditionTypes_RiverConditionTypeID",
                        column: x => x.RiverConditionTypeID,
                        principalSchema: "icejam",
                        principalTable: "RiverConditionTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RiverConditions_StageTypes_StageTypeID",
                        column: x => x.StageTypeID,
                        principalSchema: "icejam",
                        principalTable: "StageTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WeatherConditions",
                schema: "icejam",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    IceJamID = table.Column<int>(nullable: false),
                    DateTime = table.Column<DateTime>(nullable: false),
                    WeatherConditionTypeID = table.Column<int>(nullable: false),
                    Measurement = table.Column<double>(nullable: false),
                    IsEstimated = table.Column<bool>(nullable: false),
                    IsChanging = table.Column<bool>(nullable: false),
                    Comments = table.Column<string>(nullable: false),
                    LastModified = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeatherConditions", x => x.ID);
                    table.ForeignKey(
                        name: "FK_WeatherConditions_IceJams_IceJamID",
                        column: x => x.IceJamID,
                        principalSchema: "icejam",
                        principalTable: "IceJams",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WeatherConditions_WeatherConditionTypes_WeatherConditionTyp~",
                        column: x => x.WeatherConditionTypeID,
                        principalSchema: "icejam",
                        principalTable: "WeatherConditionTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Files",
                schema: "icejam",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    FileTypeID = table.Column<int>(nullable: false),
                    URL = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    IceJamID = table.Column<int>(nullable: false),
                    DamageID = table.Column<int>(nullable: false),
                    LastModified = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Files", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Files_Damages_DamageID",
                        column: x => x.DamageID,
                        principalSchema: "icejam",
                        principalTable: "Damages",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Files_FileTypes_FileTypeID",
                        column: x => x.FileTypeID,
                        principalSchema: "icejam",
                        principalTable: "FileTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Files_IceJams_IceJamID",
                        column: x => x.IceJamID,
                        principalSchema: "icejam",
                        principalTable: "IceJams",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Damages_DamageTypeID",
                schema: "icejam",
                table: "Damages",
                column: "DamageTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Damages_IceJamID",
                schema: "icejam",
                table: "Damages",
                column: "IceJamID");

            migrationBuilder.CreateIndex(
                name: "IX_DamageTypes_Name",
                schema: "icejam",
                table: "DamageTypes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Files_DamageID",
                schema: "icejam",
                table: "Files",
                column: "DamageID");

            migrationBuilder.CreateIndex(
                name: "IX_Files_FileTypeID",
                schema: "icejam",
                table: "Files",
                column: "FileTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Files_IceJamID",
                schema: "icejam",
                table: "Files",
                column: "IceJamID");

            migrationBuilder.CreateIndex(
                name: "IX_FileTypes_Name",
                schema: "icejam",
                table: "FileTypes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_IceConditions_IceConditionTypeID",
                schema: "icejam",
                table: "IceConditions",
                column: "IceConditionTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_IceConditions_IceJamID",
                schema: "icejam",
                table: "IceConditions",
                column: "IceJamID");

            migrationBuilder.CreateIndex(
                name: "IX_IceConditions_RoughnessTypeID",
                schema: "icejam",
                table: "IceConditions",
                column: "RoughnessTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_IceConditionTypes_Name",
                schema: "icejam",
                table: "IceConditionTypes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_IceJams_JamTypeID",
                schema: "icejam",
                table: "IceJams",
                column: "JamTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_IceJams_ObserverID",
                schema: "icejam",
                table: "IceJams",
                column: "ObserverID");

            migrationBuilder.CreateIndex(
                name: "IX_IceJams_SiteID",
                schema: "icejam",
                table: "IceJams",
                column: "SiteID");

            migrationBuilder.CreateIndex(
                name: "IX_JamTypes_Name",
                schema: "icejam",
                table: "JamTypes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Observers_AgencyID",
                schema: "icejam",
                table: "Observers",
                column: "AgencyID");

            migrationBuilder.CreateIndex(
                name: "IX_Observers_RoleID",
                schema: "icejam",
                table: "Observers",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_Observers_Username",
                schema: "icejam",
                table: "Observers",
                column: "Username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RiverConditions_IceJamID",
                schema: "icejam",
                table: "RiverConditions",
                column: "IceJamID");

            migrationBuilder.CreateIndex(
                name: "IX_RiverConditions_RiverConditionTypeID",
                schema: "icejam",
                table: "RiverConditions",
                column: "RiverConditionTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_RiverConditions_StageTypeID",
                schema: "icejam",
                table: "RiverConditions",
                column: "StageTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_RiverConditionTypes_Name",
                schema: "icejam",
                table: "RiverConditionTypes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RoughnessTypes_Name",
                schema: "icejam",
                table: "RoughnessTypes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StageTypes_Name",
                schema: "icejam",
                table: "StageTypes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WeatherConditions_IceJamID",
                schema: "icejam",
                table: "WeatherConditions",
                column: "IceJamID");

            migrationBuilder.CreateIndex(
                name: "IX_WeatherConditions_WeatherConditionTypeID",
                schema: "icejam",
                table: "WeatherConditions",
                column: "WeatherConditionTypeID");

            //custom sql
            migrationBuilder.Sql(@"
                CREATE OR REPLACE FUNCTION ""icejam"".""trigger_set_lastmodified""()
                    RETURNS TRIGGER AS $$
                    BEGIN
                      NEW.""LastModified"" = NOW();
                      RETURN NEW;
                    END;
                    $$ LANGUAGE plpgsql;
                ");

            migrationBuilder.Sql(@"
                CREATE TRIGGER lastupdate BEFORE INSERT OR UPDATE ON ""Files""  FOR EACH ROW EXECUTE PROCEDURE ""icejam"".""trigger_set_lastmodified""();
                CREATE TRIGGER lastupdate BEFORE INSERT OR UPDATE ON ""IceConditions""  FOR EACH ROW EXECUTE PROCEDURE ""icejam"".""trigger_set_lastmodified""();
                CREATE TRIGGER lastupdate BEFORE INSERT OR UPDATE ON  ""RiverConditions"" FOR EACH ROW EXECUTE PROCEDURE  ""icejam"".""trigger_set_lastmodified""();
                CREATE TRIGGER lastupdate BEFORE INSERT OR UPDATE ON ""WeatherConditions""  FOR EACH ROW EXECUTE PROCEDURE ""icejam"".""trigger_set_lastmodified""();
                CREATE TRIGGER lastupdate BEFORE INSERT OR UPDATE ON  ""Damages"" FOR EACH ROW EXECUTE PROCEDURE  ""icejam"".""trigger_set_lastmodified""();
                CREATE TRIGGER lastupdate BEFORE INSERT OR UPDATE ON ""IceJams""  FOR EACH ROW EXECUTE PROCEDURE ""icejam"".""trigger_set_lastmodified""();
                CREATE TRIGGER lastupdate BEFORE INSERT OR UPDATE ON  ""Observers"" FOR EACH ROW EXECUTE PROCEDURE  ""icejam"".""trigger_set_lastmodified""();
                CREATE TRIGGER lastupdate BEFORE INSERT OR UPDATE ON  ""Sites"" FOR EACH ROW EXECUTE PROCEDURE  ""icejam"".""trigger_set_lastmodified""();
                CREATE TRIGGER lastupdate BEFORE INSERT OR UPDATE ON ""Agencies"" FOR  EACH ROW EXECUTE PROCEDURE ""icejam"".""trigger_set_lastmodified""();
                CREATE TRIGGER lastupdate BEFORE INSERT OR UPDATE ON ""Roles""  FOR EACH ROW EXECUTE PROCEDURE ""icejam"".""trigger_set_lastmodified""();
                ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Files",
                schema: "icejam");

            migrationBuilder.DropTable(
                name: "IceConditions",
                schema: "icejam");

            migrationBuilder.DropTable(
                name: "RiverConditions",
                schema: "icejam");

            migrationBuilder.DropTable(
                name: "WeatherConditions",
                schema: "icejam");

            migrationBuilder.DropTable(
                name: "Damages",
                schema: "icejam");

            migrationBuilder.DropTable(
                name: "FileTypes",
                schema: "icejam");

            migrationBuilder.DropTable(
                name: "IceConditionTypes",
                schema: "icejam");

            migrationBuilder.DropTable(
                name: "RoughnessTypes",
                schema: "icejam");

            migrationBuilder.DropTable(
                name: "RiverConditionTypes",
                schema: "icejam");

            migrationBuilder.DropTable(
                name: "StageTypes",
                schema: "icejam");

            migrationBuilder.DropTable(
                name: "WeatherConditionTypes",
                schema: "icejam");

            migrationBuilder.DropTable(
                name: "DamageTypes",
                schema: "icejam");

            migrationBuilder.DropTable(
                name: "IceJams",
                schema: "icejam");

            migrationBuilder.DropTable(
                name: "JamTypes",
                schema: "icejam");

            migrationBuilder.DropTable(
                name: "Observers",
                schema: "icejam");

            migrationBuilder.DropTable(
                name: "Sites",
                schema: "icejam");

            migrationBuilder.DropTable(
                name: "Agencies",
                schema: "icejam");

            migrationBuilder.DropTable(
                name: "Roles",
                schema: "icejam");
        }
    }
}
