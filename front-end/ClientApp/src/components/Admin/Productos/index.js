import React from 'react';
import { makeStyles } from '@material-ui/core/styles';
import ProductList from '../../shared/Producto/ProductList';

const useStyles = makeStyles((theme) => ({
  productContainer: {
    flexGrow: 1,
    maxWidth: 654,
    margin: '0px auto',
  },
}));


const AdminProductos = ({ data }) => {
  const classes = useStyles();
  return (
    <div className={classes.productContainer}>

      <ProductList productos={data} />

    </div>
  );
}

export default AdminProductos;
