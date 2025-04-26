import { Component, Input } from "@angular/core";
import { MatIconModule } from "@angular/material/icon";
import { MatTableDataSource, MatTableModule } from "@angular/material/table";
import { MatCheckboxModule } from "@angular/material/checkbox";
import { ProductoService } from "../../services/producto.service";
import { APIResponse,AddProducto, Producto } from "../../Models/ApiRepònse";
import { FormsModule } from "@angular/forms";
import { CommonModule } from "@angular/common";

@Component({
  selector: "app-listado-producto",
  standalone: true,
  imports: [MatTableModule,CommonModule,FormsModule, MatIconModule, MatCheckboxModule],
  templateUrl: "./listado-producto.component.html",
  styleUrl: "./listado-producto.component.css",
})
export class ListadoProductoComponent {
  dataSource: any;
  showModal: boolean = false;


  constructor(private productoService: ProductoService) {}
updateProducto: AddProducto = {
    nombre: "",
    precio: null,
    cantidad:0,
    descripcion:"",
  };
  ngOnInit(): void {
    this.listarProductos();
  }

  listarProductos(): void {
    this.productoService.getProductos().subscribe(
      (response: APIResponse<Producto[]>) => {
        this.dataSource = new MatTableDataSource<Producto>(response.data);
      },
      (error) => {
        console.error("Error al obtener productos:", error);
      }
    );
  }

  columnsToDisplay = ["id", "nombre", "precio", "cantidad","descripcion"];
  NombreColumnas = ["Id", "Nombre", "Precio Unitario","Cantidad","Descripción"];



  eliminarProducto(id:number): void {
    this.productoService.deleteProducto(id).subscribe({
      next: (res) => {
        console.log('Producto eliminado', res);
        this.listarProductos(); 
      },
      error: (err) => console.error('Error al eliminar', err)
    });
  
  }
  toggleModal(id:number): void {
    this.productoService.GetProductoId(id).subscribe({
      next: (res) => {
        this.updateProducto = res.data; 
        this.showModal = true;       
      },
      error: (err) => console.error('Error al obtener producto', err)
    });
  }
  cerrar(): void {
  
        this.showModal = false;       
    
   
  }

  actualizarProducto(): void {
    this.productoService.updateProducto(this.updateProducto).subscribe({
      next: (res) => {
        console.log("Producto actualizado", res);
        this.listarProductos();   // recarga la lista de productos
        this.showModal = false;   // cierra el modal
      },
      error: (err) => {
        console.error("Error al actualizar producto", err);
        console.error(this.updateProducto)
      }
    });
  }
}
