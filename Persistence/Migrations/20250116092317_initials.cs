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
                    username = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    normalized_username = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
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
                name: "CategoryTypes",
                schema: "dbo",
                columns: table => new
                {
                    category_type_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    category_type_name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryTypes", x => x.category_type_id);
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
                name: "Customers",
                schema: "dbo",
                columns: table => new
                {
                    customer_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    scores = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.customer_id);
                    table.ForeignKey(
                        name: "FK_Customers_Account_customer_id",
                        column: x => x.customer_id,
                        principalSchema: "dbo",
                        principalTable: "Account",
                        principalColumn: "account_id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "Stores",
                schema: "dbo",
                columns: table => new
                {
                    store_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    store_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StorePhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    store_email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    store_address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    store_image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    account_id = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stores", x => x.store_id);
                    table.ForeignKey(
                        name: "FK_Stores_Account_account_id",
                        column: x => x.account_id,
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
                name: "Type",
                schema: "dbo",
                columns: table => new
                {
                    type_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    category_type_id = table.Column<int>(type: "int", nullable: true),
                    type_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Type", x => x.type_id);
                    table.ForeignKey(
                        name: "FK_Type_CategoryTypes_category_type_id",
                        column: x => x.category_type_id,
                        principalSchema: "dbo",
                        principalTable: "CategoryTypes",
                        principalColumn: "category_type_id");
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
                name: "SearchHistories",
                schema: "dbo",
                columns: table => new
                {
                    search_history_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    customer_id = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    search_key = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    search_log = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SearchHistories", x => x.search_history_id);
                    table.ForeignKey(
                        name: "FK_SearchHistories_Customers_customer_id",
                        column: x => x.customer_id,
                        principalSchema: "dbo",
                        principalTable: "Customers",
                        principalColumn: "customer_id");
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                schema: "dbo",
                columns: table => new
                {
                    order_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    customer_id = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    total_price = table.Column<double>(type: "float", nullable: true),
                    order_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    order_status = table.Column<int>(type: "int", nullable: true),
                    use_score = table.Column<double>(type: "float", nullable: true),
                    add_score = table.Column<double>(type: "float", nullable: true),
                    is_feedback = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    store_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.order_id);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_customer_id",
                        column: x => x.customer_id,
                        principalSchema: "dbo",
                        principalTable: "Customers",
                        principalColumn: "customer_id");
                    table.ForeignKey(
                        name: "FK_Orders_Stores_store_id",
                        column: x => x.store_id,
                        principalSchema: "dbo",
                        principalTable: "Stores",
                        principalColumn: "store_id");
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
                    store_id = table.Column<int>(type: "int", nullable: true),
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
                        name: "FK_Product_Stores_store_id",
                        column: x => x.store_id,
                        principalSchema: "dbo",
                        principalTable: "Stores",
                        principalColumn: "store_id");
                    table.ForeignKey(
                        name: "FK_Product_Sub_Categories_sub_categoty_id",
                        column: x => x.sub_categoty_id,
                        principalSchema: "dbo",
                        principalTable: "Sub_Categories",
                        principalColumn: "sub_category_id");
                });

            migrationBuilder.CreateTable(
                name: "CartItems",
                schema: "dbo",
                columns: table => new
                {
                    cart_item_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    product_color_type_id = table.Column<int>(type: "int", nullable: true),
                    product_id = table.Column<int>(type: "int", nullable: true),
                    color_id = table.Column<int>(type: "int", nullable: true),
                    type_id = table.Column<int>(type: "int", nullable: true),
                    quantity = table.Column<int>(type: "int", nullable: true),
                    customer_id = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.cart_item_id);
                    table.ForeignKey(
                        name: "FK_CartItems_Colors_color_id",
                        column: x => x.color_id,
                        principalSchema: "dbo",
                        principalTable: "Colors",
                        principalColumn: "color_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartItems_Customers_customer_id",
                        column: x => x.customer_id,
                        principalSchema: "dbo",
                        principalTable: "Customers",
                        principalColumn: "customer_id");
                    table.ForeignKey(
                        name: "FK_CartItems_Product_product_id",
                        column: x => x.product_id,
                        principalSchema: "dbo",
                        principalTable: "Product",
                        principalColumn: "product_id");
                    table.ForeignKey(
                        name: "FK_CartItems_Type_type_id",
                        column: x => x.type_id,
                        principalSchema: "dbo",
                        principalTable: "Type",
                        principalColumn: "type_id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "Feedbacks",
                schema: "dbo",
                columns: table => new
                {
                    feedback_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    account_id = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    product_id = table.Column<int>(type: "int", nullable: true),
                    feedback_date = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValue: new DateTime(2025, 1, 16, 16, 23, 16, 933, DateTimeKind.Local).AddTicks(8071)),
                    feedback_describe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    is_feedback = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedbacks", x => x.feedback_id);
                    table.ForeignKey(
                        name: "FK_Feedbacks_Account_account_id",
                        column: x => x.account_id,
                        principalSchema: "dbo",
                        principalTable: "Account",
                        principalColumn: "account_id");
                    table.ForeignKey(
                        name: "FK_Feedbacks_Product_product_id",
                        column: x => x.product_id,
                        principalSchema: "dbo",
                        principalTable: "Product",
                        principalColumn: "product_id");
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    product_id = table.Column<int>(type: "int", nullable: true),
                    color_id = table.Column<int>(type: "int", nullable: true),
                    type_id = table.Column<int>(type: "int", nullable: true),
                    store_id = table.Column<int>(type: "int", nullable: true),
                    quantity = table.Column<int>(type: "int", nullable: true),
                    OrderId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.id);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Colors_color_id",
                        column: x => x.color_id,
                        principalSchema: "dbo",
                        principalTable: "Colors",
                        principalColumn: "color_id");
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_OrderId",
                        column: x => x.OrderId,
                        principalSchema: "dbo",
                        principalTable: "Orders",
                        principalColumn: "order_id");
                    table.ForeignKey(
                        name: "FK_OrderDetails_Product_product_id",
                        column: x => x.product_id,
                        principalSchema: "dbo",
                        principalTable: "Product",
                        principalColumn: "product_id");
                    table.ForeignKey(
                        name: "FK_OrderDetails_Stores_store_id",
                        column: x => x.store_id,
                        principalSchema: "dbo",
                        principalTable: "Stores",
                        principalColumn: "store_id");
                    table.ForeignKey(
                        name: "FK_OrderDetails_Type_type_id",
                        column: x => x.type_id,
                        principalSchema: "dbo",
                        principalTable: "Type",
                        principalColumn: "type_id");
                });

            migrationBuilder.CreateTable(
                name: "ProductImages",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    product_id = table.Column<int>(type: "int", nullable: true),
                    url_image = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductImages_Product_product_id",
                        column: x => x.product_id,
                        principalSchema: "dbo",
                        principalTable: "Product",
                        principalColumn: "product_id",
                        onDelete: ReferentialAction.SetNull);
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

            migrationBuilder.CreateTable(
                name: "ImageFeedbacks",
                schema: "dbo",
                columns: table => new
                {
                    image_feedback_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    image_feedback_url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    feedback_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageFeedbacks", x => x.image_feedback_id);
                    table.ForeignKey(
                        name: "FK_ImageFeedbacks_Feedbacks_feedback_id",
                        column: x => x.feedback_id,
                        principalSchema: "dbo",
                        principalTable: "Feedbacks",
                        principalColumn: "feedback_id",
                        onDelete: ReferentialAction.Cascade);
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
                column: "normalized_username",
                unique: true,
                filter: "[normalized_username] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_color_id",
                schema: "dbo",
                table: "CartItems",
                column: "color_id");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_customer_id",
                schema: "dbo",
                table: "CartItems",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_product_id",
                schema: "dbo",
                table: "CartItems",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_type_id",
                schema: "dbo",
                table: "CartItems",
                column: "type_id");

            migrationBuilder.CreateIndex(
                name: "IX_ColorProduct_ProductColorsColorId",
                schema: "dbo",
                table: "ColorProduct",
                column: "ProductColorsColorId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_account_id",
                schema: "dbo",
                table: "Feedbacks",
                column: "account_id");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_product_id",
                schema: "dbo",
                table: "Feedbacks",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_ImageFeedbacks_feedback_id",
                schema: "dbo",
                table: "ImageFeedbacks",
                column: "feedback_id");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_color_id",
                schema: "dbo",
                table: "OrderDetails",
                column: "color_id");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderId",
                schema: "dbo",
                table: "OrderDetails",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_product_id",
                schema: "dbo",
                table: "OrderDetails",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_store_id",
                schema: "dbo",
                table: "OrderDetails",
                column: "store_id");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_type_id",
                schema: "dbo",
                table: "OrderDetails",
                column: "type_id");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_customer_id",
                schema: "dbo",
                table: "Orders",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_store_id",
                schema: "dbo",
                table: "Orders",
                column: "store_id");

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
                name: "IX_Product_store_id",
                schema: "dbo",
                table: "Product",
                column: "store_id");

            migrationBuilder.CreateIndex(
                name: "IX_Product_sub_categoty_id",
                schema: "dbo",
                table: "Product",
                column: "sub_categoty_id");

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_product_id",
                schema: "dbo",
                table: "ProductImages",
                column: "product_id");

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
                name: "IX_SearchHistories_customer_id",
                schema: "dbo",
                table: "SearchHistories",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_Stores_account_id",
                schema: "dbo",
                table: "Stores",
                column: "account_id",
                unique: true,
                filter: "[account_id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Sub_Categories_category_id",
                schema: "dbo",
                table: "Sub_Categories",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_Type_category_type_id",
                schema: "dbo",
                table: "Type",
                column: "category_type_id");

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
                name: "CartItems",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ColorProduct",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ImageFeedbacks",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "OrderDetails",
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
                name: "SearchHistories",
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
                name: "Feedbacks",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Orders",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Colors",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Type",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Roles",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Product",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Customers",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "CategoryTypes",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Brands",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Stores",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Sub_Categories",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Account",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Categories",
                schema: "dbo");
        }
    }
}
