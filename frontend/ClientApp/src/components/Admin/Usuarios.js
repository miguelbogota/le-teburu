import React, { Component } from 'react'

import Usuario from './Usuario';

export default class Usuarios extends Component {

  constructor(props) {
    super(props)
    
    this.users = this.props.users.map((usuario) =>
      <Usuario key={usuario.id} cedula={usuario.persona.documento} nombre={usuario.persona.nombre} cargo={usuario.cargo} />
    );
  }

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

        { this.users }

      </div>
    )
  }
}
