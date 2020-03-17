import React, { Component } from 'react';
import { BrowserRouter as Router, Route } from 'react-router-dom';

// Componentes
import Navigation from './components/shared/Navigation';
import Home from './components/Home/Home';
import Login from './components/Login';
import Admin from './components/Admin/Admin';
import Inventario from './components/Inventario/Inventario';
export default class App extends Component {
  render() {
    return (
      <div className="container">
        <Router>

          <Navigation />

          <Route path="/" component={ Home } exact />
          <Route path="/login" component={ Login } />
          <Route path="/admin" component={ Admin } />
          <Route path="/Inventario" component={ Inventario } />
        </Router>
      </div>
    )
  }
}
