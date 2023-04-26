using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data
{
    public class MercaderiaData : IEntityTypeConfiguration<Mercaderia>
    {
        public void Configure(EntityTypeBuilder<Mercaderia> entityBuilder)
        {
            entityBuilder.HasData
            (
                new Mercaderia
                {
                    MercaderiaId = 1,
                    Nombre = "Empanadas de Carne",
                    Precio = 300,
                    Ingredientes = "2 tazas de harina de trigo\r\n| 1 cucharadita de sal\r\n| 1/2 taza de agua tibia\r\n| 1/4 taza de aceite de oliva\r\n| 1 cebolla picada\r\n| 2 dientes de ajo picados\r\n| 1/2 kilo de carne molida\r\n| 1/2 cucharadita de comino",
                    Preparacion = "En un bol grande, mezcla la harina y la sal. Agrega el agua tibia y el aceite de oliva. Amasa hasta que quede una masa suave y homogénea.\r\n| Cubre la masa con un paño y déjala reposar durante 30 minutos.\r\n| Precalienta el horno a 200°C.",
                    Imagen = "https://comidasparaguayas.com/wp-content/uploads/2019/11/empanada-de-carne-paraguaya_700x465.jpg",
                    TipoMercaderiaId = 1
                },

                new Mercaderia
                {
                    MercaderiaId = 2,
                    Nombre = "Rollitos de primavera",
                    Precio = 1186,
                    Ingredientes = "8 láminas de papel de arroz\r\n| 150 gramos de fideos de arroz\r\n| 1 zanahoria rallada\r\n| 1/2 pepino rallado\r\n| 1/4 taza de cilantro fresco picado\r\n| 8 hojas de lechuga\r\n| 8 hojas de menta fresca\r\n| 1 cucharada de salsa de soja",
                    Preparacion = "Coloca los fideos de arroz en un recipiente y cúbrelos con agua caliente. Déjalos reposar durante 10-15 minutos o hasta que estén blandos. Escúrrelos y reserva",
                    Imagen = "https://www.elmundoeats.com/wp-content/uploads/2019/01/Spring-Rolls.jpg",
                    TipoMercaderiaId = 1
                },

                new Mercaderia
                {
                    MercaderiaId = 3,
                    Nombre = "Pollo al Curry",
                    Precio = 1500,
                    Ingredientes = "4 pechugas de pollo sin piel, cortadas en cubos\r\n| 1 cebolla picada\r\n| 3 dientes de ajo picados\r\n| 2 cucharadas de jengibre fresco rallado\r\n| 2 cucharadas de curry en polvo\r\n| 1 lata de leche de coco\r\n| 1/2 taza de caldo de pollo",
                    Preparacion = "En una olla o sartén grande, calienta el aceite de oliva a fuego medio. Agrega la cebolla y cocina hasta que esté suave y translúcida, unos 5 minutos.\r\n| Agrega el ajo, el jengibre y el curry en polvo y cocina por un minuto, hasta que estén fragantes",
                    Imagen = "https://i.blogs.es/9ea7a4/pollo_curry-copia/650_1200.jpg",
                    TipoMercaderiaId = 2
                },

                new Mercaderia
                {
                    MercaderiaId = 4,
                    Nombre = "Milanesa Napolitana",
                    Precio = 1800,
                    Ingredientes = "4 filetes de carne (puedes usar carne de res, pollo o ternera)\r\n| 2 huevos batidos\r\n| 1 taza de pan rallado\r\n| Sal y pimienta al gusto\r\n| Aceite vegetal para freír\r\n| 4 rebanadas de jamón\r\n| 4 rebanadas de queso mozzarella",
                    Preparacion = "Prepara los filetes de carne: aplana cada uno con un mazo de carne o con un rodillo, hasta que tengan un grosor de aproximadamente 1 cm. Sazónalos con sal y pimienta al gusto",
                    Imagen = "https://www.paulinacocina.net/wp-content/uploads/2015/03/P1150541-e1439164269502.jpg",
                    TipoMercaderiaId = 2
                },

                new Mercaderia
                {
                    MercaderiaId = 5,
                    Nombre = "Canelones de Verdura",
                    Precio = 1600,
                    Ingredientes = "12-15 placas de canelones\r\n| 1 calabacín mediano\r\n| 1 berenjena mediana\r\n| 2 zanahorias medianas\r\n| 1 cebolla mediana\r\n| 2 dientes de ajo picados\r\n| 1 taza de espinacas frescas\r\n| 2 tazas de salsa de tomate",
                    Preparacion = "Precalienta el horno a 180°C.\r\n| Cocina las placas de canelones según las instrucciones del paquete, hasta que estén al dente. Escúrrelas y enjuágalas con agua fría para detener la cocción. Reserva",
                    Imagen = "https://editorialtelevisa.brightspotcdn.com/wp-content/uploads/2021/04/canelones-de-pollo-con-espinacas.jpg",
                    TipoMercaderiaId = 3
                },

                new Mercaderia
                {
                    MercaderiaId = 6,
                    Nombre = "Sorrentinos de Jamon y Queso",
                    Precio = 1650,
                    Ingredientes = "1 paquete de sorrentinos de jamón y queso (puedes encontrarlos en la sección de congelados)\r\n| 2 cucharadas de aceite de oliva\r\n| 1 cebolla picada finamente\r\n| 2 dientes de ajo picados finamente\r\n| 1/2 taza de caldo de pollo",
                    Preparacion = "Cocina los sorrentinos en agua hirviendo con sal durante el tiempo recomendado en el paquete, hasta que estén al dente. Escúrrelos y resérvalos.\r\n| Calienta el aceite de oliva en una sartén a fuego medio",
                    Imagen = "https://imag.bonviveur.com/sorrentinos-rellenos-de-jamon-y-queso-con-salsa-marinara.jpg",
                    TipoMercaderiaId = 3
                },

                new Mercaderia
                {
                    MercaderiaId = 7,
                    Nombre = "Bife de chorizo",
                    Precio = 2100,
                    Ingredientes = "4 bifes de chorizo de 250 gramos cada uno\r\n| Sal gruesa\r\n| Pimienta negra molida\r\n| Aceite de oliva",
                    Preparacion = "Retira los bifes de chorizo de la nevera y deja que se pongan a temperatura ambiente durante 30 minutos antes de cocinarlos.\r\n| Precalienta la parrilla a fuego alto y cepilla la parrilla con aceite de oliva para evitar que la carne se pegue",
                    Imagen = "https://www.comedera.com/wp-content/uploads/2022/06/bife-de-chorizo.jpg",
                    TipoMercaderiaId = 4
                },

                new Mercaderia
                {
                    MercaderiaId = 8,
                    Nombre = "Asado",
                    Precio = 2500,
                    Ingredientes = "1 kilo de carne de asado (puede ser bife de chorizo, vacío, entraña, costillar, o el corte de tu preferencia)\r\n| Sal gruesa\r\n| Chimichurri (opcional)",
                    Preparacion = "Retira la carne de la nevera y deja que se ponga a temperatura ambiente durante 30-45 minutos antes de cocinarla.\r\n| Prepara la parrilla y asegúrate de que las brasas estén calientes.\r\n| Espolvorea la carne con sal gruesa",
                    Imagen = "https://resizer.iproimg.com/unsafe/880x/filters:format(webp)/https://assets.iprofesional.com/assets/jpg/2021/10/525015.jpg",
                    TipoMercaderiaId = 4
                },

                new Mercaderia
                {
                    MercaderiaId = 9,
                    Nombre = "Pizza Margarita",
                    Precio = 1950,
                    Ingredientes = "Masa de pizza (puedes hacerla casera o comprarla lista)\r\n| 1 taza de salsa de tomate\r\n| 250 gramos de mozzarella fresca\r\n| 10 hojas de albahaca fresca\r\n| Aceite de oliva",
                    Preparacion = "Precalienta el horno a 220 grados Celsius.\r\n| Extiende la masa de pizza sobre una bandeja para horno. Si la masa es casera, asegúrate de hornearla ligeramente antes de agregar los ingredientes, esto ayudará a que quede crujiente",
                    Imagen = "https://www.annarecetasfaciles.com/files/pizza-margarita-1-scaled.jpg",
                    TipoMercaderiaId = 5
                },

                new Mercaderia
                {
                    MercaderiaId = 10,
                    Nombre = "Pizza Cuatro Quesos",
                    Precio = 2200,
                    Ingredientes = "Masa de pizza (puedes hacerla casera o comprarla lista)\r\n| 1 taza de salsa de tomate\r\n| 150 gramos de queso mozzarella rallado\r\n| 50 gramos de queso gorgonzola o queso azul\r\n| 50 gramos de queso de cabra\r\n| 50 gramos de queso parmesano rallado",
                    Preparacion = "Precalienta el horno a 220 grados Celsius.\r\n| Extiende la masa de pizza sobre una bandeja para horno. Si la masa es casera, asegúrate de hornearla ligeramente antes de agregar los ingredientes, esto ayudará a que quede crujiente.",
                    Imagen = "https://www.comedera.com/wp-content/uploads/2022/04/Pizza-cuatro-quesos-shutterstock_1514858234.jpg",
                    TipoMercaderiaId = 5
                },

                new Mercaderia
                {
                    MercaderiaId = 11,
                    Nombre = "Sandwich de atún",
                    Precio = 1000,
                    Ingredientes = "2 latas de atún en agua, escurrido\r\n| 1/4 de taza de mayonesa\r\n| 1/4 de taza de cebolla picada finamente\r\n| 2 cucharadas de jugo de limón\r\n| 1 cucharadita de mostaza dijon\r\n| 1/4 de cucharadita de sal\r\n| 1/4 de cucharadita de pimienta",
                    Preparacion = "En un tazón grande, mezcla el atún, la mayonesa, la cebolla, el jugo de limón, la mostaza, la sal y la pimienta.\r\n| Corta los panes por la mitad y coloca una hoja de lechuga y una rodaja de tomate en cada pan",
                    Imagen = "https://www.pequerecetas.com/wp-content/uploads/2010/05/como-hacer-sandwich-de-atun.jpg",
                    TipoMercaderiaId = 6
                },

                new Mercaderia
                {
                    MercaderiaId = 12,
                    Nombre = "Panini de jamón y queso",
                    Precio = 800,
                    Ingredientes = "4 panes para panini\r\n| 8 rebanadas de jamón cocido\r\n| 8 rebanadas de queso mozzarella\r\n| 1/4 de taza de pesto de albahaca\r\n| 2 cucharadas de mantequilla derretida",
                    Preparacion = "Precalienta una sandwichera o plancha a fuego medio-alto.\r\n| Abre los panes para panini y unta el pesto de albahaca en la mitad inferior de cada pan.\r\n| Coloca 2 rebanadas de jamón cocido y 2 rebanadas de queso mozzarella sobre el pesto",
                    Imagen = "https://pizzamarket.com/wp-content/uploads/2020/06/PANINI-JAMON-Y-QUESO.jpg",
                    TipoMercaderiaId = 6
                },

                new Mercaderia
                {
                    MercaderiaId = 13,
                    Nombre = "Ensalada César",
                    Precio = 1050,
                    Ingredientes = "1 lechuga romana grande, lavada y cortada en trozos\r\n| 2 tazas de crutones\r\n| 1/2 taza de queso parmesano rallado\r\n| 2 pechugas de pollo, cocidas y cortadas en tiras\r\n| Sal y pimienta al gusto\r\n| Aceite de oliva\r\n| Aderezo César",
                    Preparacion = "En una sartén grande, calienta un poco de aceite de oliva a fuego medio. Agrega las tiras de pollo y sazona con sal y pimienta al gusto",
                    Imagen = "https://www.cocinacaserayfacil.net/wp-content/uploads/2018/06/Ensalada-cesar.jpg",
                    TipoMercaderiaId = 7
                },

                new Mercaderia
                {
                    MercaderiaId = 14,
                    Nombre = "Ensalada Mediterránea",
                    Precio = 1150,
                    Ingredientes = "1 lechuga romana, lavada y cortada en trozos\r\n| 1 taza de tomates cherry, cortados por la mitad\r\n| 1/2 taza de aceitunas negras, sin hueso\r\n| 1/2 taza de pepinos, cortados en rodajas\r\n| 1/2 taza de queso feta, desmenuzado",
                    Preparacion = "En un tazón grande, mezcla la lechuga romana, los tomates cherry, las aceitunas negras, los pepinos, el queso feta y la cebolla roja",
                    Imagen = "https://assets.unileversolutions.com/recipes-v2/209800.jpg",
                    TipoMercaderiaId = 7
                },

                new Mercaderia
                {
                    MercaderiaId = 15,
                    Nombre = "Agua fresca",
                    Precio = 500,
                    Ingredientes = "1 litro de agua\r\n4 limones grandes\r\n| 1/2 taza de azúcar (o al gusto)\r\n| Hielo al gusto",
                    Preparacion = "Exprime los limones para obtener el jugo y reserva.\r\nEn una jarra grande, mezcla el agua y el azúcar hasta que el azúcar se disuelva por completo.\r\n| Agrega el jugo de limón a la jarra y mezcla bien",
                    Imagen = "https://i2.wp.com/espejored.com/wp-content/uploads/2019/10/agua-potable-1.jpg?fit=798%2C1200&ssl=1",
                    TipoMercaderiaId = 8
                },

                new Mercaderia
                {
                    MercaderiaId = 16,
                    Nombre = "Jugo de Naranja",
                    Precio = 600,
                    Ingredientes = "4-6 naranjas maduras\r\n| Azúcar o edulcorante al gusto (opcional)\r\n| Agua fría (opcional)",
                    Preparacion = "Lava bien las naranjas y córtalas por la mitad.\r\n| Usa un exprimidor de cítricos para exprimir las naranjas y obtener el jugo. Si no tienes un exprimidor, puedes cortar las naranjas en trozos y procesarlas en una licuadora hasta obtener un líquido",
                    Imagen = "https://images.ecestaticos.com/4pf3S6T-4p3m68lVpNi1FNSsRY0=/0x0:1699x1130/1200x900/filters:fill(white):format(jpg)/f.elconfidencial.com%2Foriginal%2Fe8d%2Fa2d%2Ff42%2Fe8da2df4282557bd4975dbf7feb13143.jpg",
                    TipoMercaderiaId = 8
                },

                new Mercaderia
                {
                    MercaderiaId = 17,
                    Nombre = "Galaxitra - American IPA",
                    Precio = 1550,
                    Ingredientes = "4 kg de malta de cebada (pale ale)\r\n| 350 g de malta crystal 40L\r\n| 350 g de malta Vienna\r\n| 20 g de lúpulo Warrior (60 minutos)\r\n| 30 g de lúpulo Citra (20 minutos)\r\n| 30 g de lúpulo Galaxy (20 minutos)",
                    Preparacion = "Macera las maltas en agua a 66°C durante 60 minutos.\r\n| Filtra el mosto y ponlo a hervir.\r\n| Añade 20 g de lúpulo Warrior al inicio de la cocción y deja hervir durante 60 minutos.\r\n| A los 20 minutos, añade 30 g de lúpulo Citra",
                    Imagen = "https://assets.untappd.com/photos/2022_01_29/753fb24bccb877e0ba79fb01be5c8f8f_640x640.jpg",
                    TipoMercaderiaId = 9
                },

                new Mercaderia
                {
                    MercaderiaId = 18,
                    Nombre = "Flanders Red - Sour Power",
                    Precio = 1550,
                    Ingredientes = "4 kg de malta Pilsner\r\n| 1 kg de malta Vienna\r\n| 500 g de malta Munich\r\n| 500 g de malta Crystal 40L\r\n| 200 g de malta Wheat\r\n| 500 g de azúcar belga (candi sugar)\r\n| 30 g de lúpulo Saaz (60 minutos)",
                    Preparacion = "Macera las maltas en agua a 66°C durante 60 minutos.\r\n| Filtra el mosto y ponlo a hervir.\r\n| Añade el azúcar belga y el lúpulo Saaz al inicio de la cocción y deja hervir durante 60 minutos",
                    Imagen = "https://assets.untappd.com/photos/2023_04_04/7e998172a2ad65469839247db0a5c06d_640x640.jpg",
                    TipoMercaderiaId = 9
                },

                new Mercaderia
                {
                    MercaderiaId = 19,
                    Nombre = "Tiramisú",
                    Precio = 700,
                    Ingredientes = "500 gramos de queso mascarpone\r\n3 huevos\r\n| 150 gramos de azúcar\r\n| 300 ml de café fuerte\r\n| 200 gramos de bizcochos de soletilla\r\n| Cacao en polvo",
                    Preparacion = "Separa las claras y las yemas de los huevos en dos tazones diferentes.\r\n| Añade el azúcar a las yemas y bátelas hasta que se vuelvan pálidas y espumosas.\r\n| Añade el queso mascarpone a la mezcla de yemas y azúcar y mezcla bien.",
                    Imagen = "https://www.recetasderechupete.com/wp-content/uploads/2020/05/Tiramis%C3%BA-italiano.jpg",
                    TipoMercaderiaId = 10
                },

                new Mercaderia
                {
                    MercaderiaId = 20,
                    Nombre = "Flan de Vainilla",
                    Precio = 600,
                    Ingredientes = "1 lata de leche condensada (397 gramos)\r\n| 2 tazas de leche entera\r\n| 4 huevos\r\n| 1 cucharadita de esencia de vainilla\r\n| 1/2 taza de azúcar",
                    Preparacion = "Precalienta el horno a 180°C.\r\n| En una olla, calienta la leche condensada y la leche entera a fuego medio, removiendo constantemente, hasta que estén bien mezcladas",
                    Imagen = "https://imag.bonviveur.com/flan-de-vainilla-en-el-plato.jpg",
                    TipoMercaderiaId = 10
                }
            );
        }
    }
}
