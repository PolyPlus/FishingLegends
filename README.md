# Fishing Legends
- Álvaro González: Progamador principal

- Ana Márquez: Modeladora 3D y programadora

- Marta García: Artista 2D y programadora

- Álvaro Ramírez: Diseñador de Juego y programador

- Oihane Roca: Modeladora 3D y programadora
## Introducción
Fishing Legends es un juego de pesca arcade rítmico en el que planificas tu ruta de navegación.

### Propósito y público objetivo
Con Fishing Legends se busca ampliar el clásico minijuego de pesca con mecánicas que añaden planificación previa y momentos de alta intensidad. El objetivo principal es crear un bucle de juego sencillo y accesible para un público casual, en el que cada partida es distinta debido a los eventos aleatorios en el mapa. Además, se ofrecerá una tabla de puntuaciones para los jugadores y las jugadoras que busquen una experiencia más competitiva.

## Mecánicas de Juego
Cada partida comienza escogiendo la ruta de navegación. La distancia que se puede navegar es limitada y la ruta debe comenzar y terminar en el muelle. El objetivo será atravesar zonas de pesca y capturar al mayor número de peces posible. Al terminar la ruta, se obtendrá una puntuación y monedas, con las que comprar recursos o mejorar el barco para futuras expediciones.

### Planificación de ruta 
Al comenzar una expedición, se dibuja el recorrido en un mapa dividido en casillas cuadriculadas. El mapa está compuesto principalmente por casillas de agua, por las que se puede navegar, y casillas de tierra, que hay que rodear. Además, en las casillas de agua se distribuirán de forma aleatoria zonas de pesca y obstáculos.

### Zonas de Pesca
Al atravesar zonas de pesca se pasará a una pantalla en la que se verá al personaje en su bote en la parte inferior y la silueta de peces de distinto tamaño bajo el agua. La pesca está compuesta por las siguientes fases:
- Observación: Desde la superficie, se puede distinguir la posición y el número de peces a partir de su silueta. Se puede lanzar cebo al agua para que aparezcan más peces.
Lanzamiento de caña: Al pulsar en la pantalla, el personaje se prepara para lanzar la caña. Manteniendo pulsado y arrastrando hacia atrás, se escoge la dirección de lanzamiento. La potencia del lanzamiento dependerá del tiempo que se mantenga pulsado.
- Espera: Una vez lanzado el anzuelo se puede tirar de la caña pulsando en la pantalla o esperar a que pique un pez. Los peces se mueven de forma aleatoria hasta que el anzuelo entra en su cono de visión. Una vez un pez detecta el anzuelo se dirige hacia él. El pez tocará el anzuelo un número aleatorio de veces hasta morderlo. Si se tira de la caña antes de que muerda el anzuelo, el pez escapará. Si se tira de la caña cuando lo muerde comenzará la pesca rítmica. En caso de no tirar de la caña, el pez se llevará el anzuelo
- Pesca rítmica: en la parte superior de la pantalla aparecerá una barra con un anzuelo en el centro. Desde la izquierda o la derecha de la barra aparecerán uno o más peces dependiendo del tamaño del pez que se está pescando. Para pescar al pez es necesario pulsar la pantalla en el momento en el que el pez se sitúe sobre el anzuelo. En caso de no pulsar en el momento preciso el pez escapará.
- Combo: Una vez superado el juego de ritmo el pez peleará con el anzuelo. En este momento, se puede esperar a que muerda otro pez y comenzar una nueva pesca rítmica. En este caso, el número de peces que aparecerán en la barra superior aumentará con el número de peces que esté mordiendo el anzuelo. En caso de fallar durante el combo, se perderán a todos los peces. Los peces capturados durante un combo recibirán un multiplicador de puntuación que aumenta con el número de capturas consecutivas.
- Recogida: Si se pulsa la pantalla mientras uno o más peces pelean con el anzuelo se recogerán los peces y terminará el combo. En este momento, se muestra una breve animación con los peces obtenidos y a continuación se vuelve a la fase de observación.

