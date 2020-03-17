import React, { Component } from 'react'

export default class Producto extends Component {

  state = {
    mostrarDescripcion: false,
    carrito: false
  }

  mostrarDetalles = () => {
    this.setState(prevState => ({ mostrarDescripcion: !prevState.mostrarDescripcion }));
  };

  agregarCarrito = () => {
    this.setState(prevState => ({ carrito: !prevState.carrito }));
  };

  render() {
    const { mostrarDescripcion, carrito } = this.state;
    return (
      <div className="card mb-1">
        <div className="card-body p-2 d-flex align-items-center">

          <p className="m-0 mr-auto">{this.props.nombre}</p>
          <p className={`${carrito ? "hidden" : "m-0 mr-1 text-info card-link"}`} onClick={this.mostrarDetalles}>detalles</p>
          <button className={`${carrito ? "btn btn-danger btn-sm rounded-circle" : "hidden"}`} onClick={this.agregarCarrito}>-</button>
          <button className={`${carrito ? "hidden" : "btn btn-success btn-sm rounded-circle"}`} onClick={this.agregarCarrito}>🡪</button>
          
          <p className={`${carrito ? "": "hidden"}`}>numero</p>
          <button className={`${carrito ?  "btn btn-success btn-sm rounded-circle": "hidden" }`} onClick={this.agregarCarrito}>+</button>
        </div>
        <div className={`${mostrarDescripcion ? "" : "hidden"}`}>
          <p className="pl-2 text-muted">{this.props.descripcion}</p>
        </div>
      </div>
    )
  }
}
