# WORKER_COVID19

## Descripción
El proyecto **WORKER_COVID19** es una aplicación de servicio en segundo plano desarrollada en C# que automatiza el procesamiento de datos relacionados con el COVID-19. El objetivo es extraer información de un dataset, generar un archivo PDF y enviarlo por correo electrónico.

`WORKER_COVID19` es un servicio de Windows que realiza las siguientes tareas:
- Extrae información de un dataset sobre COVID-19 (columnas: `casos`, `macrodistrito`, `distrito`, `estado`, `zona`, `fuente`).
- Convierte los datos extraídos en listas.
- Genera un archivo PDF con la información procesada dentro del servidor.
- Envía el archivo PDF generado por correo electrónico.
- Todas las variables están parametrizadas en el archivo `appsettings.json`.

## Lenguaje Desarrollado

- **Lenguaje:** C#
- **Tipo de Proyecto:** Worker Service

## Librerías Utilizadas

- **[MailKit](https://github.com/jstedfast/MailKit)**: Para el envío de correos electrónicos.
- **[FileHelpers](https://github.com/MarcosMeli/FileHelpers)**: Para la lectura de archivos CSV.
- **[iTextSharp](https://github.com/itext/itext7-dotnet)**: Para la generación de archivos PDF.

## Configuración

El archivo de configuración `appsettings.json` debe contener las siguientes secciones:

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  },
  "TimerWorker": {
    "HoraInicio": "8",
    "HoraFin": "20",
    "IntervaloMinutos": "60",
    "IntervaloMinutosOffLine": "10"
  },
  "Mail": {
    "toEmail": "<Ingrese Mail a enviar el correo>",
    "subject": "REPORT COVID",
    "body": "Se envia informe de reportes cargados:",
    "smtp": "smtp.gmail.com",
    "UserMail": "<Ingrese Mail>",
    "PasswordMail": "<Ingresa Password>"
  }
}
```
