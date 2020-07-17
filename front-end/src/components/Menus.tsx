import React from "react";
import { Theme, createStyles, makeStyles } from "@material-ui/core/styles";
import clsx from "clsx";
import Collapse from "@material-ui/core/Collapse";
import IconButton from "@material-ui/core/IconButton";
import ExpandMoreIcon from "@material-ui/icons/ExpandMore";

const useStyles = makeStyles((theme: Theme) =>
  createStyles({
    menu: {
      display: "grid",
      gridTemplateColumns: "calc(90% - 10px) 10%",
      gap: "10px",
      maxWidth: 450,
      boxShadow: "0px 0px 7px 0px #00000030",
      padding: 10,
      margin: "0px 20px 20px",
    },
    menuTitle: {
      width: "100px",
      display: "flex",
      alignSelf: "center",
      fontSize: "19px",
      fontWeight: 400,
      paddingLeft: 8,
    },
    combosHidden: {
      gridColumn: "1 / span 2",
    },
    combo: {
      display: "grid",
      padding: 10,
      gap: "10px",
      gridTemplateColumns: "calc(60% - 10px) 40%",
      boxShadow: "0px 0px 7px 0px #0000001f",
      marginBottom: 10,
      "&:last-of-type": {
        marginBottom: 0,
      },
    },
    titleCard: {
      width: "100%",
      fontSize: "16px",
      fontWeight: 400,
      marginBottom: 10,
    },
    desc: {
      width: "100%",
      fontSize: "14px",
      fontWeight: 300,
    },
    media: {
      overflow: "hidden",
      position: "relative",
      display: "flex",
      flexDirection: "column",
      justifyContent: "center",
      alignItems: "center",
      padding: 15,
      minHeight: 90,
    },
    image: {
      height: "140%",
      position: "absolute",
      alignSelf: "center"
    },
    price: {
      backgroundColor: "#fff",
      padding: "6px",
      borderRadius: "2px",
      display: "block",
      zIndex: 20,
    },
    butoon: {
      backgroundColor: "#fff",
      marginTop: 5,
      transform: "rotate(-90deg)",
      zIndex: 20,
      "&:hover": {
        backgroundColor: "#fff",
      },
    },
    pad: {
      padding: 4,
    },
    ingre: {
      gridColumn: "1 / span 2",
    },
    expand: {
      transform: "rotate(0deg)",
      transition: theme.transitions.create("transform", {
        duration: theme.transitions.duration.shortest,
      }),
    },
    expandOpen: {
      transform: "rotate(180deg)",
    },
  })
);

const Card: React.FC = () => {
  const classes = useStyles();
  const [expanded, setExpanded] = React.useState(false);

  const handleExpandClick = () => {
    setExpanded(!expanded);
  };

  return (
    <div className={classes.combo}>
      <div className={classes.desc}>
        <h5 className={classes.titleCard}>Titulo combo</h5>
        <p>
          Descripcion del producto: Lorem, ipsum dolor sit amet consectetur
          adipisicing elit. Eos ad magni quos.
        </p>
        <IconButton
          className={clsx(classes.expand, {
            [classes.expandOpen]: expanded,
            [classes.pad]: true,
          })}
          style={{ marginTop: 8 }}
          onClick={handleExpandClick}
          aria-expanded={expanded}
          aria-label="show more"
        >
          <ExpandMoreIcon />
        </IconButton>
      </div>

      <div className={classes.media}>
        <img
          className={classes.image}
          src="https://images.unsplash.com/photo-1568901346375-23c9450c58cd?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=902&q=80"
        />
        <div className={classes.price}>$19.900</div>

        <IconButton className={[classes.butoon, classes.pad].join(" ")}>
          <ExpandMoreIcon />
        </IconButton>
      </div>

      <Collapse
        className={classes.ingre}
        in={expanded}
        timeout="auto"
        unmountOnExit
      >
        <div>Ingredientes: talez y pascuales. xD</div>
      </Collapse>
    </div>
  );
};

const Menus: React.FC = () => {
  const classes = useStyles();

  const [expanded, setExpanded] = React.useState(true);

  const handleExpandClick = () => {
    setExpanded(!expanded);
  };

  // Test
  const elements = ["one", "two", "three"];

  return (
    <div className={classes.menu}>
      <h4 className={classes.menuTitle}>Categoria</h4>

      <IconButton
        className={clsx(classes.expand, {
          [classes.expandOpen]: expanded,
        })}
        onClick={handleExpandClick}
        aria-expanded={expanded}
        aria-label="show more"
      >
        <ExpandMoreIcon />
      </IconButton>

      <Collapse
        className={classes.combosHidden}
        in={expanded}
        timeout="auto"
        unmountOnExit
      >
        {elements.map((value, index) => {
          return <Card key={index} />;
        })}
      </Collapse>
    </div>
  );
};

export default Menus;
