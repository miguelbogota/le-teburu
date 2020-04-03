import React from 'react';
import { makeStyles } from '@material-ui/core/styles';
import MenuCard from './MenuCard';
import Typography from '@material-ui/core/Typography';

const useStyles = makeStyles((theme) => ({
  container: {
    padding: 30,
    margin: '0px auto',
  },
  title: {
    marginBottom: 10,
    textAlign: 'center'
  }
}));

const MenuList = ({ categoria }) => {
  const classes = useStyles();

  return  categoria.menus.length > 0 ? 
            <div className={classes.container}>
              <Typography className={classes.title} variant="h5" component="h5">
                { categoria.nombre }
              </Typography>
              {
                categoria.menus.map((values) => 
                  <MenuCard
                    key={values.id}
                    menu={values}
                  />
                )
        
              }
              
            </div>
          : '';
          
}

export default MenuList;
