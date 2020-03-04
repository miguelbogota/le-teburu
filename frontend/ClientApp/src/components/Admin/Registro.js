import React, { Component } from 'react'

export default class Registro extends Component {
  render() {
    return (
      <div>
        <h3>Registro</h3>

        <div className="form-group">
          <label className="control-label">Nombre</label>
          <input type="text" className="form-control" id="nombre_id" name="Nombre" />
        </div>

        <div className="form-group">
          <label className="control-label">Fecha de nacimiento</label>
          <input type="text" className="form-control" id="edad_id" name="Edad" />
        </div>

        <div className="form-group">
          <label htmlFor="nDocumnto_id" className="control-label">Tipo de documento</label>
          <select className="form-control" id="nDocumento_id">
            <option value="Masculino">Masculino</option>
            <option value="Femenino">Femenino</option>
            <option value="Otro">Otro</option>
          </select>
        </div>

        <div className="form-group">
          <label htmlFor="documento_id" className="control-label">Numero de documento</label>
          <input type="text" className="form-control" id="documento_id" name="nDocumento" />
        </div>

        <div className="form-group">
          <label htmlFor="tDocumento_id" className="control-label">Tipo de documento</label>
          <select className="form-control" id="tDocumento_id">
            <option value="Tarjeta de identidad">Tarjeta de identidad</option>
            <option value="Cedula de ciudanania">Cedula de ciudanania</option>
            <option value="Pasaporte">Pasaporte</option>
          </select>
        </div>

        <div className="form-group">
          <label htmlFor="cargo_id" className="control-label">Cargo</label>
          <select className="form-control" id="cargo_id">
            <option value="Gerente">Gerente</option>
            <option value="Cocina">Cocina</option>
            <option value="Caja">Caja</option>
          </select>
        </div>

        <div className="form-group">
          <label htmlFor="correo_id" className="control-label">Correo</label>
          <input type="text" className="form-control" id="correo_id" name="correo" />
        </div>

        <div className="form-group">
          <label htmlFor="Clave_id" className="control-label">Clave</label>
          <input type="text" className="form-control" id="zip_id" name="calve" />
        </div>

        <div className="form-group">
          <button type="submit" className="btn btn-primary">Guardar</button>
        </div>

      </div>
    )
  }
}
