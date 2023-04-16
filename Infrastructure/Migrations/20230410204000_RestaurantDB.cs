using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RestaurantDB : Migration
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
                    MercaderiaId = table.Column<int>(type: "int", nullable: false),
                    ComandaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ComandaMercaderiaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComandaMercaderia", x => new { x.MercaderiaId, x.ComandaId });
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
                    { 1, "Imagen.PNG", "2 tazas de harina de trigo\r\n| 1 cucharadita de sal\r\n| 1/2 taza de agua tibia\r\n| 1/4 taza de aceite de oliva\r\n| 1 cebolla picada\r\n| 2 dientes de ajo picados\r\n| 1/2 kilo de carne molida\r\n| 1/2 cucharadita de comino", "Empanadas de Carne", 300, "En un bol grande, mezcla la harina y la sal. Agrega el agua tibia y el aceite de oliva. Amasa hasta que quede una masa suave y homogénea.\r\n| Cubre la masa con un paño y déjala reposar durante 30 minutos.\r\n| Precalienta el horno a 200°C.", 1 },
                    { 2, "Imagen.PNG", "8 láminas de papel de arroz\r\n| 150 gramos de fideos de arroz\r\n| 1 zanahoria rallada\r\n| 1/2 pepino rallado\r\n| 1/4 taza de cilantro fresco picado\r\n| 8 hojas de lechuga\r\n| 8 hojas de menta fresca\r\n| 1 cucharada de salsa de soja", "Rollitos de primavera", 1186, "Coloca los fideos de arroz en un recipiente y cúbrelos con agua caliente. Déjalos reposar durante 10-15 minutos o hasta que estén blandos. Escúrrelos y reserva", 1 },
                    { 3, "Imagen.PNG", "4 pechugas de pollo sin piel, cortadas en cubos\r\n| 1 cebolla picada\r\n| 3 dientes de ajo picados\r\n| 2 cucharadas de jengibre fresco rallado\r\n| 2 cucharadas de curry en polvo\r\n| 1 lata de leche de coco\r\n| 1/2 taza de caldo de pollo", "Pollo al Curry", 1500, "En una olla o sartén grande, calienta el aceite de oliva a fuego medio. Agrega la cebolla y cocina hasta que esté suave y translúcida, unos 5 minutos.\r\n| Agrega el ajo, el jengibre y el curry en polvo y cocina por un minuto, hasta que estén fragantes", 2 },
                    { 4, "Imagen.PNG", "4 filetes de carne (puedes usar carne de res, pollo o ternera)\r\n| 2 huevos batidos\r\n| 1 taza de pan rallado\r\n| Sal y pimienta al gusto\r\n| Aceite vegetal para freír\r\n| 4 rebanadas de jamón\r\n| 4 rebanadas de queso mozzarella", "Milanesa Napolitana", 1800, "Prepara los filetes de carne: aplana cada uno con un mazo de carne o con un rodillo, hasta que tengan un grosor de aproximadamente 1 cm. Sazónalos con sal y pimienta al gusto", 2 },
                    { 5, "Imagen.PNG", "12-15 placas de canelones\r\n| 1 calabacín mediano\r\n| 1 berenjena mediana\r\n| 2 zanahorias medianas\r\n| 1 cebolla mediana\r\n| 2 dientes de ajo picados\r\n| 1 taza de espinacas frescas\r\n| 2 tazas de salsa de tomate", "Canelones de Verdura", 1600, "Precalienta el horno a 180°C.\r\n| Cocina las placas de canelones según las instrucciones del paquete, hasta que estén al dente. Escúrrelas y enjuágalas con agua fría para detener la cocción. Reserva", 3 },
                    { 6, "Imagen.PNG", "1 paquete de sorrentinos de jamón y queso (puedes encontrarlos en la sección de congelados)\r\n| 2 cucharadas de aceite de oliva\r\n| 1 cebolla picada finamente\r\n| 2 dientes de ajo picados finamente\r\n| 1/2 taza de caldo de pollo", "Sorrentinos de Jamon y Queso", 1650, "Cocina los sorrentinos en agua hirviendo con sal durante el tiempo recomendado en el paquete, hasta que estén al dente. Escúrrelos y resérvalos.\r\n| Calienta el aceite de oliva en una sartén a fuego medio", 3 },
                    { 7, "Imagen.PNG", "4 bifes de chorizo de 250 gramos cada uno\r\n| Sal gruesa\r\n| Pimienta negra molida\r\n| Aceite de oliva", "Bife de chorizo", 2100, "Retira los bifes de chorizo de la nevera y deja que se pongan a temperatura ambiente durante 30 minutos antes de cocinarlos.\r\n| Precalienta la parrilla a fuego alto y cepilla la parrilla con aceite de oliva para evitar que la carne se pegue", 4 },
                    { 8, "Imagen.PNG", "1 kilo de carne de asado (puede ser bife de chorizo, vacío, entraña, costillar, o el corte de tu preferencia)\r\n| Sal gruesa\r\n| Chimichurri (opcional)", "Asado", 2500, "Retira la carne de la nevera y deja que se ponga a temperatura ambiente durante 30-45 minutos antes de cocinarla.\r\n| Prepara la parrilla y asegúrate de que las brasas estén calientes.\r\n| Espolvorea la carne con sal gruesa", 4 },
                    { 9, "Imagen.PNG", "Masa de pizza (puedes hacerla casera o comprarla lista)\r\n| 1 taza de salsa de tomate\r\n| 250 gramos de mozzarella fresca\r\n| 10 hojas de albahaca fresca\r\n| Aceite de oliva", "Pizza Margarita", 1950, "Precalienta el horno a 220 grados Celsius.\r\n| Extiende la masa de pizza sobre una bandeja para horno. Si la masa es casera, asegúrate de hornearla ligeramente antes de agregar los ingredientes, esto ayudará a que quede crujiente", 5 },
                    { 10, "Imagen.PNG", "Masa de pizza (puedes hacerla casera o comprarla lista)\r\n| 1 taza de salsa de tomate\r\n| 150 gramos de queso mozzarella rallado\r\n| 50 gramos de queso gorgonzola o queso azul\r\n| 50 gramos de queso de cabra\r\n| 50 gramos de queso parmesano rallado", "Pizza Cuatro Quesos", 2200, "Precalienta el horno a 220 grados Celsius.\r\n| Extiende la masa de pizza sobre una bandeja para horno. Si la masa es casera, asegúrate de hornearla ligeramente antes de agregar los ingredientes, esto ayudará a que quede crujiente.", 5 },
                    { 11, "Imagen.PNG", "2 latas de atún en agua, escurrido\r\n| 1/4 de taza de mayonesa\r\n| 1/4 de taza de cebolla picada finamente\r\n| 2 cucharadas de jugo de limón\r\n| 1 cucharadita de mostaza dijon\r\n| 1/4 de cucharadita de sal\r\n| 1/4 de cucharadita de pimienta", "Sandwich de atún", 1000, "En un tazón grande, mezcla el atún, la mayonesa, la cebolla, el jugo de limón, la mostaza, la sal y la pimienta.\r\n| Corta los panes por la mitad y coloca una hoja de lechuga y una rodaja de tomate en cada pan", 6 },
                    { 12, "Imagen.PNG", "4 panes para panini\r\n| 8 rebanadas de jamón cocido\r\n| 8 rebanadas de queso mozzarella\r\n| 1/4 de taza de pesto de albahaca\r\n| 2 cucharadas de mantequilla derretida", "Panini de jamón y queso", 800, "Precalienta una sandwichera o plancha a fuego medio-alto.\r\n| Abre los panes para panini y unta el pesto de albahaca en la mitad inferior de cada pan.\r\n| Coloca 2 rebanadas de jamón cocido y 2 rebanadas de queso mozzarella sobre el pesto", 6 },
                    { 13, "Imagen.PNG", "1 lechuga romana grande, lavada y cortada en trozos\r\n| 2 tazas de crutones\r\n| 1/2 taza de queso parmesano rallado\r\n| 2 pechugas de pollo, cocidas y cortadas en tiras\r\n| Sal y pimienta al gusto\r\n| Aceite de oliva\r\n| Aderezo César", "Ensalada César", 1050, "En una sartén grande, calienta un poco de aceite de oliva a fuego medio. Agrega las tiras de pollo y sazona con sal y pimienta al gusto", 7 },
                    { 14, "Imagen.PNG", "1 lechuga romana, lavada y cortada en trozos\r\n| 1 taza de tomates cherry, cortados por la mitad\r\n| 1/2 taza de aceitunas negras, sin hueso\r\n| 1/2 taza de pepinos, cortados en rodajas\r\n| 1/2 taza de queso feta, desmenuzado", "Ensalada Mediterránea", 1150, "En un tazón grande, mezcla la lechuga romana, los tomates cherry, las aceitunas negras, los pepinos, el queso feta y la cebolla roja", 7 },
                    { 15, "Imagen.PNG", "1 litro de agua\r\n4 limones grandes\r\n| 1/2 taza de azúcar (o al gusto)\r\n| Hielo al gusto", "Agua fresca", 500, "Exprime los limones para obtener el jugo y reserva.\r\nEn una jarra grande, mezcla el agua y el azúcar hasta que el azúcar se disuelva por completo.\r\n| Agrega el jugo de limón a la jarra y mezcla bien", 8 },
                    { 16, "Imagen.PNG", "4-6 naranjas maduras\r\n| Azúcar o edulcorante al gusto (opcional)\r\n| Agua fría (opcional)", "Jugo de Naranja", 600, "Lava bien las naranjas y córtalas por la mitad.\r\n| Usa un exprimidor de cítricos para exprimir las naranjas y obtener el jugo. Si no tienes un exprimidor, puedes cortar las naranjas en trozos y procesarlas en una licuadora hasta obtener un líquido", 8 },
                    { 17, "Imagen.PNG", "4 kg de malta de cebada (pale ale)\r\n| 350 g de malta crystal 40L\r\n| 350 g de malta Vienna\r\n| 20 g de lúpulo Warrior (60 minutos)\r\n| 30 g de lúpulo Citra (20 minutos)\r\n| 30 g de lúpulo Galaxy (20 minutos)", "Galaxitra - American IPA", 1550, "Macera las maltas en agua a 66°C durante 60 minutos.\r\n| Filtra el mosto y ponlo a hervir.\r\n| Añade 20 g de lúpulo Warrior al inicio de la cocción y deja hervir durante 60 minutos.\r\n| A los 20 minutos, añade 30 g de lúpulo Citra", 9 },
                    { 18, "Imagen.PNG", "4 kg de malta Pilsner\r\n| 1 kg de malta Vienna\r\n| 500 g de malta Munich\r\n| 500 g de malta Crystal 40L\r\n| 200 g de malta Wheat\r\n| 500 g de azúcar belga (candi sugar)\r\n| 30 g de lúpulo Saaz (60 minutos)", "Flanders Red - Sour Power", 1550, "Macera las maltas en agua a 66°C durante 60 minutos.\r\n| Filtra el mosto y ponlo a hervir.\r\n| Añade el azúcar belga y el lúpulo Saaz al inicio de la cocción y deja hervir durante 60 minutos", 9 },
                    { 19, "Imagen.PNG", "500 gramos de queso mascarpone\r\n3 huevos\r\n| 150 gramos de azúcar\r\n| 300 ml de café fuerte\r\n| 200 gramos de bizcochos de soletilla\r\n| Cacao en polvo", "Tiramisú", 700, "Separa las claras y las yemas de los huevos en dos tazones diferentes.\r\n| Añade el azúcar a las yemas y bátelas hasta que se vuelvan pálidas y espumosas.\r\n| Añade el queso mascarpone a la mezcla de yemas y azúcar y mezcla bien.", 10 },
                    { 20, "Imagen.PNG", "1 lata de leche condensada (397 gramos)\r\n| 2 tazas de leche entera\r\n| 4 huevos\r\n| 1 cucharadita de esencia de vainilla\r\n| 1/2 taza de azúcar", "Flan", 600, "Precalienta el horno a 180°C.\r\n| En una olla, calienta la leche condensada y la leche entera a fuego medio, removiendo constantemente, hasta que estén bien mezcladas", 10 }
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
