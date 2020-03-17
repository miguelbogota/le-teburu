import React, { Component } from 'react'

// Componentes
import Producto from './Producto';

export default class Venta extends Component {
  render() {
    return (
      <div>
        <h3 className="text-center">Venta</h3>
        <Producto nombre={'Carne'} />
        <Producto nombre={'Salchichon'} />
        <Producto nombre={'Huevos'} />
      </div>
    )
  }
}
