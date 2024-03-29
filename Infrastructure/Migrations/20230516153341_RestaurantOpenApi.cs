﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RestaurantOpenApi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FormaEntrega",
                columns: table => new
                {
                    FormaEntregaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormaEntrega", x => x.FormaEntregaId);
                });

            migrationBuilder.CreateTable(
                name: "TipoMercaderia",
                columns: table => new
                {
                    TipoMercaderiaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoMercaderia", x => x.TipoMercaderiaId);
                });

            migrationBuilder.CreateTable(
                name: "Comanda",
                columns: table => new
                {
                    ComandaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PrecioTotal = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FormaEntregaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comanda", x => x.ComandaId);
                    table.ForeignKey(
                        name: "FK_Comanda_FormaEntrega_FormaEntregaId",
                        column: x => x.FormaEntregaId,
                        principalTable: "FormaEntrega",
                        principalColumn: "FormaEntregaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Mercaderia",
                columns: table => new
                {
                    MercaderiaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Precio = table.Column<int>(type: "int", nullable: false),
                    Ingredientes = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Preparacion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Imagen = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    TipoMercaderiaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mercaderia", x => x.MercaderiaId);
                    table.ForeignKey(
                        name: "FK_Mercaderia_TipoMercaderia_TipoMercaderiaId",
                        column: x => x.TipoMercaderiaId,
                        principalTable: "TipoMercaderia",
                        principalColumn: "TipoMercaderiaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ComandaMercaderia",
                columns: table => new
                {
                    ComandaMercaderiaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MercaderiaId = table.Column<int>(type: "int", nullable: false),
                    ComandaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComandaMercaderia", x => x.ComandaMercaderiaId);
                    table.ForeignKey(
                        name: "FK_ComandaMercaderia_Comanda_ComandaId",
                        column: x => x.ComandaId,
                        principalTable: "Comanda",
                        principalColumn: "ComandaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComandaMercaderia_Mercaderia_MercaderiaId",
                        column: x => x.MercaderiaId,
                        principalTable: "Mercaderia",
                        principalColumn: "MercaderiaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "FormaEntrega",
                columns: new[] { "FormaEntregaId", "Descripcion" },
                values: new object[,]
                {
                    { 1, "Salon" },
                    { 2, "Delivery" },
                    { 3, "Pedidos Ya" }
                });

            migrationBuilder.InsertData(
                table: "TipoMercaderia",
                columns: new[] { "TipoMercaderiaId", "Descripcion" },
                values: new object[,]
                {
                    { 1, "Entrada" },
                    { 2, "Minutas" },
                    { 3, "Pastas" },
                    { 4, "Parrilla" },
                    { 5, "Pizzas" },
                    { 6, "Sandwich" },
                    { 7, "Ensaladas" },
                    { 8, "Bebidas" },
                    { 9, "Cerveza Artesanal" },
                    { 10, "Postres" }
                });

            migrationBuilder.InsertData(
                table: "Mercaderia",
                columns: new[] { "MercaderiaId", "Imagen", "Ingredientes", "Nombre", "Precio", "Preparacion", "TipoMercaderiaId" },
                values: new object[,]
                {
                    { 1, "https://comidasparaguayas.com/wp-content/uploads/2019/11/empanada-de-carne-paraguaya_700x465.jpg", "2 tazas de harina de trigo\r\n1 cucharadita de sal\r\n1/2 taza de agua tibia\r\n1/4 taza de aceite de oliva\r\n1 cebolla picada\r\n2 dientes de ajo picados\r\n1/2 kilo de carne molida\r\n1/2 cucharadita de comino", "Empanadas de Carne", 300, "En un bol grande, mezcla la harina y la sal. Agrega el agua tibia y el aceite de oliva. Amasa hasta que quede una masa suave y homogénea.\r\nCubre la masa con un paño y déjala reposar durante 30 minutos.\r\nPrecalienta el horno a 200°C.", 1 },
                    { 2, "https://www.elmundoeats.com/wp-content/uploads/2019/01/Spring-Rolls.jpg", "8 láminas de papel de arroz\r\n150 gramos de fideos de arroz\r\n1 zanahoria rallada\r\n1/2 pepino rallado\r\n1/4 taza de cilantro fresco picado\r\n8 hojas de lechuga\r\n8 hojas de menta fresca\r\n1 cucharada de salsa de soja", "Rollitos de primavera", 1186, "Coloca los fideos de arroz en un recipiente y cúbrelos con agua caliente. Déjalos reposar durante 10-15 minutos o hasta que estén blandos. Escúrrelos y reserva", 1 },
                    { 3, "https://i.blogs.es/9ea7a4/pollo_curry-copia/650_1200.jpg", "4 pechugas de pollo sin piel, cortadas en cubos\r\n1 cebolla picada\r\n3 dientes de ajo picados\r\n2 cucharadas de jengibre fresco rallado\r\n2 cucharadas de curry en polvo\r\n1 lata de leche de coco\r\n1/2 taza de caldo de pollo", "Pollo al Curry", 1500, "En una olla o sartén grande, calienta el aceite de oliva a fuego medio. Agrega la cebolla y cocina hasta que esté suave y translúcida, unos 5 minutos.\r\nAgrega el ajo, el jengibre y el curry en polvo y cocina por un minuto, hasta que estén fragantes", 2 },
                    { 4, "https://www.paulinacocina.net/wp-content/uploads/2015/03/P1150541-e1439164269502.jpg", "4 filetes de carne (puedes usar carne de res, pollo o ternera)\r\n2 huevos batidos\r\n1 taza de pan rallado\r\nSal y pimienta al gusto\r\nAceite vegetal para freír\r\n4 rebanadas de jamón\r\n4 rebanadas de queso mozzarella", "Milanesa Napolitana", 1800, "Prepara los filetes de carne: aplana cada uno con un mazo de carne o con un rodillo, hasta que tengan un grosor de aproximadamente 1 cm. Sazónalos con sal y pimienta al gusto", 2 },
                    { 5, "https://editorialtelevisa.brightspotcdn.com/wp-content/uploads/2021/04/canelones-de-pollo-con-espinacas.jpg", "12-15 placas de canelones\r\n1 calabacín mediano\r\n1 berenjena mediana\r\n2 zanahorias medianas\r\n1 cebolla mediana\r\n2 dientes de ajo picados\r\n1 taza de espinacas frescas\r\n2 tazas de salsa de tomate", "Canelones de Verdura", 1600, "Precalienta el horno a 180°C.\r\nCocina las placas de canelones según las instrucciones del paquete, hasta que estén al dente. Escúrrelas y enjuágalas con agua fría para detener la cocción. Reserva", 3 },
                    { 6, "https://imag.bonviveur.com/sorrentinos-rellenos-de-jamon-y-queso-con-salsa-marinara.jpg", "1 paquete de sorrentinos de jamón y queso (puedes encontrarlos en la sección de congelados)\r\n2 cucharadas de aceite de oliva\r\n1 cebolla picada finamente\r\n2 dientes de ajo picados finamente\r\n1/2 taza de caldo de pollo", "Sorrentinos de Jamon y Queso", 1650, "Cocina los sorrentinos en agua hirviendo con sal durante el tiempo recomendado en el paquete, hasta que estén al dente. Escúrrelos y resérvalos.\r\nCalienta el aceite de oliva en una sartén a fuego medio", 3 },
                    { 7, "https://www.comedera.com/wp-content/uploads/2022/06/bife-de-chorizo.jpg", "4 bifes de chorizo de 250 gramos cada uno\r\nSal gruesa\r\nPimienta negra molida\r\nAceite de oliva", "Bife de chorizo", 2100, "Retira los bifes de chorizo de la nevera y deja que se pongan a temperatura ambiente durante 30 minutos antes de cocinarlos.\r\nPrecalienta la parrilla a fuego alto y cepilla la parrilla con aceite de oliva para evitar que la carne se pegue", 4 },
                    { 8, "https://resizer.iproimg.com/unsafe/880x/filters:format(webp)/https://assets.iprofesional.com/assets/jpg/2021/10/525015.jpg", "1 kilo de carne de asado (puede ser bife de chorizo, vacío, entraña, costillar, o el corte de tu preferencia)\r\nSal gruesa\r\nChimichurri (opcional)", "Asado", 2500, "Retira la carne de la nevera y deja que se ponga a temperatura ambiente durante 30-45 minutos antes de cocinarla.\r\nPrepara la parrilla y asegúrate de que las brasas estén calientes.\r\nEspolvorea la carne con sal gruesa", 4 },
                    { 9, "https://www.annarecetasfaciles.com/files/pizza-margarita-1-scaled.jpg", "Masa de pizza (puedes hacerla casera o comprarla lista)\r\n1 taza de salsa de tomate\r\n250 gramos de mozzarella fresca\r\n10 hojas de albahaca fresca\r\nAceite de oliva", "Pizza Margarita", 1950, "Precalienta el horno a 220 grados Celsius.\r\nExtiende la masa de pizza sobre una bandeja para horno. Si la masa es casera, asegúrate de hornearla ligeramente antes de agregar los ingredientes, esto ayudará a que quede crujiente", 5 },
                    { 10, "https://www.comedera.com/wp-content/uploads/2022/04/Pizza-cuatro-quesos-shutterstock_1514858234.jpg", "Masa de pizza (puedes hacerla casera o comprarla lista)\r\n1 taza de salsa de tomate\r\n150 gramos de queso mozzarella rallado\r\n50 gramos de queso gorgonzola o queso azul\r\n50 gramos de queso de cabra\r\n50 gramos de queso parmesano rallado", "Pizza Cuatro Quesos", 2200, "Precalienta el horno a 220 grados Celsius.\r\nExtiende la masa de pizza sobre una bandeja para horno. Si la masa es casera, asegúrate de hornearla ligeramente antes de agregar los ingredientes, esto ayudará a que quede crujiente.", 5 },
                    { 11, "https://www.pequerecetas.com/wp-content/uploads/2010/05/como-hacer-sandwich-de-atun.jpg", "2 latas de atún en agua, escurrido\r\n1/4 de taza de mayonesa\r\n1/4 de taza de cebolla picada finamente\r\n2 cucharadas de jugo de limón\r\n1 cucharadita de mostaza dijon\r\n1/4 de cucharadita de sal\r\n1/4 de cucharadita de pimienta", "Sandwich de atún", 1000, "En un tazón grande, mezcla el atún, la mayonesa, la cebolla, el jugo de limón, la mostaza, la sal y la pimienta.\r\nCorta los panes por la mitad y coloca una hoja de lechuga y una rodaja de tomate en cada pan", 6 },
                    { 12, "https://pizzamarket.com/wp-content/uploads/2020/06/PANINI-JAMON-Y-QUESO.jpg", "4 panes para panini\r\n8 rebanadas de jamón cocido\r\n8 rebanadas de queso mozzarella\r\n1/4 de taza de pesto de albahaca\r\n2 cucharadas de mantequilla derretida", "Panini de jamón y queso", 800, "Precalienta una sandwichera o plancha a fuego medio-alto.\r\nAbre los panes para panini y unta el pesto de albahaca en la mitad inferior de cada pan.\r\nColoca 2 rebanadas de jamón cocido y 2 rebanadas de queso mozzarella sobre el pesto", 6 },
                    { 13, "https://www.cocinacaserayfacil.net/wp-content/uploads/2018/06/Ensalada-cesar.jpg", "1 lechuga romana grande, lavada y cortada en trozos\r\n2 tazas de crutones\r\n1/2 taza de queso parmesano rallado\r\n2 pechugas de pollo, cocidas y cortadas en tiras\r\nSal y pimienta al gusto\r\nAceite de oliva\r\nAderezo César", "Ensalada César", 1050, "En una sartén grande, calienta un poco de aceite de oliva a fuego medio. Agrega las tiras de pollo y sazona con sal y pimienta al gusto", 7 },
                    { 14, "https://assets.unileversolutions.com/recipes-v2/209800.jpg", "1 lechuga romana, lavada y cortada en trozos\r\n1 taza de tomates cherry, cortados por la mitad\r\n1/2 taza de aceitunas negras, sin hueso\r\n1/2 taza de pepinos, cortados en rodajas\r\n1/2 taza de queso feta, desmenuzado", "Ensalada Mediterránea", 1150, "En un tazón grande, mezcla la lechuga romana, los tomates cherry, las aceitunas negras, los pepinos, el queso feta y la cebolla roja", 7 },
                    { 15, "https://i2.wp.com/espejored.com/wp-content/uploads/2019/10/agua-potable-1.jpg?fit=798%2C1200&ssl=1", "1 litro de agua\r\n4 limones grandes\r\n1/2 taza de azúcar (o al gusto)\r\nHielo al gusto", "Agua fresca", 500, "Exprime los limones para obtener el jugo y reserva.\r\nEn una jarra grande, mezcla el agua y el azúcar hasta que el azúcar se disuelva por completo.\r\nAgrega el jugo de limón a la jarra y mezcla bien", 8 },
                    { 16, "https://images.ecestaticos.com/4pf3S6T-4p3m68lVpNi1FNSsRY0=/0x0:1699x1130/1200x900/filters:fill(white):format(jpg)/f.elconfidencial.com%2Foriginal%2Fe8d%2Fa2d%2Ff42%2Fe8da2df4282557bd4975dbf7feb13143.jpg", "4-6 naranjas maduras\r\nAzúcar o edulcorante al gusto (opcional)\r\nAgua fría (opcional)", "Jugo de Naranja", 600, "Lava bien las naranjas y córtalas por la mitad.\r\nUsa un exprimidor de cítricos para exprimir las naranjas y obtener el jugo. Si no tienes un exprimidor, puedes cortar las naranjas en trozos y procesarlas en una licuadora hasta obtener un líquido", 8 },
                    { 17, "https://assets.untappd.com/photos/2022_01_29/753fb24bccb877e0ba79fb01be5c8f8f_640x640.jpg", "4 kg de malta de cebada (pale ale)\r\n350 g de malta crystal 40L\r\n350 g de malta Vienna\r\n20 g de lúpulo Warrior (60 minutos)\r\n30 g de lúpulo Citra (20 minutos)\r\n30 g de lúpulo Galaxy (20 minutos)", "Galaxitra - American IPA", 1550, "Macera las maltas en agua a 66°C durante 60 minutos.\r\nFiltra el mosto y ponlo a hervir.\r\nAñade 20 g de lúpulo Warrior al inicio de la cocción y deja hervir durante 60 minutos.\r\nA los 20 minutos, añade 30 g de lúpulo Citra", 9 },
                    { 18, "https://assets.untappd.com/photos/2023_04_04/7e998172a2ad65469839247db0a5c06d_640x640.jpg", "4 kg de malta Pilsner\r\n1 kg de malta Vienna\r\n500 g de malta Munich\r\n500 g de malta Crystal 40L\r\n200 g de malta Wheat\r\n500 g de azúcar belga (candi sugar)\r\n30 g de lúpulo Saaz (60 minutos)", "Flanders Red - Sour Power", 1550, "Macera las maltas en agua a 66°C durante 60 minutos.\r\nFiltra el mosto y ponlo a hervir.\r\nAñade el azúcar belga y el lúpulo Saaz al inicio de la cocción y deja hervir durante 60 minutos", 9 },
                    { 19, "https://www.recetasderechupete.com/wp-content/uploads/2020/05/Tiramis%C3%BA-italiano.jpg", "500 gramos de queso mascarpone\r\n3 huevos\r\n150 gramos de azúcar\r\n300 ml de café fuerte\r\n200 gramos de bizcochos de soletilla\r\nCacao en polvo", "Tiramisú", 700, "Separa las claras y las yemas de los huevos en dos tazones diferentes.\r\nAñade el azúcar a las yemas y bátelas hasta que se vuelvan pálidas y espumosas.\r\nAñade el queso mascarpone a la mezcla de yemas y azúcar y mezcla bien.", 10 },
                    { 20, "https://imag.bonviveur.com/flan-de-vainilla-en-el-plato.jpg", "1 lata de leche condensada (397 gramos)\r\n2 tazas de leche entera\r\n4 huevos\r\n1 cucharadita de esencia de vainilla\r\n1/2 taza de azúcar", "Flan de Vainilla", 600, "Precalienta el horno a 180°C.\r\nEn una olla, calienta la leche condensada y la leche entera a fuego medio, removiendo constantemente, hasta que estén bien mezcladas", 10 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comanda_FormaEntregaId",
                table: "Comanda",
                column: "FormaEntregaId");

            migrationBuilder.CreateIndex(
                name: "IX_ComandaMercaderia_ComandaId",
                table: "ComandaMercaderia",
                column: "ComandaId");

            migrationBuilder.CreateIndex(
                name: "IX_ComandaMercaderia_MercaderiaId",
                table: "ComandaMercaderia",
                column: "MercaderiaId");

            migrationBuilder.CreateIndex(
                name: "IX_Mercaderia_TipoMercaderiaId",
                table: "Mercaderia",
                column: "TipoMercaderiaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComandaMercaderia");

            migrationBuilder.DropTable(
                name: "Comanda");

            migrationBuilder.DropTable(
                name: "Mercaderia");

            migrationBuilder.DropTable(
                name: "FormaEntrega");

            migrationBuilder.DropTable(
                name: "TipoMercaderia");
        }
    }
}
