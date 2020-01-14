using Microsoft.EntityFrameworkCore.Migrations;

namespace RestaurantData.Migrations
{
    public partial class initial8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RestaurantCuisines_CuisineType_CuisinetypeId",
                table: "RestaurantCuisines");

            migrationBuilder.DropForeignKey(
                name: "FK_RestaurantCuisines_Restaurants_RestaurantId",
                table: "RestaurantCuisines");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RestaurantCuisines",
                table: "RestaurantCuisines");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CuisineType",
                table: "CuisineType");

            migrationBuilder.RenameTable(
                name: "RestaurantCuisines",
                newName: "Restaurantcuisines");

            migrationBuilder.RenameTable(
                name: "CuisineType",
                newName: "Cuisinetypes");

            migrationBuilder.RenameIndex(
                name: "IX_RestaurantCuisines_RestaurantId",
                table: "Restaurantcuisines",
                newName: "IX_Restaurantcuisines_RestaurantId");

            migrationBuilder.RenameIndex(
                name: "IX_RestaurantCuisines_CuisinetypeId",
                table: "Restaurantcuisines",
                newName: "IX_Restaurantcuisines_CuisinetypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Restaurantcuisines",
                table: "Restaurantcuisines",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cuisinetypes",
                table: "Cuisinetypes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurantcuisines_Cuisinetypes_CuisinetypeId",
                table: "Restaurantcuisines",
                column: "CuisinetypeId",
                principalTable: "Cuisinetypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurantcuisines_Restaurants_RestaurantId",
                table: "Restaurantcuisines",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Restaurantcuisines_Cuisinetypes_CuisinetypeId",
                table: "Restaurantcuisines");

            migrationBuilder.DropForeignKey(
                name: "FK_Restaurantcuisines_Restaurants_RestaurantId",
                table: "Restaurantcuisines");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Restaurantcuisines",
                table: "Restaurantcuisines");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cuisinetypes",
                table: "Cuisinetypes");

            migrationBuilder.RenameTable(
                name: "Restaurantcuisines",
                newName: "RestaurantCuisines");

            migrationBuilder.RenameTable(
                name: "Cuisinetypes",
                newName: "CuisineType");

            migrationBuilder.RenameIndex(
                name: "IX_Restaurantcuisines_RestaurantId",
                table: "RestaurantCuisines",
                newName: "IX_RestaurantCuisines_RestaurantId");

            migrationBuilder.RenameIndex(
                name: "IX_Restaurantcuisines_CuisinetypeId",
                table: "RestaurantCuisines",
                newName: "IX_RestaurantCuisines_CuisinetypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RestaurantCuisines",
                table: "RestaurantCuisines",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CuisineType",
                table: "CuisineType",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RestaurantCuisines_CuisineType_CuisinetypeId",
                table: "RestaurantCuisines",
                column: "CuisinetypeId",
                principalTable: "CuisineType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RestaurantCuisines_Restaurants_RestaurantId",
                table: "RestaurantCuisines",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
