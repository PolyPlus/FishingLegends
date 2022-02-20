# Fishing Legends
## Introducción
Fishing Legends es un juego de pesca arcade rítmico en el que planificas tu ruta de navegación.

### Propósito y público objetivo
Con Fishing Legends se busca ampliar el clásico minijuego de pesca con mecánicas que añaden planificación previa y momentos de alta intensidad. El objetivo principal es crear un bucle de juego sencillo y accesible para un público casual, en el que cada partida es distinta debido a los eventos aleatorios en el mapa. Además, se ofrecerá una tabla de puntuaciones para los jugadores y las jugadoras que busquen una experiencia más competitiva.

## Mecánicas de Juego
Cada partida comienza en un mapa cuadriculado en el que se escoge la ruta de navegación. La distancia que se puede navegar es limitada y la ruta debe comenzar y terminar en el muelle. El mapa está compuesto principalmente por casillas de agua, por las que se puede navegar, y casillas de tierra, que hay que rodear. Además, en las casillas de agua se distribuirán de forma aleatoria zonas de pesca y zonas rocosas. Dependiendo del número y de la calidad de los peces capturados se obtendrá una puntuación al final de la ruta y dinero con el que comprar recursos o mejorar el barco para futuras expediciones. 

### Pesca
Al atravesar zonas de captura se pasará a la pantalla de pesca compuesta por las siguientes fases:
1. Observación: En el fondo del mar se puede distinguir la posición de peces de distinto tamaño a partir de su silueta. Se puede lanzar cebo al agua para que aparezcan más peces.
2. Lanzamiento de caña: Al pulsar en la pantalla, el personaje se prepara para lanzar la caña. Manteniendo pulsado y arrastrando hacia atrás, se escoge la dirección de lanzamiento. La potencia del lanzamiento dependerá del tiempo que se mantenga pulsado.
3. Espera: Una vez lanzado el anzuelo se puede tirar de la caña pulsando en la pantalla o esperar a que pique un pez. Los peces se mueven de forma aleatoria hasta que el anzuelo entra en su cono de visión. Una vez un pez detecta el anzuelo se dirige hacia él. El pez tocará el anzuelo un número aleatorio de veces hasta morderlo. Si se tira de la caña antes de que muerda el anzuelo, el pez escapará. Si se tira de la caña cuando lo muerde comenzará la pesca rítmica. En caso de no tirar de la caña, el pez se llevará el anzuelo
4. Pesca rítmica: en la parte superior de la pantalla aparecerá una barra con un anzuelo en el centro. Desde la izquierda o la derecha de la barra aparecerán uno o más peces dependiendo del tamaño del pez que se está pescando. Para pescar al pez es necesario pulsar la pantalla en el momento en el que el pez se sitúe sobre el anzuelo. En caso de no pulsar en el momento preciso el pez escapará.
5. Combo: Una vez superado el juego de ritmo el pez peleará con el anzuelo. En este momento, se puede esperar a que muerda otro pez y comenzar una nueva pesca rítmica. En este caso, el número de peces que aparecerán en la barra superior aumentará con el número de peces que esté mordiendo el anzuelo. En caso de fallar durante el combo, se perderán a todos los peces. Los peces capturados durante un combo recibirán un multiplicador de puntuación que aumenta con el número de capturas consecutivas.
6. Recogida: Si se pulsa la pantalla mientras uno o más peces pelean con el anzuelo se recogerán los peces y terminará el combo. En este momento, se muestra una breve animación con los peces obtenidos y a continuación se vuelve a la fase de observación.

Este proceso se repite hasta que no queden peces o anzuelos, o se decida continuar con la ruta, volviendo a la pantalla del mapa. Como se mencionó en la fase de observación, se puede utilizar cebo para que aparezcan más peces y continuar la pesca, pero se trata de un recurso limitado. 

### Enemigos y obstáculos

## Interfaz

### Pantallas y bocetos
La interfaz se divide en interfaz de juego y menús
  - Interfaz de Juego
    - Indicador de cebos y anzuelos : Indicadores para indicar al jugador dentro de la zona de juego del numero de cebos y anzuelos del que dispondrá antes de realizar la ruta.
    - Barra de combustible o resistencia : Indicador en forma de barra , para indicar cuanto combustible nos queda para pintar la ruta, y asu vez que indicará cuanto trayecto
      queda por recorrer.   
  - Menús
    - Tienda
    - Inicio de sesión
    - Opciones
        
### Diagramas de flujo
## Arte
### Historia
### Estética
Fishing Legends utilizará una estética sencilla y amigable acorde con el tono del juego. Los modelos 3D se representarán a través de formas geométricas sencillas y colores planos, utilizando la técnica de cell shading para el sombreado. A la hora de realizar los modelos se tendrá en cuenta que el juego utiliza en mayor medida la perspectiva cenital, por lo que se deben poder distinguir desde arriba.
El diseño de los peces no será realista, pero estarán inspirados en peces reales y tendrán variaciones de color. 
Los peces estarán clasificados según su tamaño y rareza:
- Peces pequeños 
- Peces medianos 
- Peces grandes 
- Otros
- Criaturas marinas: Solamente aparecerán en caso de que intercepten la ruta de navegación.

Cada categoría utilizará el mismo modelo debajo del agua, consistente de una sombra en la que no se podrá distinguir la especie concreta de pez.

### Música y Sonido
Música
- Música del Menú: música tranquila que transmita sensación de bienvenida
- Música de selección de ruta: música de aventura marítima
- Música de Pesca: música de ambiente con oleaje y gaviotas
- Música de Juego Rítmico: Percusión sencilla con la que distinguir el ritmo con facilidad.

Sonido
Menú:
- Pulsar un botón
- Cancelar/Volver atrás
- Iniciar una partida

Ruta marítima
- Pintar una casilla
- Alcanzar una zona de pesca
- Alcanzar una criatura marina
- Llegar al destino

Pesca
- Cargar el lanzamiento de la caña
- Lanzar el anzuelo
- Impacto del anzuelo con el agua
- Impacto de cebo con el agua
- Pez tocando el anzuelo
- Pez mordiendo el anzuelo
- Pez peleando con el anzuelo
- Pulsar en el momento adecuado en el juego de ritmo
- Pulsar en el momento perfecto en el juego de ritmo
- Pulsar en el momento equivocado en el juego de ritmo
- Recoger el anzuelo sin pez
- Recoger el anzuelo con pez
- Recompensa al capturar un pez
- Derrota al romper un anzuelo
- Volver a la ruta
## Redes Sociales
