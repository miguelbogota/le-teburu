import React, { Component } from 'react'

import DInven from './DInven';

export default class Tabla2 extends Component {
  render() {
    return (
      <div>
        <div className="card mb-1">
          <div className="card-body d-flex text-white bg-dark">

            <div className="col-sm-3">Nombre Producto</div>
            <div className="col-sm-3">Categoria</div>
            <div className="col-sm-3">Cantidad</div>
            <div className="col-sm-3">Acciones</div>

          </div>
        </div>

        <DInven NombreP={"leche"} tProducto={"Legumbres"} cantidad={"20"} />
        <DInven NombreP={"huevos"} tProducto={"Legumbres"} cantidad={"40"} />
      </div>
    )
  }
}
