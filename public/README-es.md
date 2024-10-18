Trabajando con conjuntos de datos de calidad del aire de muchas fuentes. Herramientas: Excel, .NET 8, Visual Studio

## Sobre el conjunto de datos

### Fuentes
**Oficial**
- [Buenos Aires Data - Calidad de Aire](https://data.buenosaires.gob.ar/dataset/calidad-aire)
- [Calidad del Aire | Buenos Aires Ciudad - Gobierno de la Ciudad Autónoma de Buenos Aires](https://buenosaires.gob.ar/laboratorio-ambiental/calidad-del-aire)
- [Estación Parque Centenario | Buenos Aires Ciudad - Gobierno de la Ciudad Autónoma de Buenos Aires](https://buenosaires.gob.ar/calidad-del-aire/estacion-parque-centenario)
- [Red de Monitoreo - Buenos Aires Ciudad - Calidad Ambiental](https://buenosaires.gob.ar/areas/med_ambiente/apra/calidad_amb/red_monitoreo/mapa.php?menu_id=34233)
- [Obtener contaminantes por día por lugar - Buenos Aires Ciudad - Calidad Ambiental](https://buenosaires.gob.ar/areas/med_ambiente/apra/calidad_amb/red_monitoreo/index.php?estacion=1&menu_id=34234)

**Proveedores externos**
- [Índice de Calidad del Aire (Buenos Aires): Contaminación del Aire en Tiempo Real (aqi.in)](https://www.aqi.in/es/dashboard/argentina/buenos-aires)

**Noticias**
- [Incendios y calidad del aire: Un vínculo inquietante en la Ciudad de Buenos Aires | Sobre La Tierra (uba.ar)](https://sobrelatierra.agro.uba.ar/incendios-y-calidad-del-aire-un-vinculo-inquietante-en-la-ciudad-de-buenos-aires/)
- [Especialistas de la UBA alertan por la calidad del aire en la Ciudad (ambito.com)](https://www.ambito.com/informacion-general/especialistas-la-uba-alertan-la-calidad-del-aire-la-ciudad-n5795059)

### Características de los datos
**Ficha de contaminante - CO.**
![Pasted image 20241016025406.png](public/Pasted_image_20241016025406.png)

**Ficha de contaminante - NO2.**
![Pasted image 20241016025633.png](public/Pasted_image_20241016025633.png)

**Ficha de contaminante - PM10.**
![Pasted image 20241016025707.png](public/Pasted_image_20241016025707.png)

**Fuentes recolectoras de datos.**
![Pasted image 20241016025529.png](public/Pasted_image_20241016025529.png)

### Transformando datos
- [Calculating AQI (Air Quality Index) Tutorial (kaggle.com)](https://www.kaggle.com/code/rohanrao/calculating-aqi-air-quality-index-tutorial)
- **Agregar campos faltantes**: _estación_ y _"color" para cada contaminante_ (basado en efectos previamente definidos).

### Enfoque de análisis
| **Combinación** | **Enfoque** | **Caso de Uso** | **Beneficios**  |
|-----------------------------------------------|------------------------------------------------------------------------------------------------|-----------------------------------------------------------------|---------------------------------------------------------------------|
| **Clustering + Árboles de Decisión** | Agrupar por niveles de contaminantes en diferentes ubicaciones, aplicar árboles de decisión para predecir la calidad del aire. | Agrupar patrones de calidad del aire por tiempo/ubicación y predecir mala calidad del aire. | Revela patrones y crea reglas predictivas para clusters específicos. |
| **Árboles de Decisión + Reglas de Asociación**  | Usar árboles de decisión para identificar contaminantes clave, aplicar reglas de asociación para encontrar co-ocurrencias de contaminantes. | Identificar contaminantes clave que causan mala calidad del aire y encontrar patrones de co-ocurrencia. | Descubre contaminantes importantes y co-ocurrencias frecuentes.  |
| **Clustering + Reglas de Asociación** | Agrupar basado en niveles de contaminantes en diferentes ubicaciones, luego aplicar reglas de asociación dentro de cada cluster. | Entender combinaciones de contaminantes que aumentan juntas en diferentes ubicaciones. | Descubrimiento de patrones específicos para clusters de datos de calidad del aire. |
| **Clustering + Árboles de Decisión + Reglas de Asociación** | Agrupar datos, usar árboles de decisión para predecir la calidad del aire y minar reglas de asociación dentro de los clusters. | Análisis integral de la calidad del aire a través del tiempo y ubicaciones. | Enfoque multifacético que combina segmentación, predicción y patrones. |
| **Reglas de Asociación Informadas por Árboles de Decisión** | Usar árboles de decisión para encontrar contaminantes clave, luego aplicar reglas de asociación en estos contaminantes.  | Enfocarse en contaminantes críticos y descubrir patrones relacionados. | Reduce la complejidad al enfocarse en las características más importantes. |

## Registros de Arquitectura
### 1. Sobre la Inyección de la Base de Datos
#### Contexto
Basado en este archivo para una muestra actual: [aspire-samples/samples/AspireShop/AspireShop.BasketService/AspireShop.BasketService.csproj at main · dotnet/aspire-samples (github.com)](https://github.com/dotnet/aspire-samples/blob/main/samples/AspireShop/AspireShop.BasketService/AspireShop.BasketService.csproj)

#### Decisión
Inyectaré la base de datos desde el proyecto `AirQualityApp.ApiService`

### 2. Procesamiento de la Aplicación
#### Contexto
Basado en la experiencia, el objetivo principal de la aplicación será exponer a través de una API/frontend web, el conjunto de datos consumidos/procesados.

#### Decisión
La arquitectura será como:

### 3. Enfoque de Lectura de CSV
#### Contexto
Mis opciones son:
1. Análisis manual.
2. Paquete NuGet `JoshClose/CsvHelper`.

#### Decisión
Usaremos este paquete NuGet: [`JoshClose/CsvHelper`: Biblioteca para ayudar a leer y escribir archivos CSV (github.com)](https://github.com/JoshClose/CsvHelper)
[CsvHelper Getting started](https://joshclose.github.io/CsvHelper/getting-started/)