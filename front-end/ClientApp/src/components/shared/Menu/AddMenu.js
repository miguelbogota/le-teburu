import React, { Component } from 'react'
import AddIcon from '@material-ui/icons/Add';
import Button from '@material-ui/core/Button';

class AddMenu extends Component {

  state = {
    formOpen: false
  }

  // Funcion cambia el estado del formulario
  toggleForm = () => {
    this.setState(prevState => ({
      formOpen: !prevState.formOpen
    }));
  }

  // Funcion renderiza el boton para agregar productos nuevos
  renderButton = () => {
    return (
      <Button
        variant="contained"
        color="default"
        startIcon={<AddIcon />}
        onClick={this.toggleForm}
      >
        Agregar un producto
      </Button>
    );
  }

  // Funcion renderiza el formulario para ingresar un nuevo producto
  RenderForm = () => {
    return (
      <div style={{...styles.productForm}}>
        
      </div>
    );
  }

  render() {
    return this.state.formOpen ? this.RenderForm() : this.renderButton();
  }
}

const styles = {
  productForm: {
    
  }
}

export default AddMenu;
