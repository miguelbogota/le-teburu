import { createStore } from 'redux';
import RootReducer from '../reducers/MenuReducer';

const store = createStore(RootReducer);

export default store;
