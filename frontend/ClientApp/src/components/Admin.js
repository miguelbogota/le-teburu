import React, { Component } from 'react'

export default class Admin extends Component {
  render() {
    return (
      <div className="container">


        <div className="row mt-3 mt-md-5">

          <div className="bg-white border rounded p-3 col-md-5">
            <h3>Registro</h3>

            <div class="form-group">
              <label class="control-label">Nombre</label>
              <input type="text" class="form-control" id="nombre_id" name="Nombre" />
            </div>

            <div class="form-group">
              <label class="control-label">Edad</label>
              <input type="text" class="form-control" id="edad_id" name="Edad" />
            </div>

            <div class="form-group">
              <label for="nDocumnto_id" class="control-label">Tipo de documento</label>
              <select class="form-control" id="nDocumento_id">
                <option value="Masculino">Masculino</option>
                <option value="Femenino">Femenino</option>
                <option value="Otro">Otro</option>
              </select>
            </div>

            <div class="form-group">
              <label for="documento_id" class="control-label">Numero de documento</label>
              <input type="text" class="form-control" id="documento_id" name="nDocumento" />
            </div>

            <div class="form-group">
              <label for="tDocumento_id" class="control-label">Tipo de documento</label>
              <select class="form-control" id="tDocumento_id">
                <option value="Tarjeta de identidad">Tarjeta de identidad</option>
                <option value="Cedula de ciudanania">Cedula de ciudanania</option>
                <option value="Pasaporte">Pasaporte</option>
              </select>
            </div>

            <div class="form-group">
              <label for="correo_id" class="control-label">Correo</label>
              <input type="text" class="form-control" id="correo_id" name="correo" />
            </div>

            <div class="form-group">
              <label for="Clave_id" class="control-label">Clave</label>
              <input type="text" class="form-control" id="zip_id" name="calve" />
            </div>

            <div class="form-group">
              <button type="submit" class="btn btn-primary">Guardar</button>
            </div>
          </div>

          <div class="col-sm-7">
            <table class="table table-borderless">
              <thead>
                <tr>
                  <th scope="col">#</th>
                  <th scope="col">First</th>
                  <th scope="col">Last</th>
                  <th scope="col">Handle</th>
                </tr>
              </thead>
              <tbody>
                <tr>
                  <th scope="row">1</th>
                  <td>Mark</td>
                  <td>Otto</td>
                  <td>@mdo</td>
                </tr>
                <tr>
                  <th scope="row">2</th>
                  <td>Jacob</td>
                  <td>Thornton</td>
                  <td>@fat</td>
                </tr>
                <tr>
                  <th scope="row">3</th>
                  <td colspan="2">Larry the Bird</td>
                  <td>@twitter</td>
                </tr>
              </tbody>
            </table>
          </div>
        </div>
      </div>
    )
  }
}
