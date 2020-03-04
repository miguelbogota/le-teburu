import React, { Component } from 'react'

// Componentes
import Producto from './Producto';

export default class Productos extends Component {
  render() {
    return (
      <div className="container-users">
        <h3 className="text-center bg-dark d-box py-5 my-3 text-light">Productos</h3>
        <Producto nombre={'Carne'} descripcion={'Carnceita rica'}/>
        <Producto nombre={'Salchichon'} descripcion={'Salchichon portuano'}/>
        <Producto nombre={'Huevos'} descripcion={'Huevitos'}/>
      </div>
    )
  }
}
