import React from 'react';
import { makeStyles } from '@material-ui/core/styles';
import Grid from '@material-ui/core/Grid';
import MenuList from '../shared/Menu/MenuList';
import Typography from '@material-ui/core/Typography';
import axios from 'axios';

class Home extends React.Component {

  getCategorias = async () => {
    var datos = await axios.get('https://localhost:44337/api/categorias')
      .then(res => {
        return res.data.map(r => {
          var menu = r.menus.map(m => {
            // Guardar productos
            var productos = []
            m.productos.map(p => {
              productos.push(p.nombre)
              return p;
            });
            return {
              id: m.id,
              nombre: m.nombre,
              precio: m.precio,
              descripcion: m.descripcion,
              ingredientes: productos,
              imgUrl: m.imgUrl,
              cantidad: 0,
              list: r.id + 1
            };
          });
          return {
            id: r.id + 1,
            nombre: r.nombre,
            menus: menu
          };
        })
      });
    return datos;
  }

  state = {
    data: [
      {
        id: 1,
        nombre: "Carrito",
        categorias: [
          {
            id: 1,
            nombre: "Carrito",
            menus: []
          }
        ]
      },
      {
        id: 2,
        nombre: "Menu",
        categorias: []
      }
    ],
    fetching: true
  }

  componentWillMount() {
    this.getCategorias().then(y => {
      console.log(y)
      this.setState({
        data: [
          {
            id: 1,
            nombre: "Carrito",
            categorias: [
              {
                id: 1,
                nombre: "Carrito",
                menus: []
              }
            ]
          },
          {
            id: 2,
            nombre: "Menu",
            categorias: y
          }
        ],
        fetching: false
      });
    })
  }

  render () {
    return !this.state.fetching ? (
      <Grid container style={{flexGrow: 1, width: '100% !important'}} spacing={4}>
        <Grid item xs={12} md={6}>
  
          <Typography style={{marginBottom: 10, textAlign: 'center'}} variant="h4" component="h4">
            {this.state.data[1].nombre}
          </Typography>
  
          {
            this.state.data[1].categorias.map(value => {
              return <MenuList key={value.id} categoria={value} />
            })
          }
        </Grid>
  
        <Grid item xs={12} md={6} style={{position: 'fixed', height: '80vh', overflow: 'auto', top: 70, right: 0}}>
          {
            this.state.data[0].categorias.map(value => {
              return <MenuList key={value.id} categoria={value} />
            })
          }
        </Grid>
      </Grid>
    ) : 'Cargando';
  }
}


export default Home;
