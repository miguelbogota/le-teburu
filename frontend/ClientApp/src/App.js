import React, { Component } from 'react';
import { BrowserRouter as Router, Route } from 'react-router-dom';

// Componentes
import Navigation from './components/shared/Navigation';
import Home from './components/Home/Home';
import Login from './components/Login';
import Registro from './components/Registro/Registro';
import AdminEmpleados from './components/Admin/AdminEmpleados/AdminEmpleados';
import Inventario from './components/Admin/AdminInventario/AdminInventarios'


export default class App extends Component {
  render() {
    return (
      <div className="container">
        <Router>

          <Navigation />

          <Route path="/" component={ Home } exact />
          <Route path="/login" component={ Login } />
          <Route path="/registro" component={ Registro } />
          <Route path="/admin" component={ AdminEmpleados } />
          <Route path="/inventario" component={ Inventario } />
        </Router>
      </div>
    )
  }
}