Este proceso se repite hasta que no queden peces o anzuelos, o se decida continuar con la ruta, volviendo a la pantalla del mapa. Como se mencionó en la fase de observación, se puede utilizar cebo para que aparezcan más peces y continuar la pesca, pero se trata de un recurso limitado.

### Tesoros
En las casillas de tierra situadas en la orilla podrán aparecer tesoros de forma aleatoria. Se recogerán automáticamente al pasar por la casilla de al lado y podrán contener cebos, anzuelos o monedas. Los tesoros recogidos incrementarán la puntuación final.

### Criaturas Marinas
Hay una probabilidad de que aparezca una criatura marina en una casilla de agua. La criatura se representará como una silueta grande bajo el agua y se moverá de forma aleatoria a otras casillas de agua durante la ruta. Si el bote pasa por una casilla con una criatura marina, comenzará un enfrentamiento con la criatura.

- Lanzamiento de caña: se lanzará la caña al igual que en las zonas de pesca. En esta ocasión aparecerá una silueta de gran tamaño que morderá el cebo con tanta fuerza que arrastrará el bote
- Evitar obstáculos: Mientras el bote es arrastrado de izquierda a derecha, se podrá mover verticalmente manteniendo pulsado en la pantalla y moviendo el cursor arriba y abajo. Aparecerán rocas desde la parte derecha de la pantalla que se deberán evitar.
- Pesca rítmica: entre las secciones en las que hay que evitar obstáculos habrá que superar un juego de ritmo al igual que en las zonas de pesca, pero más complicado.

Tras superar 3 pescas rítmicas se capturará a la criatura marina y se continuará la ruta. En caso de perder todos los anzuelos, se terminará la ruta.
        
## Arte
### Historia
Una tarde tranquila de domingo en el pub, nuestro protagonista oye a unos marineros hablar sobre una leyenda que dice que una extraña criatura merodea por aquellas aguas. Se trata del temible Leviatán, al que únicamente una persona asegura haber visto un día entre la niebla, y entonces desplegó las velas y salió por patas.
 
Motivado por la majestuosidad de esta criatura, el protagonista decide investigar sobre el paradero del Leviatán y cree haber dado con una pista. Siguiendo su instinto aventurero, decide hacerse con una humilde barca, rescatar su caña una vez olvidada en el trastero, y adentrarse en las sorprendentes aguas que le rodean.  
En ellas se esforzará por encontrar a todas las criaturas que las habitan, conseguir recursos para mejorar su equipo, hacer frente a todos los peligros que allí se encuentren, y soñar con que quizá algún día, llegue a toparse con el legendario Leviatán. 

### Estética
Fishing Legends utilizará una estética sencilla y amigable acorde con el tono del juego. Los modelos 3D se representarán a través de formas geométricas sencillas y colores planos, utilizando la técnica de cell shading para el sombreado. A la hora de realizar los modelos se tendrá en cuenta que el juego utiliza en mayor medida la perspectiva cenital, por lo que se deben poder distinguir desde arriba.
El diseño de los peces no será realista, pero estarán inspirados en peces reales y tendrán variaciones de color. 
Los peces estarán clasificados según su tamaño y rareza:
- Peces pequeños 
- Peces medianos 
- Peces grandes 
- Criaturas marinas

Cada categoría utilizará el mismo modelo debajo del agua, consistente de una sombra en la que no se podrá distinguir la especie concreta de pez.

### Música y Sonido
Música
- Menú: música tranquila para dar la bienvenida.
- Planificación de ruta: música de aventura marítima.
- Pesca: música de ambiente con oleaje y gaviotas que invite a relajarse con la pesca.
- Criatura marina: música épica de enfrentamiento.

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
- Volver a la ruta


## Redes Sociales
Portfolio: 
https://polyplus.github.io/

Twitter:
https://twitter.com/PolyplusStudios

Youtube: 
https://www.youtube.com/channel/UCORDpONBjQlp1iaylG8L9uw
