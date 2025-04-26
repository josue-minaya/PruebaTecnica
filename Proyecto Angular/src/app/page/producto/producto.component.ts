import { Component, ViewChild } from "@angular/core";
import { CommonModule } from "@angular/common";
import { MatIconModule } from "@angular/material/icon";
import { FormsModule } from "@angular/forms";
import { ListadoProductoComponent } from "../../shared/listado-producto/listado-producto.component";
import { ProductoService } from "../../services/producto.service";
import { AddProducto, APIResponse } from "../../Models/ApiRepònse";

@Component({
  selector: "app-usuario",
  standalone: true,
  imports: [CommonModule, ListadoProductoComponent, MatIconModule, FormsModule],
  templateUrl: "./producto.component.html",
  styleUrl: "./producto.component.css",
})
export class ProductoComponent {

  productos: AddProducto[] = [];
  showModal: boolean = false;


  constructor(private productoService: ProductoService) {}
  nuevoProducto: AddProducto = {
    nombre: "",
    precio: null,
    cantidad:0,
    descripcion:"",
  };

  agregarProducto(): void {
    this.productoService.addProducto(this.nuevoProducto).subscribe(
      (response: APIResponse<AddProducto>) => {
        if (response.success) {
          this.productos.push(response.data);
          this.nuevoProducto = { nombre: "", precio: 0 ,cantidad:0,descripcion:""}; 
        } else {
          console.log("Error al agregar producto:", response.message);
        }
      },
      (error) => {
        console.error("Error al agregar producto:", error);
      }
    );

    this.showModal = false;
    window.location.reload();
  }


  toggleModal(): void {
    this.showModal = !this.showModal;
  }

  descargarPDF() {
    this.productoService.descargarPdf().subscribe(blob => {
      const url = window.URL.createObjectURL(blob);

      const link = document.createElement('a');
      link.href = url;
      link.download = 'reporte.pdf'; 
      link.click();  

      window.URL.revokeObjectURL(url);
    }, error => {
      console.error('Error al descargar el PDF:', error);
    });

    }

  }

