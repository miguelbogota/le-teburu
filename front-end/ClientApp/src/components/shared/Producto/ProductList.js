import React from 'react';
import MaterialTable from 'material-table';
import AddBox from '@material-ui/icons/AddBox';
import ArrowDownward from '@material-ui/icons/ArrowDownward';
import Check from '@material-ui/icons/Check';
import ChevronLeft from '@material-ui/icons/ChevronLeft';
import ChevronRight from '@material-ui/icons/ChevronRight';
import Clear from '@material-ui/icons/Clear';
import DeleteOutline from '@material-ui/icons/DeleteOutline';
import Edit from '@material-ui/icons/Edit';
import FilterList from '@material-ui/icons/FilterList';
import FirstPage from '@material-ui/icons/FirstPage';
import LastPage from '@material-ui/icons/LastPage';
import Remove from '@material-ui/icons/Remove';
import SaveAlt from '@material-ui/icons/SaveAlt';
import Search from '@material-ui/icons/Search';
import ViewColumn from '@material-ui/icons/ViewColumn';
import Refresh from '@material-ui/icons/Refresh';
import Paper from '@material-ui/core/Paper';
import InputBase from '@material-ui/core/InputBase';
import IconButton from '@material-ui/core/IconButton';
import SearchIcon from '@material-ui/icons/Search';
import { forwardRef } from 'react';
import axios from 'axios';

// Iconos en la tabla
const tableIcons = {
  Add: forwardRef((props, ref) => <AddBox {...props} ref={ref} />),
  Check: forwardRef((props, ref) => <Check {...props} ref={ref} />),
  Clear: forwardRef((props, ref) => <Clear {...props} ref={ref} />),
  Delete: forwardRef((props, ref) => <DeleteOutline {...props} ref={ref} />),
  DetailPanel: forwardRef((props, ref) => <ChevronRight {...props} ref={ref} />),
  Edit: forwardRef((props, ref) => <Edit {...props} ref={ref} />),
  Export: forwardRef((props, ref) => <SaveAlt {...props} ref={ref} />),
  Filter: forwardRef((props, ref) => <FilterList {...props} ref={ref} />),
  FirstPage: forwardRef((props, ref) => <FirstPage {...props} ref={ref} />),
  LastPage: forwardRef((props, ref) => <LastPage {...props} ref={ref} />),
  NextPage: forwardRef((props, ref) => <ChevronRight {...props} ref={ref} />),
  PreviousPage: forwardRef((props, ref) => <ChevronLeft {...props} ref={ref} />),
  ResetSearch: forwardRef((props, ref) => <Clear {...props} ref={ref} />),
  Search: forwardRef((props, ref) => <Search {...props} ref={ref} />),
  SortArrow: forwardRef((props, ref) => <ArrowDownward {...props} ref={ref} />),
  ThirdStateCheck: forwardRef((props, ref) => <Remove {...props} ref={ref} />),
  ViewColumn: forwardRef((props, ref) => <ViewColumn {...props} ref={ref} />),
  Refresh: forwardRef((props, ref) => <Refresh {...props} ref={ref} />)
};


class ProductList extends React.Component {

  constructor(props) {
    super(props);
    this.tableRef = React.createRef();
  }

  onSearchChange = async (event) => {
    const ev = event.target.value;
    if (ev.length > 0) {
      this.setState((prevState) => {
        const newData = prevState.data.filter(arr => arr.id.toString().includes(ev) || arr.nombre.includes(ev) || arr.nombre.toLowerCase().includes(ev));
        return {
          data: newData,
          columns: prevState.columns
        };
      });
      this.tableRef.current && this.tableRef.current.onQueryChange()
    }
    else {
      await this.refreshProductos();
    }
  }

  refreshProductos = async () => {
    const datos = await this.getProductos();
    this.setState({
      data: datos
    })
    this.tableRef.current && this.tableRef.current.onQueryChange()
  }

  setProductos = (query) => {
    return new Promise(async (resolve, reject) => {
      const page = (query.pageSize * query.page);
      // Mostrar solo la info de la pagina
      const datosState = this.state.data.slice(page, query.pageSize);
      // Enviar datos
      resolve({
        data: datosState,
        page: page,
        totalCount: this.state.data.length,
      });
    })
  }

  // Funcion obtiene los datos
  getProductos = async () => {
    this.setState({
      loadinData: true
    })
    // Hacer llamado a la pagina
    const res = await axios.get('https://localhost:44337/api/inventarios');
    const resData = res.data;

    let datos = [];
    // Mapear los datos en un arregle
    for (var i = 0; i < resData.length; i++) {
      datos.push({
        id: resData[i].producto.id,
        nombre: resData[i].producto.nombre,
        precio: resData[i].producto.precio,
        cantidad: resData[i].cantidad
      });
    }
    this.setState({
      loadinData: false
    })
    return datos;
  }

