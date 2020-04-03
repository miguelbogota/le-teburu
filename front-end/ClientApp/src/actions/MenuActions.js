import { CONSTANTS } from './index';

export const addToList = (listId, fromId, menu) => {
  return {
    type: CONSTANTS.SWITCH_MENU,
    payload: {
      toId: listId,
      fromId: fromId,
      menu: menu.menu
    }
  };
}