import { combineReducers } from 'redux';
import MenuReducer from './MenuReducer';
import ProductReducer from './ProductReducer';

export default combineReducers({
  list: ProductReducer
});
