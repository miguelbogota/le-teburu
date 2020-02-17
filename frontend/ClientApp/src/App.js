import React, { Component } from 'react';
import { BrowserRouter as Router, Route } from 'react-router-dom';

// Componentes
import Navigation from './components/shared/Navigation';
import Home from './components/Home';
import Login from './components/Login';
import Admin from './components/Admin';

export default class App extends Component {
  render() {
    return (
      <div className="container">
        <Router>

          <Navigation />

          <Route path="/" component={ Home } exact />
          <Route path="/login" component={ Login } />
          <Route path="/admin" component={ Admin } />

        </Router>
      </div>
    )
  }
}
