import { CONSTANTS } from '../actions'
import axios from 'axios';

const getCategorias = async () => {
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
          categorias: menu
        };
      })
    });
  console.log(datos)
}

const initialState = [
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
    categorias: [
      {
        id: 2,
        nombre: "Comidas rapidas",
        menus: [
          {
            id: 1,
            nombre: "Hamburguesa",
            precio: 19900,
            descripcion: "Muy buena!",
            ingredientes: ["Pan", "Carne", "Lechuga"],
            imgUrl: "https://images.unsplash.com/photo-1541214113241-21578d2d9b62?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=1050&q=80",
            cantidad: 0,
            list: 2
          },
          {
            id: 2,
            nombre: "Perro Caliente",
            precio: 19900,
            descripcion: "Muy bueno el perrito!",
            ingredientes: ["Pan", "Salchicha", "Pepinillos"],
            imgUrl: "https://images.unsplash.com/photo-1541214113241-21578d2d9b62?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=1050&q=80",
            cantidad: 0,
            list: 2
          }
        ]
      },
      {
        id: 3,
        nombre: "Ensaladas",
        menus: [
          {
            id: 4,
            nombre: "Esaladasa light",
            precio: 19900,
            descripcion: "Muy buena!",
            ingredientes: ["Pan", "Carne", "Lechuga"],
            imgUrl: "https://images.unsplash.com/photo-1541214113241-21578d2d9b62?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=1050&q=80",
            cantidad: 0,
            list: 3
          },
          {
            id: 5,
            nombre: "Ensalada calienat",
            precio: 19900,
            descripcion: "Muy bueno el perrito!",
            ingredientes: ["Pan", "Salchicha", "Pepinillos"],
            imgUrl: "https://images.unsplash.com/photo-1541214113241-21578d2d9b62?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=1050&q=80",
            cantidad: 0,
            list: 3
          }
        ]
      }
    ]
  }
];

const MenuReducer = (state = initialState, action) => {
  switch (action.type) {
    case CONSTANTS.SWITCH_MENU:
      // AGregar a carrito
      const agregarDatos = state[action.payload.toId].categorias.map(m => {
        let d = action.payload.menu;
        if (action.payload.toId === 0) {
          d.cantidad = 1;
          m.menus.push(d);
          return m;
        }
        else {
          if (m.id === d.list) {
            d.cantidad = 0;
            m.menus.push(d);
          }
          return m;
        }
      });
      // Remover datos
      const removerDatos = state[action.payload.fromId].categorias.map(m => {
        return {
          id: m.id,
          nombre: m.nombre,
          menus: m.menus.filter(m => m.id !== action.payload.menu.id )
        }
      })
      if (action.payload.toId === 0) {
        state = [
          {
            id: 1,
            nombre: "Carrito",
            categorias: [...agregarDatos]
          },
          {
            id: 2,
            nombre: "Menu",
            categorias: [...removerDatos]
          }
        ];
      }
      else {
        state = [
          {
            id: 1,
            nombre: "Carrito",
            categorias: [...removerDatos]
          },
          {
            id: 2,
            nombre: "Menu",
            categorias: [...agregarDatos]
          }
        ];
      }
      
      return state;
    default: return state;
  }
}

export default MenuReducer;
