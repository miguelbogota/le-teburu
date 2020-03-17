import React, { Component } from 'react'

export default class DInven extends Component {
  render() {
    return (
      <div className="card mb-1">
        <div className="card-body d-flex">

    <div className="col-sm-2">{this.props.NombreP}</div>
          <div className="col-sm-4">{this.props.tProducto}</div>
          <div className="col-sm-2">{this.props.cantidad}</div>
          <div className="col-sm-4">
            <button className="btn btn-primary btn-sm">Editar</button>
            <button className="btn btn-danger btn-sm ml-1">Eliminar</button>
          </div>

        </div>
      </div>
    )
  }
}
