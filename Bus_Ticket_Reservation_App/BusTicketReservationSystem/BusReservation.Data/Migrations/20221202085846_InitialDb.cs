using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusReservation.Data.Migrations
{
    public partial class InitialDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Buses",
                columns: table => new
                {
                    BusId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BusName = table.Column<string>(type: "TEXT", nullable: true),
                    TotalSeats = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buses", x => x.BusId);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    CityId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CityName = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.CityId);
                });

            migrationBuilder.CreateTable(
                name: "Passengers",
                columns: table => new
                {
                    PassengerId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Fname = table.Column<string>(type: "TEXT", nullable: true),
                    Lname = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passengers", x => x.PassengerId);
                });

            migrationBuilder.CreateTable(
                name: "Trips",
                columns: table => new
                {
                    TripId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DepartureTime = table.Column<string>(type: "TEXT", nullable: true),
                    ReservationDate = table.Column<string>(type: "TEXT", nullable: true),
                    TicketPrice = table.Column<double>(type: "REAL", nullable: true),
                    EstimatedTime = table.Column<string>(type: "TEXT", nullable: true),
                    BusId = table.Column<int>(type: "INTEGER", nullable: false),
                    DepartureCityId = table.Column<int>(type: "INTEGER", nullable: false),
                    ArrivalCityId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trips", x => x.TripId);
                    table.ForeignKey(
                        name: "FK_Trips_Buses_BusId",
                        column: x => x.BusId,
                        principalTable: "Buses",
                        principalColumn: "BusId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Trips_Cities_ArrivalCityId",
                        column: x => x.ArrivalCityId,
                        principalTable: "Cities",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Trips_Cities_DepartureCityId",
                        column: x => x.DepartureCityId,
                        principalTable: "Cities",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    TicketId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PassengerId = table.Column<int>(type: "INTEGER", nullable: false),
                    TripId = table.Column<int>(type: "INTEGER", nullable: false),
                    SeatNo = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.TicketId);
                    table.ForeignKey(
                        name: "FK_Tickets_Passengers_PassengerId",
                        column: x => x.PassengerId,
                        principalTable: "Passengers",
                        principalColumn: "PassengerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tickets_Trips_TripId",
                        column: x => x.TripId,
                        principalTable: "Trips",
                        principalColumn: "TripId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Buses",
                columns: new[] { "BusId", "BusName", "TotalSeats" },
                values: new object[] { 1, "MAN", 20 });

            migrationBuilder.InsertData(
                table: "Buses",
                columns: new[] { "BusId", "BusName", "TotalSeats" },
                values: new object[] { 2, "Volvo", 30 });

            migrationBuilder.InsertData(
                table: "Buses",
                columns: new[] { "BusId", "BusName", "TotalSeats" },
                values: new object[] { 3, "Mercedes", 40 });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "CityId", "CityName" },
                values: new object[] { 1, "Istanbul" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "CityId", "CityName" },
                values: new object[] { 2, "Belgrade" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "CityId", "CityName" },
                values: new object[] { 3, "Berlin" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "CityId", "CityName" },
                values: new object[] { 4, "Amsterdam" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "CityId", "CityName" },
                values: new object[] { 5, "Paris" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "CityId", "CityName" },
                values: new object[] { 6, "Madrid" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "CityId", "CityName" },
                values: new object[] { 7, "Vienna" });

            migrationBuilder.InsertData(
                table: "Passengers",
                columns: new[] { "PassengerId", "Email", "Fname", "Lname", "PhoneNumber" },
                values: new object[] { 1, "berkgonencc@gmail.com", "Berk", "Gonenc", "5309999999" });

            migrationBuilder.InsertData(
                table: "Passengers",
                columns: new[] { "PassengerId", "Email", "Fname", "Lname", "PhoneNumber" },
                values: new object[] { 2, "ipksml@gmail.com", "Ipek", "Gonenc", "5319999999" });

            migrationBuilder.InsertData(
                table: "Passengers",
                columns: new[] { "PassengerId", "Email", "Fname", "Lname", "PhoneNumber" },
                values: new object[] { 3, "ipksml@gmail.com", "Kunta", "Gonenc", "5319999999" });

            migrationBuilder.InsertData(
                table: "Passengers",
                columns: new[] { "PassengerId", "Email", "Fname", "Lname", "PhoneNumber" },
                values: new object[] { 4, "hkntmn@gmail.com", "Hakan", "Ataman", "5329999999" });

            migrationBuilder.InsertData(
                table: "Passengers",
                columns: new[] { "PassengerId", "Email", "Fname", "Lname", "PhoneNumber" },
                values: new object[] { 5, "cnbk@gmail.com", "Canberk", "Bulut", "5339999999" });

            migrationBuilder.InsertData(
                table: "Trips",
                columns: new[] { "TripId", "ArrivalCityId", "BusId", "DepartureCityId", "DepartureTime", "EstimatedTime", "ReservationDate", "TicketPrice" },
                values: new object[] { 1, 2, 1, 1, "12:00", "11:00", "2023-08-20", 300.0 });

            migrationBuilder.InsertData(
                table: "Trips",
                columns: new[] { "TripId", "ArrivalCityId", "BusId", "DepartureCityId", "DepartureTime", "EstimatedTime", "ReservationDate", "TicketPrice" },
                values: new object[] { 2, 2, 2, 1, "14:00", "11:00", "2023-08-20", 300.0 });

            migrationBuilder.InsertData(
                table: "Trips",
                columns: new[] { "TripId", "ArrivalCityId", "BusId", "DepartureCityId", "DepartureTime", "EstimatedTime", "ReservationDate", "TicketPrice" },
                values: new object[] { 3, 2, 3, 1, "16:00", "11:00", "2023-08-20", 400.0 });

            migrationBuilder.InsertData(
                table: "Trips",
                columns: new[] { "TripId", "ArrivalCityId", "BusId", "DepartureCityId", "DepartureTime", "EstimatedTime", "ReservationDate", "TicketPrice" },
                values: new object[] { 4, 2, 2, 1, "18:00", "11:00", "2023-08-20", 600.0 });

            migrationBuilder.InsertData(
                table: "Trips",
                columns: new[] { "TripId", "ArrivalCityId", "BusId", "DepartureCityId", "DepartureTime", "EstimatedTime", "ReservationDate", "TicketPrice" },
                values: new object[] { 5, 2, 1, 1, "20:00", "11:00", "2023-08-20", 600.0 });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "TicketId", "PassengerId", "SeatNo", "TripId" },
                values: new object[] { 1, 1, 3, 1 });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "TicketId", "PassengerId", "SeatNo", "TripId" },
                values: new object[] { 2, 2, 4, 1 });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "TicketId", "PassengerId", "SeatNo", "TripId" },
                values: new object[] { 3, 3, 5, 2 });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "TicketId", "PassengerId", "SeatNo", "TripId" },
                values: new object[] { 4, 4, 6, 3 });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "TicketId", "PassengerId", "SeatNo", "TripId" },
                values: new object[] { 5, 5, 7, 4 });

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_PassengerId",
                table: "Tickets",
                column: "PassengerId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_TripId",
                table: "Tickets",
                column: "TripId");

            migrationBuilder.CreateIndex(
                name: "IX_Trips_ArrivalCityId",
                table: "Trips",
                column: "ArrivalCityId");

            migrationBuilder.CreateIndex(
                name: "IX_Trips_BusId",
                table: "Trips",
                column: "BusId");

            migrationBuilder.CreateIndex(
                name: "IX_Trips_DepartureCityId",
                table: "Trips",
                column: "DepartureCityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Passengers");

            migrationBuilder.DropTable(
                name: "Trips");

            migrationBuilder.DropTable(
                name: "Buses");

            migrationBuilder.DropTable(
                name: "Cities");
        }
    }
}
