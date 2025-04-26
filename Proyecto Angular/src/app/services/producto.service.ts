import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { map, Observable } from "rxjs";
import { AddProducto, APIResponse, Producto } from "../Models/ApiRepònse";

@Injectable({
  providedIn: "root",
})
export class ProductoService {
  private apiUrl = "https://localhost:7143/api"; 

  constructor(private http: HttpClient) {}

  getProductos(): Observable<APIResponse<Producto[]>> {
    
    return this.http.get<APIResponse<Producto[]>>(`${this.apiUrl}/productos`);
  }

  addProducto(producto: AddProducto): Observable<APIResponse<AddProducto>> {
    return this.http.post<APIResponse<AddProducto>>((`${this.apiUrl}/productos`), producto);
  }
  
  deleteProducto(id: number): Observable<APIResponse<any>> {
    return this.http.delete<APIResponse<any>>(`${this.apiUrl}/eliminar/${id}`);
  }
  GetProductoId(id: number): Observable<APIResponse<any>> {
    return this.http.get<APIResponse<any>>(`${this.apiUrl}/producto/${id}`);
  }
  updateProducto( producto: AddProducto): Observable<APIResponse<AddProducto>> {
    return this.http.put<APIResponse<AddProducto>>(`${this.apiUrl}/actualizar`, producto);
  }

  descargarPdf(): Observable<Blob> {
    return this.http.get(`${this.apiUrl}/pdf`, {
      responseType: 'blob'  
    });
  
  }
}