  // Funcion para agregar productos nuevos
  addProducto = (newData) => {
    return new Promise(async (resolve, reject) => {
      // Validacion
      if (newData.nombre == null || newData.precio == null || newData.cantidad == null) { reject(); }
      else {
        resolve();
        this.setState({
          loadinData: true
        })
        const d = new Date('2010-08-05')
        const dtf = new Intl.DateTimeFormat('en', { year: 'numeric', month: '2-digit', day: '2-digit' }) 
        const [{ value: mo },,{ value: da },,{ value: ye }] = dtf.formatToParts(d) 
        const datos = {
          fechaIngreso: `${ye}-${mo}-${da}`,
          precioTotal: (newData.precio * newData.cantidad),
          cantidad: (newData.cantidad),
          restauranteId: 1,
          producto: {
            nombre: newData.nombre,
            precio: (newData.precio),
            estado: "A",
            proveedorId: 1,
            menu: null
          }
        };
        console.log(datos)
        // Hacer llamado a la pagina
        await axios.post('https://localhost:44337/api/inventarios', datos);
        this.refreshProductos();
        this.setState({
          loadinData: false
        })
      }
    });
  };

  // Funcion para eliminar un producto
  deleteProduct = (oldData) => {
    return new Promise(async (resolve) => {
      resolve();
      await axios.delete('https://localhost:44337/api/inventarios/' + oldData.id);
      this.refreshProductos();
    });
  }

  // Funcion para actualizar un producto
  updateProduct = (newData, oldData) => {
    return new Promise((resolve) => {
      resolve();
      if (oldData) {
        this.setState((prevState) => {
          const data = [...prevState.data];
          data[data.indexOf(oldData)] = newData;
          return { ...prevState, data };
        });
      }
    });
  }

  state = {
    // Estado para saber si la tabla esta cargando
    loadinData: true,
    // Guardar los datos en el estado
    data: [],
    // Definir las columnas necesarias
    columns: [
      {
        title: 'Id', field: 'id', editComponent: props => (
          <div></div>
        )
      },
      { title: 'Nombre', field: 'nombre' },
      {
        title: 'Precio', field: 'precio', type: 'currency', editComponent: props => (
          <div className="MuiFormControl-root MuiTextField-root" style={{ float: 'right' }}>
            <div className="MuiInputBase-root MuiInput-root MuiInput-underline MuiInputBase-formControl MuiInput-formControl" style={{ fontSize: 13 }}>
              <input
                placeholder="Precio"
                type="number"
                className="MuiInputBase-input MuiInput-input"
                value={props.value || ''}
                onChange={e => props.onChange(e.target.value)}
              />
            </div>
          </div>
        )
      },
      { title: 'Cantidad', field: 'cantidad', type: 'numeric' }
    ]
  };

  componentWillMount() {
    this.getProductos().then(res => {
      this.setState({
        data: res
      })
      this.refreshProductos();
    });
  }

  render() {
    // Crear tabla
    return (
      <div>

        <Paper component="form" style={{ padding: '2px 4px', display: 'flex', alignItems: 'center', marginBottom: 30 }}>
          <InputBase
            style={{ marginLeft: 20, flex: 1, }}
            placeholder="Buscar"
            inputProps={{ 'aria-label': 'Buscar' }}
            onChange={this.onSearchChange}
          />
          <IconButton type="submit" style={{ padding: 10 }} aria-label="search">
            <SearchIcon />
          </IconButton>
        </Paper>

        <MaterialTable
          title="Productos"
          tableRef={this.tableRef}
          isLoading={this.state.loadinData}
          columns={this.state.columns}
          data={query => this.setProductos(query)}
          icons={tableIcons}
          options={{
            actionsColumnIndex: -1,
            pageSize: 20,
            pageSizeOptions: [20],
            search: false
          }}
          actions={[
            {
              icon: Refresh,
              tooltip: 'Refrescar Datos',
              isFreeAction: true,
              onClick: () => this.refreshProductos()
            }
          ]}
          editable={{
            onRowAdd: (newData) => this.addProducto(newData),
            onRowUpdate: (newData, oldData) => this.updateProduct(newData, oldData),
            onRowDelete: (oldData) => this.deleteProduct(oldData)
          }}
          localization={{
            body: {
              emptyDataSourceMessage: '¡No hay datos!',
              addTooltip: 'Agregar',
              deleteTooltip: 'Eliminar',
              editTooltip: 'Editar'
            },
            editRow: {
              deleteText: '¿Estas seguro de borrar esta fila?',
              cancelTooltip: 'Cancelar',
              saveTooltip: 'Guardar'
            },
            header: {
              actions: 'Acciones'
            },
            toolbar: {
              searchTooltip: 'Buscar',
              searchPlaceholder: 'Buscar'
            },
            pagination: {
              labelDisplayedRows: ' {from}-{to} de {count}',
              labelRowsSelect: 'Filas',
              labelRowsPerPage: 'Filas por pagina:',
              firstAriaLabel: 'Primera pagina',
              firstTooltip: 'Primera pagina',
              previousAriaLabel: 'Pagina anterior',
              previousTooltip: 'Pagina anterior',
              nextAriaLabel: 'Sigiente pagina',
              nextTooltip: 'Siguiente pagina',
              lastAriaLabel: 'Ultima pagina',
              lastTooltip: 'Ultima pagina'
            }
          }}
        />
      </div>
    );
  }
}

export default ProductList;
