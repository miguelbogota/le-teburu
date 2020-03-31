import React, { Component } from 'react'
import { getCookie, removeCookie } from "./Autentificacion/sesion";
import { signIn, redirectIfAuthenticated } from "./Autentificacion";

export default class Login extends Component {
  render(){
  

    // verificar
      constructor(props); {
        super(props)
        this.state = {
          error: null 
        }
      }
      // getInitialProps es la primera función llamada en
      // el ciclo de vida de una página en Next.js 
      static getInitialProps(ctx) {
      // Si ya se ha iniciado una sesión, se produce el
      // redirecionamiento ya que esta es la página de inicio de sesión.
      if (redirectIfAuthenticated(ctx)) {
        return {};
      }
    

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
    
  }
  handleSubmit = async e => {
    e.preventDefault();

    const documento = e.target.elements.documento.value;
    const Contraseña = e.target.elements.Contraseña.value;

    const error = await signIn(documento, Contraseña);

    if (error) {
      this.setState({
        error
      });
      return false;
    }
  }
}
