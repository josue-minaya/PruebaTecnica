# Gestor de Productos 📦

Este es un sistema web desarrollado en Angular para gestionar productos, permitiendo registrar, listar, editar y eliminar productos fácilmente.


---

## 🖥️ Frontend (Angular)

### 🚀 Tecnologías Utilizadas

- Angular 16+
- TypeScript
- TailwindCSS
- Angular Material Icons
- Formularios con `ngModel`
- Comunicación con servicios HTTP

### 🎯 Funcionalidades

- Registrar productos con validaciones:
  - ✅ Nombre (mín. 3 caracteres)
  - ✅ Precio (> 0)
  - ✅ Cantidad (> 0)
  - ✅ Descripción (mín. 5 caracteres)
- Listado de productos en tiempo real
- Modal emergente para agregar productos
- Exportar reporte en formato PDF
- Recarga automática tras agregar producto

### 📦 Instalación del Frontend

- bash
- cd frontend
- npm install
- ng serve






## 🛠️ Backend (API REST)

Este proyecto es un backend que proporciona una API REST para gestionar productos y realizar operaciones como agregar productos, listar productos registrados y exportarlos a un archivo PDF.

### 📄 Funcionalidades

1. **Agregar nuevo producto**
   - **Método**: `POST`
   - **Endpoint**: `/productos`
   - **Descripción**: Permite agregar un nuevo producto a la base de datos.
   - **Cuerpo de la solicitud** (JSON):
     ```json
     {
       "nombre": "Nombre del producto",
       "descripcion": "Descripción del producto",
       "precio": 100.00
     }
     ```

2. **Listar productos registrados**
   - **Método**: `GET`
   - **Endpoint**: `/productos`
   - **Descripción**: Obtiene una lista de todos los productos registrados en el sistema.
   - **Respuesta** (JSON):
     ```json
     [
       {
         "id": 1,
         "nombre": "Producto 1",
         "descripcion": "Descripción del producto 1",
         "precio": 50.00
       },
       {
         "id": 2,
         "nombre": "Producto 2",
         "descripcion": "Descripción del producto 2",
         "precio": 150.00
       }
     ]
     ```

3. **Exportar todos los productos a PDF**
   - **Método**: `GET`
   - **Endpoint**: `/productos/exportar-pdf`
   - **Descripción**: Exporta todos los productos registrados a un archivo PDF.
   - **Respuesta**: El servidor generará y devolverá un archivo PDF con la lista de productos.

4. **Endpoint para descargar el PDF consumido por el frontend**
   - **Método**: `GET`
   - **Endpoint**: `/productos/descargar-pdf`
   - **Descripción**: Permite al frontend descargar el archivo PDF generado con la lista de productos.
   - **Respuesta**: El archivo PDF será descargado automáticamente.

### 📦 Instalación

Sigue estos pasos para instalar y ejecutar el backend localmente:

1. **Clonar el repositorio**

   Clona el repositorio del proyecto y navega a la carpeta del backend:

   ```bash
   git clone https://github.com/tu-usuario/tu-repo.git
   cd tu-repo/backend






# 🔐 Validaciones (Frontend)

Las validaciones en el frontend se manejan utilizando **ngModel** y **directivas** en **Angular** para garantizar que los datos ingresados por el usuario sean correctos antes de ser enviados al backend.

### Reglas de Validación

| Campo        | Reglas de Validación                             |
|--------------|--------------------------------------------------|
| **Nombre**   | Requerido, mínimo 3 caracteres                   |
| **Precio**   | Requerido, mayor que 0                           |
| **Cantidad** | Requerido, mayor que 0                           |
| **Descripción** | Requerido, mínimo 5 caracteres               |








# 📄 Reporte PDF

En la interfaz de **Angular**, cuando el usuario hace clic en el botón **"Descargar Reporte"**, se ejecuta un método que realiza los siguientes pasos:

1. **Llamada al backend**: Se invoca el método `productoService.descargarPdf()`, el cual hace una solicitud al endpoint del backend que genera y envía el archivo PDF con el listado de productos.

2. **Descarga automática del PDF**: El archivo PDF es recibido desde el servidor y se descarga automáticamente en el navegador del usuario.

3. **Uso de Blob y ObjectURL**: El archivo PDF se maneja usando **Blob** y **ObjectURL** para descargarlo dinámicamente sin necesidad de hacer una redirección o recargar la página.






# 👤 Autor

- **Nombre**: Josue Enrique Minaya Jaulis
- **GitHub**: [@josue-minaya](https://github.com/josue-minaya)



