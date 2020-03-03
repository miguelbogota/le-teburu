import React, { Component } from 'react'

export default class Login extends Component {
  render() {
    return (
      <div className="login-container">
        <div className="bg-white border rounded p-4 col-md-6 offset-md-3 mt-3 mt-md-5">
          <h3>Inicio de Sesión</h3>

          <div>

            <div className="form-group">
              <label htmlFor="documento">Numero de documento:</label>
              <input type="email" className="form-control" id="documento" aria-describedby="emailHelp" />
            </div>
            <div className="form-group">
              <label htmlFor="clave">Contraseña:</label>
              <input type="password" className="form-control" id="clave" />
            </div>
            <button type="submit" className="btn btn-primary">Inciar sesión</button>

          </div>

        </div>
      </div>
    )
  }
}
