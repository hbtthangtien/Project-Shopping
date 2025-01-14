using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class initials : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Account",
                schema: "dbo",
                columns: table => new
                {
                    account_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    latest_login = table.Column<DateTime>(type: "datetime2", nullable: true),
                    scores = table.Column<double>(type: "float", nullable: true),
                    username = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    normalized_email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    email_confirmed = table.Column<bool>(type: "bit", nullable: false),
                    password_hash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sercurity_stamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    concurrency_stamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    phone_number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    phone_number_confirmed = table.Column<bool>(type: "bit", nullable: false),
                    two_factor_enabled = table.Column<bool>(type: "bit", nullable: false),
                    lockout_end = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    lockout_enabled = table.Column<bool>(type: "bit", nullable: false),
                    access_failed_count = table.Column<int>(type: "int", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.account_id);
                });

            migrationBuilder.CreateTable(
                name: "Brands",
                schema: "dbo",
                columns: table => new
                {
                    brand_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    brand_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    brand_image = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.brand_id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                schema: "dbo",
                columns: table => new
                {
                    category_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    category_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.category_id);
                });

            migrationBuilder.CreateTable(
                name: "Colors",
                schema: "dbo",
                columns: table => new
                {
                    color_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    color_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colors", x => x.color_id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    role_name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    normalized_name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    concurrency_stamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Type",
                schema: "dbo",
                columns: table => new
                {
                    type_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    type_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Type", x => x.type_id);
                });

            migrationBuilder.CreateTable(
                name: "Profile",
                schema: "dbo",
                columns: table => new
                {
                    profile_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fullname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    gender = table.Column<int>(type: "int", nullable: true),
                    avatar_profile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    phone_number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    identity_card = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    date_of_birth = table.Column<DateOnly>(type: "date", nullable: true),
                    account_id = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profile", x => x.profile_id);
                    table.ForeignKey(
                        name: "FK_Profile_Account_account_id",
                        column: x => x.account_id,
                        principalSchema: "dbo",
                        principalTable: "Account",
                        principalColumn: "account_id");
                });

            migrationBuilder.CreateTable(
                name: "SearchHistory",
                schema: "dbo",
                columns: table => new
                {
                    SearchHistoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SearchKey = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SearchHistory", x => x.SearchHistoryId);
                    table.ForeignKey(
                        name: "FK_SearchHistory_Account_AccountId",
                        column: x => x.AccountId,
                        principalSchema: "dbo",
                        principalTable: "Account",
                        principalColumn: "account_id");
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    claim_type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    claim_value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaims_Account_user_id",
                        column: x => x.user_id,
                        principalSchema: "dbo",
                        principalTable: "Account",
                        principalColumn: "account_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLogin",
                schema: "dbo",
                columns: table => new
                {
                    login_provider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    provider_key = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    provider_display_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    user_id = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogin", x => new { x.provider_key, x.login_provider });
                    table.ForeignKey(
                        name: "FK_UserLogin_Account_user_id",
                        column: x => x.user_id,
                        principalSchema: "dbo",
                        principalTable: "Account",
                        principalColumn: "account_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                schema: "dbo",
                columns: table => new
                {
                    user_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    login_provider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => new { x.user_id, x.login_provider, x.name });
                    table.ForeignKey(
                        name: "FK_UserTokens_Account_user_id",
                        column: x => x.user_id,
                        principalSchema: "dbo",
                        principalTable: "Account",
                        principalColumn: "account_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sub_Categories",
                schema: "dbo",
                columns: table => new
                {
                    sub_category_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sub_category_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    category_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sub_Categories", x => x.sub_category_id);
                    table.ForeignKey(
                        name: "FK_Category_SubCategory",
                        column: x => x.category_id,
                        principalSchema: "dbo",
                        principalTable: "Categories",
                        principalColumn: "category_id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    role_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    claim_type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    claim_value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaims_Roles_role_id",
                        column: x => x.role_id,
                        principalSchema: "dbo",
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                schema: "dbo",
                columns: table => new
                {
                    user_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    role_is = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => new { x.role_is, x.user_id });
                    table.ForeignKey(
                        name: "FK_UserRole_Account_user_id",
                        column: x => x.user_id,
                        principalSchema: "dbo",
                        principalTable: "Account",
                        principalColumn: "account_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRole_Roles_role_is",
                        column: x => x.role_is,
                        principalSchema: "dbo",
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                schema: "dbo",
                columns: table => new
                {
                    product_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    brand_id = table.Column<int>(type: "int", nullable: true),
                    category_id = table.Column<int>(type: "int", nullable: true),
                    product_name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    sub_categoty_id = table.Column<int>(type: "int", nullable: true),
                    product_description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sale_level = table.Column<int>(type: "int", nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: true, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.product_id);
                    table.ForeignKey(
                        name: "FK_Product_Brands_brand_id",
                        column: x => x.brand_id,
                        principalSchema: "dbo",
                        principalTable: "Brands",
                        principalColumn: "brand_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Product_Categories_category_id",
                        column: x => x.category_id,
                        principalSchema: "dbo",
                        principalTable: "Categories",
                        principalColumn: "category_id");
                    table.ForeignKey(
                        name: "FK_Product_Sub_Categories_sub_categoty_id",
                        column: x => x.sub_categoty_id,
                        principalSchema: "dbo",
                        principalTable: "Sub_Categories",
                        principalColumn: "sub_category_id");
                });

            migrationBuilder.CreateTable(
                name: "ColorProduct",
                schema: "dbo",
                columns: table => new
                {
                    ColorProductId = table.Column<int>(type: "int", nullable: false),
                    ProductColorsColorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColorProduct", x => new { x.ColorProductId, x.ProductColorsColorId });
                    table.ForeignKey(
                        name: "FK_ColorProduct_Colors_ProductColorsColorId",
                        column: x => x.ProductColorsColorId,
                        principalSchema: "dbo",
                        principalTable: "Colors",
                        principalColumn: "color_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ColorProduct_Product_ColorProductId",
                        column: x => x.ColorProductId,
                        principalSchema: "dbo",
                        principalTable: "Product",
                        principalColumn: "product_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductImages",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    UrlImage = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductImages_Product_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "dbo",
                        principalTable: "Product",
                        principalColumn: "product_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductType",
                schema: "dbo",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ProductTypesTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductType", x => new { x.ProductId, x.ProductTypesTypeId });
                    table.ForeignKey(
                        name: "FK_ProductType_Product_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "dbo",
                        principalTable: "Product",
                        principalColumn: "product_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductType_Type_ProductTypesTypeId",
                        column: x => x.ProductTypesTypeId,
                        principalSchema: "dbo",
                        principalTable: "Type",
                        principalColumn: "type_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductTypeColor",
                schema: "dbo",
                columns: table => new
                {
                    product_type_color_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    product_id = table.Column<int>(type: "int", nullable: true),
                    type_id = table.Column<int>(type: "int", nullable: true),
                    color_id = table.Column<int>(type: "int", nullable: true),
                    origin_price = table.Column<double>(type: "float", nullable: true),
                    available = table.Column<int>(type: "int", nullable: true),
                    is_sale = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTypeColor", x => x.product_type_color_id);
                    table.ForeignKey(
                        name: "FK_ProductTypeColor_Colors_color_id",
                        column: x => x.color_id,
                        principalSchema: "dbo",
                        principalTable: "Colors",
                        principalColumn: "color_id");
                    table.ForeignKey(
                        name: "FK_ProductTypeColor_Product_product_id",
                        column: x => x.product_id,
                        principalSchema: "dbo",
                        principalTable: "Product",
                        principalColumn: "product_id");
                    table.ForeignKey(
                        name: "FK_ProductTypeColor_Type_type_id",
                        column: x => x.type_id,
                        principalSchema: "dbo",
                        principalTable: "Type",
                        principalColumn: "type_id");
                });

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "dbo",
                table: "Account",
                column: "normalized_email");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "dbo",
                table: "Account",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ColorProduct_ProductColorsColorId",
                schema: "dbo",
                table: "ColorProduct",
                column: "ProductColorsColorId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_brand_id",
                schema: "dbo",
                table: "Product",
                column: "brand_id");

            migrationBuilder.CreateIndex(
                name: "IX_Product_category_id",
                schema: "dbo",
                table: "Product",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_Product_sub_categoty_id",
                schema: "dbo",
                table: "Product",
                column: "sub_categoty_id");

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_ProductId",
                schema: "dbo",
                table: "ProductImages",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductType_ProductTypesTypeId",
                schema: "dbo",
                table: "ProductType",
                column: "ProductTypesTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTypeColor_color_id",
                schema: "dbo",
                table: "ProductTypeColor",
                column: "color_id");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTypeColor_product_id_color_id_type_id",
                schema: "dbo",
                table: "ProductTypeColor",
                columns: new[] { "product_id", "color_id", "type_id" },
                unique: true,
                filter: "[product_id] IS NOT NULL AND [color_id] IS NOT NULL AND [type_id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTypeColor_type_id",
                schema: "dbo",
                table: "ProductTypeColor",
                column: "type_id");

            migrationBuilder.CreateIndex(
                name: "IX_Profile_account_id",
                schema: "dbo",
                table: "Profile",
                column: "account_id",
                unique: true,
                filter: "[account_id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaims_role_id",
                schema: "dbo",
                table: "RoleClaims",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                schema: "dbo",
                table: "Roles",
                column: "normalized_name",
                unique: true,
                filter: "[normalized_name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_SearchHistory_AccountId",
                schema: "dbo",
                table: "SearchHistory",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Sub_Categories_category_id",
                schema: "dbo",
                table: "Sub_Categories",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_user_id",
                schema: "dbo",
                table: "UserClaims",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogin_user_id",
                schema: "dbo",
                table: "UserLogin",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_user_id",
                schema: "dbo",
                table: "UserRole",
                column: "user_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ColorProduct",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ProductImages",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ProductType",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ProductTypeColor",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Profile",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "RoleClaims",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "SearchHistory",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "UserClaims",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "UserLogin",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "UserRole",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "UserTokens",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Colors",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Product",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Type",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Roles",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Account",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Brands",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Sub_Categories",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Categories",
                schema: "dbo");
        }
    }
}
