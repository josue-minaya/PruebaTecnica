export interface Producto {
  id: number;
  nombre: string;
  precio: number;
  cantidad:number|null;
  descripcion:string;}

export interface APIResponse<T> {
  success: boolean;
  message: string;
  data: T;
}
export interface AddProducto {
  nombre: string;
  precio: number | null;
  cantidad:number|null;
  descripcion:string;
}
