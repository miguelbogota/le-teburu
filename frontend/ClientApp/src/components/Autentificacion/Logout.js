import { Component } from "react";
import { signOut } from "./Autentificacion";

// No es necesario tener un componente para cerra la sesión
// pero la ventaja es que de esta manera se integra mejor
// al componente de la cabecera.
export default class Logout extends Component {
  componentDidMount() {
    // Aquí finalizamos la sesión
    signOut();
    return {};
  }
  render() {
    return null;
  }
}