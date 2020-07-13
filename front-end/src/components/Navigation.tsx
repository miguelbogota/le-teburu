import React from "react";
import { createStyles, makeStyles, Theme } from "@material-ui/core/styles";
import {
  List,
  ListItem,
  ListItemIcon,
  ListItemText,
  Divider,
  Drawer,
  IconButton,
  Button,
  Typography,
  Toolbar,
  AppBar,
} from "@material-ui/core";
import { Link } from "react-router-dom";
import MenuIcon from "@material-ui/icons/Menu";
import HomeIcon from "@material-ui/icons/Home";
import SettingsIcon from "@material-ui/icons/Settings";

const useStyles = makeStyles((theme: Theme) =>
  createStyles({
    root: {
      flexGrow: 1,
    },
    menuButton: {
      marginRight: theme.spacing(2),
    },
    title: {
      flexGrow: 1,
    },
    offset: theme.mixins.toolbar,
    drawer: {
      width: 240,
      flexShrink: 0,
    },
    link: {
      textDecoration: "none",
      color: theme.palette.text.primary,
    },
  })
);

const Navigation: React.FC = () => {
  const classes = useStyles();
  const [isOpen, setIsOpen] = React.useState(false);

  const toggleDrawer = (open: boolean) => (
    event: React.KeyboardEvent | React.MouseEvent
  ) => {
    if (
      event.type === "keydown" &&
      ((event as React.KeyboardEvent).key === "Tab" ||
        (event as React.KeyboardEvent).key === "Shift")
    ) {
      return;
    }
    setIsOpen(open);
  };

  /**
   * Principales rutas de la navegacion
   */
  const mainRoutes = [
    { text: "Inicio", path: "/", icon: <HomeIcon /> },
    { text: "Configuración", path: "/settings", icon: <SettingsIcon /> },
  ];

  /**
   * Lista con toda la navegacion y sus links
   */
  const list = () => (
    <div onClick={toggleDrawer(false)}>
      <List>
        {mainRoutes.map((link, index) => (
          <Link key={index} to={link.path} className={classes.link}>
            <ListItem button>
              <ListItemIcon>{link.icon}</ListItemIcon>
              <ListItemText primary={link.text} />
            </ListItem>
          </Link>
        ))}
      </List>
      <Divider />
    </div>
  );

  const drawerMenu = () => (
    <Drawer
      open={isOpen}
      anchor={"left"}
      onClose={toggleDrawer(false)}
      className={classes.drawer}
    >
      <div style={{ width: 240 }}>{list()}</div>
    </Drawer>
  );

  return (
    <div className={classes.root}>
      <AppBar color="primary">
        <Toolbar>
          <IconButton
            onClick={toggleDrawer(true)}
            edge="start"
            className={classes.menuButton}
            color="inherit"
            aria-label="menu"
          >
            <MenuIcon />
          </IconButton>

          {drawerMenu()}

          <Typography variant="h6" className={classes.title}>
            Le Teburu
          </Typography>
          <Button color="inherit">Iniciar Sesión</Button>
        </Toolbar>
      </AppBar>
      <div className={classes.offset}></div>
    </div>
  );
};

export default Navigation;
