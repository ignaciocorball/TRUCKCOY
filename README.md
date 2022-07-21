# TRUCKCOY

[![Ver video](https://i.imgur.com/vKb2F1B.png)]([https://youtu.be/vt5fpE0bzSY](https://youtu.be/HGKjjoifl3Y))

TRUCKCOY es un software de escritorio que permite la administración y gestion de flotas vehiculares mediante un módulo `ESP32 SIM800L` que interactua con la base de datos mediante un chip de datos móviles. 

Una de sus carácteristicas fundamentales es la capacidad de añadir más módulos los cuales permitan un analísis de datos mayor tanto de los conductores como del vehículo o camión.

# Información importante
Este proyecto es de carácter educativo y se realizó el 05-05-2020 utilizando C#, C++, PHP, MySQL y mucho café 😊, por lo que te recomendamos analizar el código para comprender como funciona el transporte de datos desde que el GPS envía la información, como es captada por el servidor y como es manipulada utilizando el software de escritorio.

Puede que no todas las funciones se encuentren disponibles debido a que utiliza una base de datos existente hasta 2025 en Hostinger. Puedes configurar tu propia string de conexión y generar tus propias consultas para gestionar apropiadamente la información.

Dentro de la carpeta raiz `\TRUCKCOY` podrás encontrar otra carpeta llamada `\NaheimGPS` la cual consta de 3 partes.
1. Un archivo de `arduino` el cual contiene la configuración para un modulo `ESP32 SIM800L` (Funciona en derivados) el cual envía información hacia un script en PHP el cúal se encarga de gestionar esta y el acceso mediante una apikey.
2. El archivo `PHP` se encarga de recibir la información brindada por el módulo `ESP32` y envía los datos hacia el servidor para ser subidos a la base de datos `MySQL`.
3. También encontrarás un archivo con la extensión `.sql` el cúal podrás exportar directamente a tu base de datos MYSQL y generará las tablas y columnas utilizadas dentro del software, lo que permitirá una implementación más rápida de tu sistema de gestión de flota vehicular.

Truckcoy is powered by .NET & MySQL technology.

## Instalación mediante VSCommunity
1. Pega el siguiente link en tu terminal
    `git clone https://github.com/ignaciocorball/truckcoy.git`
2. Abre el archivo de la solución dentro de la ruta `TRUCKCOY\TRUCKCOY.sln`
3. Compila la app y encuentra los binarios en `TRUCKCOY\TRUCKCOY\bin`

## Contributing
Pull requests son bienvenidos. Para cambios importantes, abra un problema primero para discutir lo que le gustaría cambiar.
Asegúrese de actualizar las pruebas según corresponda.

## License

#### [MIT LICENSE](https://choosealicense.com/licenses/mit/)
#### Copyright (c) [2019 - 2021] [TRUCKCOY]

Por la presente se concede permiso, sin cargo, a cualquier persona que obtenga una copia
de este software y los archivos de documentación asociados (el "Software"), para tratar
en el Software sin restricciones, incluidos, entre otros, los derechos
usar, copiar, modificar, fusionar, publicar, distribuir, otorgar sublicencias y permitir a las personas a quienes se les otorga el Software
provisto para hacerlo, sujeto a las siguientes condiciones:

El aviso de derechos de autor anterior y este aviso de permiso se incluirán en todos
copias o partes sustanciales del Software.

EL SOFTWARE SE PROPORCIONA "TAL CUAL", SIN GARANTÍA DE NINGÚN TIPO, EXPRESA O
IMPLÍCITO, INCLUYENDO PERO NO LIMITADO A LAS GARANTÍAS DE COMERCIABILIDAD,
IDONEIDAD PARA UN PROPÓSITO PARTICULAR Y NO VIOLACIÓN. EN NINGÚN CASO LA
LOS AUTORES O TITULARES DE LOS DERECHOS DE AUTOR SERÁN RESPONSABLES DE CUALQUIER RECLAMACIÓN, DAÑOS U OTROS
RESPONSABILIDAD, YA SEA EN UNA ACCIÓN DE CONTRATO, AGRAVIO O DE OTRA FORMA, DERIVADA DE,
FUERA DE O EN CONEXIÓN CON EL SOFTWARE O EL USO U OTROS TRATOS EN EL
SOFTWARE.
