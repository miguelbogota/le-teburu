import React, { Component } from 'react';
import { BrowserRouter as Router, Route } from "react-router-dom";
import { connect } from 'react-redux';
import Home from './Home';
import Navigation from './shared/Navigation';
import AdminProductos from './Admin/Productos';

class App extends Component {
  render() {
    
    const { listas } = this.props;

    return (
      <Router className="App">

        <Navigation />

        <Route path="/" exact>
          <Home categorias={listas} />
        </Route>

        <Route path="/productos" exact>
          <AdminProductos />
        </Route>

      </Router>
    );
  }
}

const mapStateToProps = (state) => {
  return { listas: state }
}

export default connect(mapStateToProps)(App);
