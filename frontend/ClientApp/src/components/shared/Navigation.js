import React, { Component } from 'react'
import { Link } from 'react-router-dom';

export default class Navigation extends Component {
  render() {
    return (
      <nav className="navbar navbar-expand-md navbar-light bg-white border rounded mt-3">

        {/* Link al inicio de la pagina */}
        <Link to="/" className="navbar-brand">Inicio</Link>

        {/* Boton para pantallas pequeñas */}
        <button className="navbar-toggler" data-toggle="collapse" data-target="#navigation" aria-expanded="false" aria-label="Toggle navigation">
          <span className="navbar-toggler-icon"></span>
        </button>

        {/* Links a las otras paginas */}
        <div className="collapse navbar-collapse" id="navigation">
          <div className="navbar-nav ml-auto mt-3 mt-md-0">

            <Link to="/" className="nav-item nav-link">Historial</Link>
            <Link to="/" className="nav-item nav-link text-danger text-bold">Cerrar Sesión</Link>

          </div>
        </div>

      </nav>
    )
  }
}
