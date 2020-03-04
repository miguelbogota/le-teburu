import React, { Component } from 'react'

import Usuario from './Usuario';

export default class Usuarios extends Component {
  render() {
    return (
      <div>
        <div className="card mb-1">
          <div className="card-body d-flex text-white bg-dark">

            <div className="col-sm-3">Cedula</div>
            <div className="col-sm-3">Nombre</div>
            <div className="col-sm-3">Cargo</div>
            <div className="col-sm-3">Acciones</div>

          </div>
        </div>

        <Usuario cedula={1234567} nombre={"Migruel Angel Bogota Rico"} cargo={"Jefe"} />
        <Usuario cedula={7654321} nombre={"Johan Sebastian Piza Acosta"} cargo={"Gerente"} />
      </div>
    )
  }
}
