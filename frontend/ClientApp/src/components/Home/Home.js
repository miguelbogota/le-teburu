import React, { Component } from 'react'

// Componentes
import Productos from './Productos';
import Venta from './Venta';
import './Styles.css';

export default class Home extends Component {

  productos = [
    { id: 1, nombre: 'Carne', descripcion: 'Carnceita rica' },
    { id: 2, nombre: 'Carne2', descripcion: 'Carnceita 2 rica' }
  ]
  ventas = []

  enviarCarrito = (id) => {
    var index = id -1;
    var prod = this.productos[index];
    this.productos.splice(index, 1);
    this.ventas.push(prod);
    console.log(this.productos);
    console.log(this.ventas);
  }
  enviarProducto(id) {
    var index = id -1;
    var prod = this.ventas[index];
    this.ventas.splice(index, 1);
    this.productos.push(prod);
    console.log(this.productos);
    console.log(this.ventas);
  }

  render() {
    return (
      <div className="row mt-4">
        <div className="col-md-6">
          <Productos prod={this.productos} />
        </div>

        <div className="col-md-6">
          <Venta prod={this.ventas} />
        </div>

      </div>
    )
  }
}
