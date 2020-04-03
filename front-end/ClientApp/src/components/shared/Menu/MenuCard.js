import React from 'react';
import Card from '@material-ui/core/Card';
import CardContent from '@material-ui/core/CardContent';
import CardMedia from '@material-ui/core/CardMedia';
import IconButton from '@material-ui/core/IconButton';
import CardActions from '@material-ui/core/CardActions';
import Typography from '@material-ui/core/Typography';
import Collapse from '@material-ui/core/Collapse';
import ExpandMoreIcon from '@material-ui/icons/ExpandMore';
import NavigateNextIcon from '@material-ui/icons/NavigateNext';
import AddIcon from '@material-ui/icons/Add';
import RemoveIcon from '@material-ui/icons/Remove';
import { connect } from 'react-redux';
import { addToList } from '../../../actions';

class MenuCard extends React.Component {

  state = {
    expanded: false,
    count: this.props.menu.cantidad
  }

  handleExpandClick = () => {
    this.setState(prevState => ({ expanded: !prevState.expanded }))
  };

  // Funcion cambia el estado de la cantidad
  count = (upOrDown) => {
    if (upOrDown) {
      this.setState(prevState => ({ count: prevState.count + 1 }))
      if (this.state.count === 0) {
        const { dispatch } = this.props;
        dispatch(addToList(0, 1, this.props));
      }
    }
    else {
      this.setState(prevState => ({ count: prevState.count - 1 }))
      if (this.state.count === 1) {
        const { dispatch } = this.props;
        dispatch(addToList(1, 0, this.props));
      }
    }
  }

  render() {
    var optionsToShow;
    if (this.state.count <= 0) {
      optionsToShow = (
        <CardActions disableSpacing>
          <IconButton
            style={this.state.expanded ?
              { marginLeft: 'auto', transition: 'transform .4s ease', transform: 'rotate(180deg)' } :
              { transform: 'rotate(0deg)', marginLeft: 'auto', transition: 'transform .4s ease' }}
            onClick={this.handleExpandClick}
            aria-expanded={this.state.expanded}
            aria-label="show more"
          >
            <ExpandMoreIcon />
          </IconButton>

          <IconButton onClick={() => this.count(true)}>
            <NavigateNextIcon />
          </IconButton>
        </CardActions>
      )
    }
    else {
      optionsToShow = (
        <CardActions disableSpacing>
          <IconButton
            style={this.state.expanded ?
              { marginLeft: 'auto', transition: 'transform .4s ease', transform: 'rotate(180deg)' } :
              { transform: 'rotate(0deg)', marginLeft: 'auto', transition: 'transform .4s ease' }}
            onClick={this.handleExpandClick}
            aria-expanded={this.state.expanded}
            aria-label="show more"
          >
            <ExpandMoreIcon />
          </IconButton>

          <IconButton onClick={() => this.count(false)}>
            <RemoveIcon />
          </IconButton>

          <Typography variant="subtitle1" color="textSecondary">
            {this.state.count}
          </Typography>

          <IconButton onClick={() => this.count(true)}>
            <AddIcon />
          </IconButton>

        </CardActions>
      )
    }

    return (
      <Card style={{
        display: 'flex',
        margin: '0px auto 20px',
        maxWidth: 550,
        backgroundColor: '#F5EFF3'
      }}>
        <div style={{
          display: 'flex',
          flexDirection: 'column',
          width: 360
        }}>
          <CardContent style={{ flex: '1 0 auto', }}>
            <Typography component="h5" variant="h5">
              {this.props.menu.nombre}
            </Typography>
            <Typography variant="subtitle1" color="textSecondary">
              {
                (this.props.menu.precio * this.state.count === 0 ? this.props.menu.precio : this.props.menu.precio * this.state.count)
                  .toLocaleString('es-CO', {
                    style: 'currency',
                    currency: 'COP',
                  })
              } COP
          </Typography>
          </CardContent>
          <div style={{
            display: 'flex',
            alignItems: 'center',
            paddingLeft: 10,
            paddingBottom: 10,
          }}>

            {optionsToShow}

          </div>

          <Collapse in={this.state.expanded} timeout="auto" unmountOnExit>
            <CardContent>
              {
                this.props.menu.ingredientes.map((value, index) => {
                  return <Typography paragraph key={index}>{value}</Typography>
                })
              }
            </CardContent>
          </Collapse>
        </div>
        <CardMedia
          style={{
            width: 190,
            height: 164
          }}
          image={this.props.menu.imgUrl}
          title={this.props.menu.descripcion}
        />
      </Card>
    );
  }
}


export default connect()(MenuCard);
